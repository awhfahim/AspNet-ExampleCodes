using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Course : IEntity<Guid>
    {
        public Instructor Teacher { get; set; }
        public List<Topic> Topic { get; set; }
        public int Fees { get; set; }
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
    }
}
