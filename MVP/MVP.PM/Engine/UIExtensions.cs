using System;
using System.Windows.Forms;

namespace MVP.Engine
{
    public static class UIExtensions
    {
        public static void Guard(this Control control, Action uiMutation)
        {
            if (control.InvokeRequired)
                control.BeginInvoke(uiMutation);
            else
                uiMutation();
        }
    }
}