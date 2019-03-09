using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Point
    {
        int x;
        int y;

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value > 39)
                {
                    x = 0;
                }
                else if (value < 0)
                {
                    x = 39;
                }
                else
                {
                    x = value;
                }
            }
        }

        public int Y {
            get
            {
                return y;
            }
            set
            {
                if (value > 39)
                {
                    y = 0;
                } 
                else if (value < 0)
                {
                    y = 39;
                }
                else
                {
                    y = value;
                }
            }
        }
    }
}
