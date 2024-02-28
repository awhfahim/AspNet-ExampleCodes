using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples.IMDBd
{
    public class Earning
    {
        public string Movie_Id { get; set; }
        public int Domestic { get; set; }
        public decimal Worldwide { get; set; }
    }
}
