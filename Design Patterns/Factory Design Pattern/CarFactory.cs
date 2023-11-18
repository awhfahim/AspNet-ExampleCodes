using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Pattern
{
    public abstract class CarFactory
    {
        public abstract ICar Create(string color, string model, int fuelCapacity);
    }
}
