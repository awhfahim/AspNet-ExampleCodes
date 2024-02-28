using System;
using System.Collections.Generic;
using LinqExamples;

namespace TCPData
{
    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                AnnualSalary = 60000.3m,
                IsManager = true,
                DepartmentId = 1,
                ManagerId = 1,
                HireDate = new DateTime(2022, 5, 21)
            };
            employees.Add(employee);
            
            employee = new Employee
            {
                Id = 1,
                FirstName = "Mr",
                LastName = "Zakaria",
                AnnualSalary = 60000.3m,
                IsManager = true,
                DepartmentId = 1,
                ManagerId = 3,
                HireDate = new DateTime(2022, 5, 21)
            };
            employees.Add(employee);
            
            employee = new Employee
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Jameson",
                AnnualSalary = 80000.1m,
                IsManager = true,
                DepartmentId = 1,
                ManagerId = 1,
                HireDate = new DateTime(2022, 11, 18)
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 3,
                FirstName = "Douglas",
                LastName = "Roberts",
                AnnualSalary = 40000.2m,
                IsManager = false,
                DepartmentId = 2,
                ManagerId = 2,
                HireDate = new DateTime(2018, 3, 9)
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Stevens",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 3,
                ManagerId = 3,
                HireDate = new DateTime(2023, 10, 27)
            };
            employees.Add(employee);employee = new Employee
            {
                Id = 5,
                FirstName = "Fahim",
                LastName = "Hasan",
                AnnualSalary = 35000.2m,
                IsManager = true,
                DepartmentId = 3,
                ManagerId = 1,
                HireDate = new DateTime(2022, 12, 14)
            };
            employees.Add(employee);employee = new Employee
            {
                Id = 6,
                FirstName = "Imon",
                LastName = "Chowdhury",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 2,
                ManagerId = 2,
                HireDate = new DateTime(2015, 3, 21)
            };
            employees.Add(employee);employee = new Employee
            {
                Id = 7,
                FirstName = "Imon",
                LastName = "Khan",
                AnnualSalary = 30000.2m,
                IsManager = true,
                DepartmentId = 4,
                ManagerId = 1,
                HireDate = new DateTime(2014, 1, 21)
            };
            employees.Add(employee);

            return employees;
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };
            departments.Add(department);
            
            department = new Department
            {
                Id = 4,
                ShortName = "IT",
                LongName = "Information"
            };
            departments.Add(department);

            return departments;
        }

        public static List<Manager> GetManagers()
        {
            List <Manager> list = new List<Manager>();
            list.Add(new Manager(1,"Fahim","Hasan"));
            list.Add(new Manager(2,"Bob","Jones"));
            list.Add(new Manager(3,"Abu","Wabaidar"));
            return list;
        }

        public static List<Calls> GetCalls()
        {
            List<Calls> callsList = new();
            callsList.Add(new Calls(){from_id = 1,to_id = 2,duration = 59});
            callsList.Add(new Calls(){from_id = 2,to_id = 1,duration = 11});
            callsList.Add(new Calls(){from_id = 1,to_id = 3,duration = 20});
            callsList.Add(new Calls(){from_id = 3,to_id = 4,duration = 100});
            callsList.Add(new Calls(){from_id = 3,to_id = 4,duration = 200});
            callsList.Add(new Calls(){from_id = 4,to_id = 3,duration = 499});

            return callsList;
        }

        public static List<Weather> GetWeathers()
        {
            var weather = new List<Weather>();
            weather.Add(new Weather(){Id = 1,RecordDate = DateOnly.Parse("14/02/2024"),Temperature = 20});
            weather.Add(new Weather(){Id = 2,RecordDate = DateOnly.Parse("15/02/2024"),Temperature = 20});
            weather.Add(new Weather(){Id = 3,RecordDate = DateOnly.Parse("16/02/2024"),Temperature = 18});
            weather.Add(new Weather(){Id = 4,RecordDate = DateOnly.Parse("17/02/2024"),Temperature = 26});
            weather.Add(new Weather(){Id = 5,RecordDate = DateOnly.Parse("18/02/2024"),Temperature = 20});
            weather.Add(new Weather(){Id = 6,RecordDate = DateOnly.Parse("19/02/2024"),Temperature = 30});
            return weather;
        }

    }
}
