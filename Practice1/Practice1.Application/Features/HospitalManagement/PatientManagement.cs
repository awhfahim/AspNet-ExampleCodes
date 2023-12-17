using Practice1.Domain.Entities;
using Practice1.Domain.Features.HospitalManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Application.Features.HospitalManagement
{
    public class PatientManagement : IPatientManagement
    {
        private IApplicationUnitOfWork _patientUnitOfWork;

        public PatientManagement(IApplicationUnitOfWork unitOfWork)
        {
            _patientUnitOfWork = unitOfWork;
        }

        public async Task AddPatientAsync(Patient patient)
        {
            _patientUnitOfWork.patientRepository.Add(patient);
            await _patientUnitOfWork.SaveAsync();
        }
    }
}
