using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Threading_Exercise
{
    class Gladiatrix
    {
        public string Name { get; set; }
        public int Resistance { get; set; }
        public int Strength { get; set; }
        public long LatestResult { get; set; }

        public Gladiatrix(string name, int resistance, int strength)
        {
            Name = name;
            Resistance = resistance;
            Strength = strength;
        }
    }
}
