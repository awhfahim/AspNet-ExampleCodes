using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Desing_Pattern
{
    public class Product : ICloneable
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public object Clone()
        {
            Product p = new Product();
            p.Name = Name;
            p.Price = Price;
            return p;
        }
    }
}
