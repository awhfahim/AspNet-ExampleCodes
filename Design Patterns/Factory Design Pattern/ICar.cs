using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Pattern
{
    public interface ICar
    {
        string Name { get; set; }
        string color { get; set; }
        int fuelCapacity { get; set; }
    }
}
