using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace appMain { 
    public class ScreenManager
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MonitorInfo
        {
            public uint size;
            public Rect monitor;
            public Rect work;
            public uint flags;
            public string DeviceName;
        }

        public delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, int dwData);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, int dwData);
        [DllImport("user32.dll")]
        public static extern bool GetMonitorInfo(IntPtr hmon, ref MonitorInfo mi);

        public static bool MonitorProc(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData)
        {
            
            
            return false;
        }

        public static bool procMonitor()
        {
            int monCount = 0;
            MonitorInfo mi = new MonitorInfo();
            /*MonitorEnumDelegate MonitorProc = (IntPtr hDesktop, IntPtr hdc, ref Rect lprcMonitor, int d) =>
            {
                monCount++;
                GetMonitorInfo(hDesktop, ref mi);
            };

            if (EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorProc, 0))
                Console.WriteLine("You have {0} monitors", monCount);
            else
                Console.WriteLine("An error occured while enumerating monitors");


            return EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorProc, 0);
            */
            return true;
        }
    }
}
