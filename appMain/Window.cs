using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMain
{
    class Window
    {
        private String ApplicationName { get; set; }
        private int TopCord { get; set; }
        private int BotCord { get; set; }
        private int LeftCord { get; set; }
        private int RightCord { get; set; }

        public Window(String applicationName, int top, int bottom, int left, int right)
        {
            this.TopCord = top;
            this.BotCord = bottom;
            this.LeftCord = left;
            this.RightCord = right;

            this.ApplicationName = applicationName;
        }

    }
}
