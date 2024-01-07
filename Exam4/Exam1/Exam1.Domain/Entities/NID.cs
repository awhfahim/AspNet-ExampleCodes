﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Domain.Entities
{
    public class NID : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PermanentAddress { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
    }
}
