using System;
using System.Runtime.InteropServices;

namespace appMain
{
    public class ApplicationManager
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public static RECT rct;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int AdjustWindowRect(ref RECT lpRect, int dwStyle, int bMenu);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetDesktopWindow(ref RECT lpRect, int dwStyle, int bMenu);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref RECT rectangle);
    }
}