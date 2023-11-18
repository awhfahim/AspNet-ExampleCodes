using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Pattern
{
    public class BMWFactory : CarFactory
    {
        public override ICar Create(string color, string model, int fuelCapacity)
        {
           return new BMW() { color = color, Name = model, fuelCapacity = fuelCapacity};
        }
    }
}
