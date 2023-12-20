using Practice1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Domain.Features.HospitalManagement
{
    public interface IDoctorManagement
    {
        Task AddDoctorAsync(string name, string chembar_Location, string expertise);

        Task<(IList<Doctor> records, int total, int totalDisplay)>
            GetPagedDoctorsAsync(int pageIndex, int pageSize, string searchText,
            string sortBy);
    }
}
