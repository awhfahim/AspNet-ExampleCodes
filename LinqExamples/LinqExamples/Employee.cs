using System;
namespace TCPData
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }
        public int ManagerId { get; set; }
        public DateTime HireDate { get; set; }
    }

    public record Manager(int Id, string FirstName, string LastName);
}
