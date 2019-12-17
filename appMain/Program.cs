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
            while(true)
            { 
                Process[] processes = Process.GetProcesses();

                foreach (Process p in processes)
                {
                    if (p.MainWindowHandle != null && !String.IsNullOrEmpty(p.MainWindowTitle))
                    {
                        if (p.MainWindowTitle.Contains("Discord"))
                        {
                            WindowManager.GetWindowRect(p.MainWindowHandle, ref WindowManager.rct);
                            Console.WriteLine();
                            Console.WriteLine("left " + WindowManager.rct.left);
                            Console.WriteLine("top " + WindowManager.rct.top);
                            Console.WriteLine("right " + WindowManager.rct.right);
                            Console.WriteLine("bottom " + WindowManager.rct.bottom);
                            Console.WriteLine();
                            WindowManager.MoveWindow(p.MainWindowHandle,
                                        2573,
                                        -218,
                                        (3629 - 2573),
                                        (622 + 218),
                                        true);

                        }

                        if (p.MainWindowTitle.Contains("Vivaldi"))
                        {
                            WindowManager.GetWindowRect(p.MainWindowHandle, ref WindowManager.rct);
                            Console.WriteLine();
                            Console.WriteLine("left " + WindowManager.rct.left);
                            Console.WriteLine("top " + WindowManager.rct.top);
                            Console.WriteLine("right " + WindowManager.rct.right);
                            Console.WriteLine("bottom " + WindowManager.rct.bottom);
                            Console.WriteLine();
                            WindowManager.MoveWindow(p.MainWindowHandle,
                                        2573,
                                        635,
                                        (3629 - 2573),
                                        (1643 - 635),
                                        true);

                        }

                    }
                }
                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine("before");
            ScreenManager.procMonitor();

        }
    }
}
