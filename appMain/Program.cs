using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace appMain
{
    class Program
    {

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            List<Window> applicationList = new List<Window>();
            ScreenManager screenManager = ProcMonitors();
            //LowLevelKeyboardHook keyboardHook = new LowLevelKeyboardHook();
            Console.WriteLine("iiii");
            
            int tmpRank = 0;
            foreach (Process p in processes)
            {
                if (p.MainWindowHandle != null && !String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    ApplicationManager.GetWindowRect(p.MainWindowHandle, ref ApplicationManager.rct);
                    Window newWindow = new Window(
                        p.ProcessName,
                        ApplicationManager.rct.top,
                        ApplicationManager.rct.bottom, 
                        ApplicationManager.rct.left, 
                        ApplicationManager.rct.right, 
                        tmpRank,
                        p);
                    tmpRank++;

                    Console.WriteLine(p.MainWindowTitle);
                    Console.WriteLine("==================================\n");
                    applicationList.Add(newWindow);
                }

            }

            List<Window> controlledApplicationList = GatherControlledApplications(applicationList);
            screenManager = AssignApplicationsToScreens(screenManager, controlledApplicationList);
            screenManager.resetMonitors();
            while (true)
            {
                foreach (Window controlledWindow in controlledApplicationList)
                {
                    if (controlledWindow != null)
                    {
                        // TODO if window application exits!
                        /*
                        if (controlledWindow.systemProcess.HasExited)
                        {
                            controlledApplicationList.Remove(controlledWindow);
                            screenManager.ActiveMonitors[1].resetApplicationsOnScreen();
                        }
                        */
                        ApplicationManager.MoveWindow(controlledWindow.systemProcess.MainWindowHandle,
                                            controlledWindow.Left,
                                            controlledWindow.Top,
                                            (controlledWindow.Right - controlledWindow.Left),
                                            (controlledWindow.Bottom - controlledWindow.Top),
                                            true);

                    }
                    System.Threading.Thread.Sleep(100);
                }
            }
        }

        private static ScreenManager AssignApplicationsToScreens(ScreenManager screenManager, List<Window> applications)
        {
            applications.ForEach((application) => {
                screenManager.ActiveMonitors.ForEach((monitor) =>
                {
                    if(isPointWithinScreen(monitor, application))
                    {
                        monitor.applicationsOnMonitor.Add(application);
                        Console.WriteLine("Application: " + application.ApplicationName + " lives on monitor: " + monitor.screen.DeviceName); 
                    }
                });
            });
            return screenManager;
        }

        private static bool isPointWithinScreen(ComputerMonitor computerMonitor, Window application)
        {
            if (computerMonitor.screen.WorkingArea.Left <= application.Left && computerMonitor.screen.WorkingArea.Top < application.Top &&
                computerMonitor.screen.WorkingArea.Right > application.Right &&
                computerMonitor.screen.WorkingArea.Bottom > application.Bottom)
                { 
                return true; 
            }
            return false;
        }


        public static ScreenManager ProcMonitors()
        {
            string msg = "";
            int monId = 1;
            ScreenManager screenManager = new ScreenManager();
            foreach (var screen in Screen.AllScreens)
            {
                var str =
                    $"Monitor {monId}: {screen.Bounds.Width} x {screen.Bounds.Height} @ {screen.Bounds.X},{screen.Bounds.Y}\n";

                msg += str;
                monId++;
                ComputerMonitor monitor = new ComputerMonitor();
                monitor.screen = screen;
                monitor.aspectRatio = ((double)screen.Bounds.Height / screen.Bounds.Width);
                screenManager.ActiveMonitors.Add(monitor);
            }
            Console.WriteLine(msg);
            return screenManager;
        }

        static int GetGreatestCommonDivisor(int a, int b)
        {
            return b == 0 ? a : GetGreatestCommonDivisor(b, a % b);
        }

        static List<Window> GatherControlledApplications(List<Window> applicationList)
        {
            String applicationName = "";
            List<Window> tmpControlledWindowList = new List<Window>();

            while (!applicationName.Equals("z"))
            {
                Console.WriteLine("Choose windows: ");
                applicationName = Console.ReadLine();
                Window tmpWindow = applicationList.Find(window => window.ApplicationName.ToLower().Contains(applicationName.ToLower())); // Specific Tracking
              
                if (tmpWindow != null)
                {

                    Console.Write("tracking: ");
                    Console.WriteLine(tmpWindow.ApplicationName);
                    tmpControlledWindowList.Add(tmpWindow);
                }
            }
            return tmpControlledWindowList;
        }
    }
}