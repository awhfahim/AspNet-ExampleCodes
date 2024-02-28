using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.TestCase1
{
    public class Color : IEntity<Guid>
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
