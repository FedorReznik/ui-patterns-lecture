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
        private readonly ICatFeederDriver _catFeederDriver = new CatFeederDriver();
        private readonly CancellationTokenSource _rootTokenSource = new CancellationTokenSource();
        
        private readonly TaskScheduler _scheduler;
        
        public MainFixed()
        {
            InitializeComponent();
            
            _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        private void btnFeedCatOnClick(object sender, EventArgs e)
        {
            btnFeedCat.Enabled = false;
            
            var cancellationToken = CancellationTokenSource
                .CreateLinkedTokenSource(_rootTokenSource.Token)
                .Token;
            
            _catFeederDriver.Feed(cancellationToken)
                .ContinueWith(t =>
                    {
                        try
                        {
                            t.Wait(cancellationToken);
                            
                            if(cancellationToken.IsCancellationRequested)
                                return;
                            
                            NotifySuccess();
                            btnFeedCat.Enabled = true;
                        }
                        catch (AggregateException ae)
                        {
                            ProcessError(ae);
                        }
                    }, 
                    _scheduler);
        }

        private void NotifySuccess()
        {
            MessageBox.Show(this, "The cat is successfully fed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void ProcessError(AggregateException ae)
        {
            ae.Flatten()
                .InnerExceptions
                .Where(ex => !(ex is OperationCanceledException))
                .ForEach(ex => MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _rootTokenSource.Cancel();
            base.OnClosing(e);
        }
    }
}