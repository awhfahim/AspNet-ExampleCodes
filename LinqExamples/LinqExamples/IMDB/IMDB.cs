using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples.IMDBd
{
    public class IMDB
    {
        public string? Movie_id { get; set; }
        public string? Title { get; set; }
        public decimal? Rating { get; set; }
        public decimal? Budget { get; set; }
        public decimal? MetaCritic { get; set; }
    }
}
