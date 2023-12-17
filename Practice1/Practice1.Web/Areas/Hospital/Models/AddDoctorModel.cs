using Autofac;
using Practice1.Domain.Entities;
using Practice1.Domain.Features.HospitalManagement;
using System.ComponentModel.DataAnnotations;

namespace Practice1.Web.Areas.Hospital.Models
{
    public class AddDoctorModel
    {
        private IDoctorManagement _doctorManagement;

        [Required(ErrorMessage = "Enter Your Name")]
        public string Name { get; set; }
        public string Chembar_Location { get; set; }
        public string Expertise { get; set; }
        public AddDoctorModel() { }

        public AddDoctorModel(IDoctorManagement doctorManagement) => _doctorManagement = doctorManagement;

        internal void Resolve(ILifetimeScope scope)
        {
            _doctorManagement = scope.Resolve<IDoctorManagement>();
        }

        internal async Task AddDoctorAsync(AddDoctorModel doctor)
        {
            await _doctorManagement.AddDoctorAsync(doctor.Name, doctor.Chembar_Location, doctor.Expertise);
        }
    }
}
