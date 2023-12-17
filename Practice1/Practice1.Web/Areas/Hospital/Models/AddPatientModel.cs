using Autofac;
using Practice1.Domain.Entities;
using Practice1.Domain.Features.HospitalManagement;

namespace Practice1.Web.Areas.Hospital.Models
{
    public class AddPatientModel
    {
        private IPatientManagement _patientMangement;
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public AddPatientModel() { }
        public AddPatientModel(IPatientManagement patientManagement) => _patientMangement = patientManagement;

        internal void Resolve(ILifetimeScope scope)
        {
            _patientMangement = scope.Resolve<IPatientManagement>();
        }

        internal async Task AddPatientAsync(AddPatientModel model)
        {
            var patient = new Patient { Name = model.Name, Address = model.Address, Age = model.Age };
            await _patientMangement.AddPatientAsync(patient);
        }

    }
}
