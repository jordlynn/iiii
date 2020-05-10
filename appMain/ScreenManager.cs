using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;

namespace appMain { 
    public class ScreenManager : Attribute
    {
        public List<ComputerMonitor> ActiveMonitors = new List<ComputerMonitor>();


        public bool resetMonitors()
        {
            ActiveMonitors.ForEach((monitor) => {
                monitor.resetApplicationsOnScreen();
            });

            return true;
        }
    }
}
