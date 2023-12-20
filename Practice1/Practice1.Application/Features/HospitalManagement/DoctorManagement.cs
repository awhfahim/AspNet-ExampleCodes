using Practice1.Domain.Entities;
using Practice1.Domain.Features.HospitalManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Application.Features.HospitalManagement
{
    public class DoctorManagement : IDoctorManagement
    {
        private IApplicationUnitOfWork _unitOfWork;

        public DoctorManagement(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddDoctorAsync(string name, string chembar_Location, string expertise)
        {
            var isDuplicate = await _unitOfWork.doctorRepository.IsDuplicateAsync(name);
            if (isDuplicate)
                throw new InvalidOperationException("Already Available in Database");

            var doctor = new Doctor() { Name = name, Chembar_Location = chembar_Location, Expertise = expertise };
             _unitOfWork.doctorRepository.Add(doctor);
            await _unitOfWork.SaveAsync();
        }

        public async Task<(IList<Doctor> records, int total, int totalDisplay)> GetPagedDoctorsAsync(int pageIndex, int pageSize, string searchText, string sortBy)
        {
            return await _unitOfWork.doctorRepository.GetTableDataAsync(searchText, sortBy,
                pageIndex, pageSize);
        }
    }
}
