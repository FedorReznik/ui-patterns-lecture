# The history of UI architecture design approaches: from Code-behind to MVVM.

By Fedor Reznik

## 1. Preface.

### 1.1. The purpose 

&nbsp;&nbsp;&nbsp;&nbsp;The whole purpose of this article is to summarize author's experience with regard to UI development and how it evolved via .Net technologies prism. Thus this point of view is highly opinionated and doesn't pretend to be 100% truth. Neither it is historically correct - in the end the MVC pattern itself is older than .Net! We will try to focus on trade-offs of different approaches and why developers have moved from one to another - trying to reveal the idea(s) behind them.
</br>
&nbsp;&nbsp;&nbsp;&nbsp;To give more examples we will need some kind of "Business/Problem domain" wired through different solutions. The problem is if we select a complex one we will hide the ideas in KLOCs and KLOCs of code not related to the actual topic. If we select a simple one some of our arguments might seem a bit artificial and issues highlighted can look dubious or non-existing at all. Well, we will try to keep the domain as simple as it possible - so prepare your imagination to extend the pros and cons highlighted to more complex areas.

### 1.2. Domain

&nbsp;&nbsp;&nbsp;&nbsp;Let's imagine that we are running an automatic cat feeder business. Right now we are only providing hardware configured feeders - with physical buttons on device. Our engineering team has developed and integrated into device the bluetooth adapter, as well as provided corresponding driver, so the idea is to quickly provide application to control cat feeder remotely. 

### 1.3. First User Story

&nbsp;&nbsp;&nbsp;&nbsp;To quickly conquer the market we as the company must provide the simplest yet use-full desktop application: it should contain only "Feed the cat" button and should provide feedback if the feeding has been successful. So our UX team came-out with the following design:
<img src="Images/CatFeederAppUX.png"/> 
And the status of feeding should be provided by modal dialog with success/fail message and OK button to close it.

## 2. Back in the days. Code-behind

### 2.1 Code-behind "pattern" definition

&nbsp;&nbsp;&nbsp;&nbsp;Let's imagine that everything is happening around 2005 and our team has proven expertise in Windows Forms, as well as code-behind approach seems quick and easy to implement: just open the form designer in your IDE, put some controls on it, wire the event handlers with mouse click, put the code into handlers and you are done. So you can hardly call this a pattern, the better word would be a process.

### 2.2 The implementation

&nbsp;&nbsp;&nbsp;&nbsp;The best part of this approach is that there is almost nothing to discuss, so the basic implementation can look like this (you can find the complete solution [here](./Code-behind/)), see [Main.cs](./Code-behind/CodeBehind/Main.cs) file:
```C#
public partial class Main : Form
{
    // 1. Instantiating the driver. 
    private readonly ICatFeederDriver _catFeederDriver = new CatFeederDriver();
    private readonly TaskScheduler _uiScheduler;
    
    public Main()
    {
        InitializeComponent();
        
        _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    }

    private void btnFeedCatOnClick(object sender, EventArgs e)
    {
        // 2. Executing feeding
        _catFeederDriver.Feed(CancellationToken.None)
            .ContinueWith(t =>
                {
                    try
                    {
                        t.Wait();
                        // 3. Handling successful case 
                        NotifySuccess();
                    }
                    catch (AggregateException ae)
                    {
                        // 4. Handling error case
                        ProcessError(ae);
                    }
                }, 
                // 5. Doing so on UI thread, respecting the STA nature of Windows Forms
                _uiScheduler);
    }

    private void NotifySuccess()
    {
        MessageBox.Show(
            this,
            "The cat is successfully fed!",
            "Success",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void ProcessError(AggregateException ae)
    {
        ae.Flatten()
            .InnerExceptions
            .ForEach(ex => MessageBox.Show(
                    this,
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error));
    }
}
```
&nbsp;&nbsp;&nbsp;&nbsp;As you can see we are doing straightforward steps:
1. Instantiating the `CatFeederDriver`
2. Calling `Feed` method in button click event handler - `btnFeedCatOnClick`
3. Handling successful feeding
4. Handling error during feeding
5. Notifications should be shown on UI thread to adhere STA nature of desktop apps, so we are using continuation also avoiding avoiding `async void` method signature

Simple. Effective. Quick. Or...?

### 2.3 Here comes the issues

&nbsp;&nbsp;&nbsp;&nbsp;Let's take a closer look on our code and try to answer is it easy to test? Unfortunately it is not, because to implement a test we need to instantiate our form in the correct environment e.g. in STA. More over we cannot separately test the logic - basically only end to end testing is possible. Now even if we want to create e2e test we will ought to use either reflection to call private `btnFeedCatOnClick` method or use UI-automation tools, which are notorious for their instability. So the only reasonable solution is to have manual QA team which will test it.
</br>
&nbsp;&nbsp;&nbsp;&nbsp;And QA fortunately did find the issues:
- First issue - driver throws exception if we are trying to call `Feed` while feeding in progress
- Second issue - was much more harder to find: it appears, that closing the window w/o proper waiting for feeding to finish causes a memory leak in device. **Note:** This behavior is modeled via logging the correct feeding cancellation, see [CatFeederDriver.cs](./FeederDriver/FeederDriver/CatFeederDriver.cs) - just use your imagination.

&nbsp;&nbsp;&nbsp;&nbsp;Of course our dev-team quickly fixes it, see [MainFixed.cs](./Code-behind/CodeBehind/MainFixed.cs) (Please also change `@fixed` variable to true in [Program.cs](./Code-behind/CodeBehind/Program.cs)):
```C#
public partial class MainFixed : Form
{
    // 1. Instantiating the driver. 
    private readonly ICatFeederDriver _catFeederDriver = new CatFeederDriver();
    // 2. Instantiating root token
    private readonly CancellationTokenSource _rootTokenSource = new CancellationTokenSource();
    
    private readonly TaskScheduler _scheduler;
    
    public MainFixed()
    {
        InitializeComponent();
        
        _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    }

    private void btnFeedCatOnClick(object sender, EventArgs e)
    {
        // 3. Disabling feed button to avoid crash on concurrent feeding
        btnFeedCat.Enabled = false;
        
        // 4. Initializing child lifetime for feeding operation
        var cancellationToken = CancellationTokenSource
            .CreateLinkedTokenSource(_rootTokenSource.Token)
            .Token;
        
        // 5. Executing feeding
        _catFeederDriver.Feed(cancellationToken)
            .ContinueWith(t =>
                {
                    try
                    {
                        t.Wait(cancellationToken);

                        if (cancellationToken.IsCancellationRequested)
                            return;

                        // 6. Handling successful case
                        NotifySuccess();
                    }
                    catch (AggregateException ae)
                    {
                        // 7. Handling error case
                        ProcessError(ae);
                    }
                    finally
                    {
                        // 8. Enabling feed button
                        btnFeedCat.Enabled = true;
                    }
                }, 
                // 9. Doing so on UI thread, respecting the STA nature of Windows Forms
                _scheduler);
    }

    private void NotifySuccess()
    {
        MessageBox.Show(
            this,
            "The cat is successfully fed!", "Success",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void ProcessError(AggregateException ae)
    {
        ae.Flatten()
            .InnerExceptions
            .Where(ex => !(ex is OperationCanceledException))
            .ForEach(ex => MessageBox.Show(
                this,
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error));
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        // 10. Cancelling root token on Form closing
        _rootTokenSource.Cancel();
        base.OnClosing(e);
    }
}
```
&nbsp;&nbsp;&nbsp;&nbsp;Let's see what logical steps we are executing now:
1. Instantiating the `CatFeederDriver`
2. Instantiating root token which will be bound to Form lifetime
3. Disabling feed button to avoid crash on concurrent feeding
4. Initializing child lifetime for feeding operation
5. Calling `Feed` method in button click event handler - `btnFeedCatOnClick`
6. Handling successful feeding
7. Handling error during feeding
8. Enabling feed button
9. All the UI changes are invoked on UI thread
10. Cancelling root token on Form closing

&nbsp;&nbsp;&nbsp;&nbsp;Much more to keep in mind compared to the first implementation! In addition we have the following problems with code-behind approach:
- Mix of UI and functional code - we can't separate work between "tech-guru" and "UI-guru"
- Hardly auto-testable code, so one need to have a manual regression test-cycle
- We also can't re-use this code in other parts of our project

&nbsp;&nbsp;&nbsp;&nbsp;These and other problems can be formalized via NFRs: a non-functional requirements that specifies criteria that can be used to judge the operation of a system, rather than specific behaviors. They are contrasted with functional requirements that define specific behavior or functions. For this article we will select the following subset of NFRs:
- Testability - the ability to implement the pyramid of tests: unit, integration, e2e
- Extensibility - the ability to bring new features into the project without pain
- Adaptability - the ability to withstand technology change. Usually we are supposing that technology will stay forever and you won't change your UI framework or database or whatever. But the author was involved in such a projects like adapting WinCE application to IOS and Android, so if your approach gives your possibility to quickly change the framework and not requiring to much effort to do it - it's better
- Effectiveness - the ability to bring mode developers into the project and split the work between them. This NFR is usually tightly related to Time-to-Market (TTM)
- Reusability - the ability to move functionality between components.
- Readability - the ability to minimize cognitive pressure then reading the code - usually it is easier to think about one aim at the time and trust the contracts you have. It also related to the amount of boilerplate one need to get through

&nbsp;&nbsp;&nbsp;&nbsp;So for code-behind we will have the following assessment:

| NFR | Yes/No | Comment |
|-----|--------|---------|
| Testability | *No* | e2e via UI Automation is possible |
| Extensibility | *No* | New Forms can be added |
| Adaptability | *No* | UI is mixed with logic, so changing any part of technology is complicated |
| Effectiveness | *No* | *Frontend* and *backend* will working with the same set of files, not via contracts |
| Reusability | *No* |  One can extract UserControl(s) to improve it a bit |
| Readability | *No* | The more features we will add the bigger and dirty will code-behind file become |

### The Blasphemy

&nbsp;&nbsp;&nbsp;&nbsp;The code-behind approach may work! Indeed if you have:

- Single responsibility windows with almost no validation logic, for example CRUD.
- Multiple-windows UI, e.g. when any new operation is done by opening new window instead of changing the content of the shown one
- User interaction is focused around entering data and confirmation dialogs.

In this case one can still maintain the good enough balance between code complexity and TTM. And it was actually working in early days when software was quite simple in terms of interaction, but still very useful, because it was automating daily routine. 

&nbsp;&nbsp;&nbsp;&nbsp;But soon everything was about to change...

## 3. Moving to patterns

### 3.1 The driving force of change

## 4. MVC

## 5. MVP

## 6. MVVM

## 7. Conclusion

### 7.1 Modern state

### 7.2 Which approach to select?