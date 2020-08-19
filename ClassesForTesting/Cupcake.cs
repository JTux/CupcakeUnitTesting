using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesForTesting
{
    public class Cupcake
    {
        public Cupcake(string batter, string icing, double cost)
        {
            Batter = batter;
            Icing = icing;
            Cost = cost;
        }

        public string Batter { get; set; }
        public string Icing { get; set; }
        public double Cost { get; set; }

        public string GetDescription()
        {
            return $"A ${Cost} {Batter} cupcake with {Icing} on top!";
        }
    }
}
