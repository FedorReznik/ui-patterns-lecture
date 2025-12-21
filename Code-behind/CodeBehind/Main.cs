using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FeederDriver;
using MoreLinq.Extensions;

namespace CodeBehind
{
    [SuppressMessage("ReSharper", "LocalizableElement")]
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
                            // 3.1 Handling successful case 
                            NotifySuccess();
                        }
                        catch (AggregateException ae)
                        {
                            // 3.2 Handling error case
                            ProcessError(ae);
                        }
                    }, 
                    // 4. Doing so on UI thread, respecting the STA nature of Windows Forms
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

        private static void ProcessError(AggregateException ae)
        {
            ae.Flatten()
                .InnerExceptions
                .ForEach(ex => MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error));
        }
    }
}