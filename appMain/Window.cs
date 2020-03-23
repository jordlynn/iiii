using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMain
{
    class Window
    {
        public String ApplicationName { get; set; }
        public int TopCord { get; set; }
        public int BotCord { get; set; }
        public int LeftCord { get; set; }
        public int RightCord { get; set; }

        public int Rank { get; set; }

        public Process systemProcess { get; set; }

        public Window LeftChild { get; set; }
        public Window RightChild { get; set; }
        public Window ParentWindow { get; set; }

        public Window(String applicationName, int top, int bottom, int left, int right, int rank, Process process)
        {
            TopCord = top;
            BotCord = bottom;
            LeftCord = left;
            RightCord = right;
            Rank = rank;
            ApplicationName = applicationName;
            systemProcess = process;
        }

    }
}
