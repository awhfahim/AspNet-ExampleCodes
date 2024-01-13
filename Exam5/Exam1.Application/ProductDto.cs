using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Application
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint FullPrice { get; set; }
        public double Weight { get; set; }
    }
}
