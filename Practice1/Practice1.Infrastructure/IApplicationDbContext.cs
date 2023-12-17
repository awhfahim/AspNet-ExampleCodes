using Microsoft.EntityFrameworkCore;
using Practice1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Infrastructure
{
    public interface IApplicationDbContext
    {
        public DbSet<Doctor> Doctors { get; }
        public DbSet<Patient> Patients { get; }
    }
}
