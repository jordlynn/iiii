using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appMain
{
    public class ComputerMonitor 
    {
        public Screen screen;
        public List<Window> applicationsOnMonitor = new List<Window>();
        public Double aspectRatio;

        public void resetApplicationsOnScreen()
        {
            if (this.aspectRatio == 1.7777777777777777) // vert. 
            {
                resetApplicationOnTallScreen();
            }
            if (this.aspectRatio == 0.5625) // horizontal
            {
                resetApplicationOnWideScreen();
            };
        }

        private void resetApplicationOnWideScreen()
        {
            if (applicationsOnMonitor.Count == 0)
            {
                return;
            }

            int applicationCount = applicationsOnMonitor.Count;
            int equalApplicationWidth = this.screen.WorkingArea.Width / applicationCount;
            int xCord = this.screen.WorkingArea.X;

            applicationsOnMonitor.ForEach((application) =>
            {
                application.Left = xCord;
                application.Right = xCord + equalApplicationWidth;
                application.Top = this.screen.WorkingArea.Top;
                application.Bottom = this.screen.WorkingArea.Bottom;

                ApplicationManager.MoveWindow(application.systemProcess.MainWindowHandle,
                    xCord,
                    this.screen.WorkingArea.Top,
                    equalApplicationWidth,
                    this.screen.WorkingArea.Bottom,
                    true);
                xCord += equalApplicationWidth;
            });
        }

        private void resetApplicationOnTallScreen()
        {
            if (applicationsOnMonitor.Count == 0)
            {
                return;
            }

            int applicationCount = applicationsOnMonitor.Count;
            int equalApplicationHeightOffset = this.screen.WorkingArea.Height / applicationCount;
            int yCord = this.screen.WorkingArea.Y;

            applicationsOnMonitor.ForEach((application) =>
            {
                ApplicationManager.MoveWindow(application.systemProcess.MainWindowHandle,
                    yCord,
                    this.screen.WorkingArea.Top,
                    equalApplicationHeightOffset,
                    this.screen.WorkingArea.Bottom,
                    true);

                application.Left = this.screen.WorkingArea.Left;
                application.Right = this.screen.WorkingArea.Right;
                application.Top = yCord;
                application.Bottom = yCord + equalApplicationHeightOffset;

                yCord += equalApplicationHeightOffset;
            });
        }
    }
}
