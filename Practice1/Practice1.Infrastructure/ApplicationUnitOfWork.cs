using Microsoft.EntityFrameworkCore;
using Practice1.Application;
using Practice1.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IDoctorRepository doctorRepository { get; private set; }

        public IPatientRepository patientRepository {  get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext, IDoctorRepository _doctorRepository,
            IPatientRepository _patientRepository) : base((DbContext)dbContext)
        {
            doctorRepository = _doctorRepository;
            patientRepository = _patientRepository;
        }

    }
}
