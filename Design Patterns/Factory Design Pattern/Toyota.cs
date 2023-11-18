using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Pattern
{
    public class Toyota : ICar
    {
        public string Name { get; set; }
        public string color { get; set; }
        public int fuelCapacity { get; set; }
    }
}
