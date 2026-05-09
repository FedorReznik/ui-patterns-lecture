using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FeederDriver;
using MoreLinq.Extensions;

namespace CodeBehind
{
    [SuppressMessage("ReSharper", "LocalizableElement")]
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
}