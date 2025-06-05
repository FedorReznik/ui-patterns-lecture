using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows.Forms;
using FeederDriver;
using MoreLinq.Extensions;

namespace UserStory1
{
    [SuppressMessage("ReSharper", "LocalizableElement")]
    public partial class Main : Form
    {
        private readonly IFeederDriver1 _feederDriver = new FeederDriverImpl();
        private readonly TaskScheduler _scheduler;
        
        public Main()
        {
            InitializeComponent();
            
            _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        private void btnFeedCatOnClick(object sender, EventArgs e)
        {
            _feederDriver.Feed()
                .ContinueWith(t =>
                    {
                        try
                        {
                            t.Wait();
                            NotifySuccess();
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
                .ForEach(ex => MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));
        }
    }
}