using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Domain.Entities
{
    public class Doctor : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Chembar_Location { get; set; }
        public string? Expertise { get; set; }

    }
}
