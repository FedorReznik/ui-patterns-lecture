﻿using System;
using System.Windows.Forms;

namespace MVC.Routing.Engine
{
    public interface INavigationHost
    {
        void ShowView(UserControl view);

        event Action Initialized;
        
        Form Host { get; }
    }
}