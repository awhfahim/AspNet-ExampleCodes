using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoAssignment3
{
    public class Instructor
    {
        public Guid Id { get; set; }
        public Guid PresentAddressId { get; set; }
        public Guid ParmanentAddressId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Age { get; set; }

        [ForeignKey("PresentAddressId")]
        public Address PresentAddress { get; set; }

        [ForeignKey("ParmanentAddressId")]
        public Address ParmanentAddress { get; set; }
    }
}
