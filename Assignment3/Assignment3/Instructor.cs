using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Instructor : IEntity<Guid>
    {
        public List<Phone> PhoneNumbers { get; set; }
        public Address PresentAddress { get; set; }
        public Guid Id { get;set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address PermanentAddress { get; set; }
    }

    public class Address : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Area> Areas { get; set; }
    }

    public class Phone : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Extension { get; set; }
        public string CountryCode { get; set; }
    }

    public class Area : IEntity<Guid>
    {
        private string _name;
        public Guid Id { get; set; }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public bool IsActive { get; set; }
        public AreaType AreaType { get; set; }
    }

    public enum AreaType
    {
        Upozila,
        Corporation,
        Division
    }
}
