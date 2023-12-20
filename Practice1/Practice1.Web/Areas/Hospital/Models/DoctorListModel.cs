using Practice1.Domain.Features.HospitalManagement;
using Practice1.Infrastructure;
using System.Web;

namespace Practice1.Web.Areas.Hospital.Models
{
    public class DoctorListModel
    {
        private IDoctorManagement doctorManagement;
        public DoctorListModel() { }
        public DoctorListModel(IDoctorManagement doctorManagement)
        {
            this.doctorManagement = doctorManagement;
        }

        public async Task<object> GetPagedDoctorsAsync(DataTablesAjaxRequestUtility dataTablesUtility)
        {           
            var data = await doctorManagement.GetPagedDoctorsAsync(
                dataTablesUtility.PageIndex,
                dataTablesUtility.PageSize,
                dataTablesUtility.SearchText,
                dataTablesUtility.GetSortText(new string[] { "Name", "Expertise" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                HttpUtility.HtmlEncode(record.Name!),
                                HttpUtility.HtmlEncode(record.Chembar_Location!),
                                 HttpUtility.HtmlEncode(record.Expertise!),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
    }
}
