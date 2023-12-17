using Practice1.Domain;
using Practice1.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IDoctorRepository doctorRepository {  get; }
        IPatientRepository patientRepository { get; }
    }
}
