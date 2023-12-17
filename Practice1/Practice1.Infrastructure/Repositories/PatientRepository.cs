using Microsoft.EntityFrameworkCore;
using Practice1.Domain.Entities;
using Practice1.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Infrastructure.Repositories
{
    public class PatientRepository : Repository<Patient, Guid>, IPatientRepository
    {
        public PatientRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }
    }
}
