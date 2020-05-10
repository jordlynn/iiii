using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMain
{
    public class Window
    {
        public String ApplicationName { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int Rank { get; set; }

        public Process systemProcess { get; set; }

        public Window LeftChild { get; set; }
        public Window RightChild { get; set; }
        public Window ParentWindow { get; set; }

        public Window(String applicationName, int top, int bottom, int left, int right, int rank, Process process)
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
            Rank = rank;
            ApplicationName = applicationName;
            systemProcess = process;
        }

    }
}
