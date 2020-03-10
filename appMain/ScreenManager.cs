using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;

namespace appMain { 
    public class ScreenManager
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public long left;
            public long top;
            public long right;
            public long bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MonitorInfo
        {
            public int size;
            public Rect monitor;
            public Rect work;
            public uint flags;
            public string DeviceName;
        }

        public delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, int dwData);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, int dwData);
        [DllImport("user32.dll")]
        public static extern bool GetMonitorInfo(IntPtr hmon, [In, Out] MonitorInfo mi);

        public static bool MonitorProc(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData)
        {
            
            
            return false;
        }

        public static bool procMonitor()
        {
            int monCount = 0;
            MonitorInfo mi = new MonitorInfo();
            mi.size = Marshal.SizeOf(typeof(MonitorInfo));
            List<MonitorInfo> monitors = new List<MonitorInfo>();

            MonitorEnumDelegate MonitorProc = (IntPtr hDesktop, IntPtr hdc, ref Rect lprcMonitor, int d) =>
            {
                monCount++;
                if(GetMonitorInfo(hDesktop, mi))
                {
                    monitors.Add(mi);
                    Console.WriteLine("name");
                    Console.WriteLine(mi.work.bottom + "x" + mi.work.right);
                }
                return true;
            };
            
            if (EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorProc, 0))
                Console.WriteLine("You have {0} monitors", monCount);
            else
                Console.WriteLine("An error occured while enumerating monitors");


            return EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorProc, 0);
            
            //return true;
        }
    }
}
