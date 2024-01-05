using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Application.Dtos
{
    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public uint Price { get; set; }
        public uint Weight { get; set; }
    }
}
