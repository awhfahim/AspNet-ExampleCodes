using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Pattern
{
    public class ToyotaFactory : CarFactory
    {
        public override ICar Create(string color, string model, int fuelCapacity)
        {
            return new Toyota { color = color, Name = model, fuelCapacity = fuelCapacity };
        }
    }
}
