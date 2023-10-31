using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonFormat
{
    public class Course
    {
        public int Id { get; set; }       
        public readonly double Price;
        public string Name { get; set; }
    }
}
