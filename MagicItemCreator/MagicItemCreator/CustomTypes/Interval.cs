using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicItemCreator.CustomTypes
{
    public class Interval
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public Interval(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public Boolean Inside(int x)
        {
            return ((x <= Max) && (x >= Min));
        }
    }
}
