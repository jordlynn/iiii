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
            List<Window> windowList = new List<Window>();

            Console.WriteLine("iiii");
            int tmpRank = 0;
            foreach (Process p in processes)
            {
                if (p.MainWindowHandle != null && !String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    WindowManager.GetWindowRect(p.MainWindowHandle, ref WindowManager.rct);
                    Window newWindow = new Window(
                        p.ProcessName,
                        WindowManager.rct.top,
                        WindowManager.rct.bottom,
                        WindowManager.rct.left,
                        WindowManager.rct.right,
                        tmpRank,
                        p);
                    tmpRank++;

                    Console.WriteLine(p.MainWindowTitle);
                    Console.WriteLine("==================================\n");
                    windowList.Add(newWindow);
                }

            }

            Console.WriteLine("Choose windows: ");
            string windowName = Console.ReadLine();
            List<Window> controlledWindowList = GatherControlledWindows(windowList);

            while (true)
            {
                foreach (Window controlledWindow in controlledWindowList)
                {
                    if (controlledWindow != null)
                    {
                        WindowManager.MoveWindow(controlledWindow.systemProcess.MainWindowHandle,
                                            controlledWindow.LeftCord,
                                            controlledWindow.TopCord,
                                            (controlledWindow.RightCord - controlledWindow.LeftCord),
                                            (controlledWindow.BotCord - controlledWindow.TopCord),
                                            true);

                    }
                    System.Threading.Thread.Sleep(100);
                }
            }
        }

        static List<Window> GatherControlledWindows(List<Window> windowList)
        {
            String windowName = "";
            List<Window> tmpControlledWindowList = new List<Window>();

            while (!windowName.Equals("z"))
            {
                Console.WriteLine("Choose windows: ");
                windowName = Console.ReadLine();
                Window tmpWindow = windowList.Find(window => window.ApplicationName.ToLower().Contains(windowName.ToLower())); // Specific Tracking
              
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