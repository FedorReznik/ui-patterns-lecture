using System;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace MVP.Engine
{
    public interface INavigationHost
    {
        void ShowView([NotNull] UserControl view);

        event Action Initialized;
        
        Form Host { get; }
    }
}