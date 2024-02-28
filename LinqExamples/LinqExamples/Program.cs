// See https://aka.ms/new-console-template for more information
using LinqExamples;
using LinqExamples.Extensions;
using LinqExamples.IMDBd;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TCPData;

var products = new List<Product>().GetProducts();

var customers = new List<Customer>().GetCustomers();

var employees = Data.GetEmployees();
var departments = Data.GetDepartments();
var managers = Data.GetManagers();

#region(Practice)
//var result = employees.Join(departments, e => e.DepartmentId, d => d.Id, (e,d) => new 
//{
//    e.FirstName, e.DepartmentId, d.LongName
//}).ToList();

/// Inner Join

//var resultList = employees.Join(
//    employees,
//    e1 => e1.Id,
//    e2 => e2.DepartmentId,
//    (e1, e2) => (e1, e2)
//).ToList();

//var result = from emp in employees
//             join dep in departments on emp.DepartmentId equals dep.Id
//             select new
//             {
//                 EmployeeName = emp.FirstName + " " + emp.LastName,
//                 DepartmentName = dep.LongName
//             };


///Left Join

//var result = departments.GroupJoin(employees, d => d.Id, e => e.DepartmentId, (d,e) => (d.LongName, e)).ToList();

//var result = from dep in departments
//             join emp in employees
//             on dep.Id equals emp.DepartmentId
//             into employeeGroup orderby dep.Id, dep.LongName descending
//             select new
//             {
//                 Employees = employeeGroup,
//                 DepartmentName = dep.LongName
//             };

//foreach (var r in result)
//{
//    Console.WriteLine($"{r.DepartmentName,10} ");
//    foreach (var c in r.Employees)
//    {
//        Console.WriteLine($"{c.FirstName} {c.LastName} ");
//    }
//}


//var result = employees.Join(departments, e => e.DepartmentId, d => d.Id, (e,d) => new {e.FirstName, d.LongName, d.Id})
//    .OrderBy(x => x.LongName)
//    .GroupBy(x => x.LongName).ToList();

//var t = from item in result
//        li

//foreach (var item in t)
//{
//    Console.WriteLine($"{item.ProductName} {item.ProductID} {item.Category}");
//}
#endregion

#region 10 Question With Answer
/// Question 1 : Retrieve all employees who belong to a specific department

// var ans1 = employees.Where(x => x.DepartmentId == 4).ToList();

/// Question 2 : Get the total count of employees in each department

//var ans2 = departments.GroupJoin(employees, d => d.Id, e => e.DepartmentId,
// (e, employeeList) => new { e.LongName, employeeListCount = employeeList.Count() }).ToList();

//foreach (var ans in ans2)
//{
//    Console.WriteLine($"{ans.LongName} {ans.employeeListCount}");
//}

/// Question 3 : Find the departments with the highest number of employees

//var ans3 = departments.GroupJoin(employees, d => d.Id, e => e.DepartmentId,
//           (e, employeeList) => new { e.LongName, employeeListCount = employeeList.Count() }).Max(x => x.employeeListCount);

//var ans3Query = (from dep in departments
//                 join emp in employees
//                 on dep.Id equals emp.DepartmentId
//                 into empList
//                 select new
//                 {
//                     empListCount = empList.Count()
//                 }).Max(x => x.empListCount);

/// Question 4 : Retrieve all employees who have a salary above a certain threshold

//var ans4 = from emp in employees
//           where emp.AnnualSalary > 25000
//           select emp;

/// Question5 : Get the average salary for each Department

//var ans5 = (from dep in departments
//           join emp in employees
//           on dep.Id equals emp.DepartmentId
//           into empList
//           select new
//           {
//               DepartmentName = dep.LongName,
//               AverageSalary = empList.Average(x => x.AnnualSalary)
//           }).ToList();

//var ans5QuerySyntax = departments.GroupJoin(employees, d => d.Id, e => e.DepartmentId, (d, empList) =>
//    new
//    {
//        d.LongName,
//        empListCount = empList.Average(x => x.AnnualSalary)
//    }).ToList();

/// Question 6: Find the employees who have the same last name as their manager

//var ans6 = employees.Join(managers, e => e.LastName, m => m.LastName, (e,m) => (e)).ToList();

/// Question 7: Retrieve the top 5 highest-paid employees

//var ans7 = employees.OrderByDescending(x => x.AnnualSalary).Take(5).ToList();

/// Question 8: Get the departments with no employees:

//var ans8 = departments.GroupJoin(employees, d => d.Id, e => e.DepartmentId, (d, e) =>
//             new
//             {
//                 DepartmentName = d.LongName,
//                 EmployeeCount = e.Count()
//             }).Where(x => x.EmployeeCount == 0).ToList();

//var ans8Query = from dep in departments
//                join emp in employees
//                on dep.Id equals emp.DepartmentId
//                into empList where empList.Count() == 0
//                select new
//                {
//                    DepartmentName = dep.LongName,
//                    EmployeeCount = empList.Count()
//                };

/// Question 9 : Find the employees who have been with the company for more than 5 years

//var ans9 = employees.Where(x => DateTime.Now.Year - x.HireDate.Year > 5).ToList();

/// Question 10 : Retrieve the employees who have the same first name as any employee in another department
/*
/// Using Method Syntax
var employeesWithSameFirstNameInDifferentDepartment = employees
    .Where(e => employees.Any(emp => emp.Id != e.Id && emp.FirstName == e.FirstName && emp.DepartmentId != e.DepartmentId))
    .ToList();

/// Solving Using Any Method with Query Syntax
var result = (from emp in employees
              where employees
              .Any(emp2 => emp2.Id != emp.Id && emp2.FirstName == emp.FirstName && emp2.DepartmentId != emp.DepartmentId)
              select emp).ToList();

/// Solving Using Join
var result2 = (from emp in employees
              join emp2 in employees on emp.FirstName equals emp2.FirstName
              where emp.Id != emp2.Id && emp.DepartmentId != emp2.DepartmentId
              select emp2).ToList();
*/
#endregion


///Question 11 : From the IMDb dataset, print the title and rating of 
///those movies which have a genre starting from 'C' released in 2014 with a budget higher than 4 Crore.
//var context = new ApplicationDbContext();
//var earning = context.earning.ToList();
//var genre = context.genre.ToList();
//var imdb = context.IMDB.ToList();


//var result = (from g in genre
//              join i in imdb on g.Movie_Id equals i.Movie_id
//              where g.genres.StartsWith("C") && i.Title.Contains("2014") && i.Budget > 40000000
//              select new { i.Title, i.Rating }).ToList();


//var result = genre
//    .Join(imdb, g => g.Movie_Id, i => i.Movie_id, (g, i) => new { g, i })
//    .Where(x => x.g.genres.StartsWith("C") && x.i.Title.Contains("2014") && x.i.Budget > 40000000)
//    .Select(x => new { x.i.Title, x.i.Rating })
//    .ToList();


///SELECT DISTINCT Salary FROM Employee ORDER BY Salary DESC LIMIT 1 OFFSET 1;

//var ans12 = employees.OrderByDescending(x => x.AnnualSalary)
//                            .Distinct()
//                            .Skip(1)
//                            .Select(x => x.AnnualSalary)
//                            .FirstOrDefault();


///Question 12 : Find the employees who have the same manager

//var ans12 = managers.GroupJoin(employees, m => m.Id, e => e.ManagerId, (m,e) => (m,e)).ToList();

//var ans12v2 = employees.GroupBy(e => e.ManagerId).ToList();

//var ans12query = from man in employees
//                 group man by man.ManagerId into empGroup
//                 select empGroup;

//Question 13 : Retrieve the employees who have the highest salary in each department

//var ans13 = employees.GroupBy(x => x.DepartmentId).Select(x => x.Max(x => x.AnnualSalary))
//.ToList();

//var ans13query = from dep in departments
//                 join emp in employees
//                 on dep.Id equals emp.DepartmentId
//                 into empList
//                 select new
//                 {
//                     DepartmentName = dep.LongName,
//                     MaxSalary = empList.Max(x => x.AnnualSalary)
//                 };

//var courses =
//    new List<(int id, string name, double price)>();

//courses.Add((1, "C#", 8000));
//courses.Add((2, "Asp.net", 30000));

//var students =
//    new List<(int id, string name, string address, int courseId)>();
//students.Add((3, "Jalaluddin", "Mirpur", 2));
//students.Add((4, "Hasan", "Moghbazar", 1));
//students.Add((4, "Hasan", "Moghbazar", 2));


//var details = from c in courses
//    join s in students on c.id equals s.courseId
//    group new { s, c } by s.name into g
//    select (StudentName: g.Key, CoursesName: g.Select(x => x.c));


//foreach (var detail in details)
//{
//    Console.WriteLine($"Student Name : {detail.StudentName} ");
//    Console.Write("Enrolled Courses : ");
//    int temp = 0;
//    foreach (var courseName in detail.CoursesName)
//    {
//        if (temp > 0)
//        {
//            Console.Write(", ");
//        }
//        Console.Write(courseName.name);
//        temp++;
//    }
//    Console.WriteLine();
//    Console.WriteLine();
//}

/// question 15.Retrieve the employees who have the same manager and are in the same department

// var result = from emp in employees
//              join emp2 in employees
//              on emp.ManagerId equals emp2.ManagerId
//              where emp.Id != emp2.Id && emp.DepartmentId == emp2.DepartmentId
//              select emp;

    /*
     Retrieve the total number of employees, the average salary, and the highest salary for each department,
      including departments without employees.*/

    // var result = (from dep in departments
    //     join employee in employees on dep.Id equals employee.DepartmentId
    //         into empList
    //     select new
    //     {
    //         DepartmentName = dep.LongName,
    //         TotalEmployees = empList.Count(),
    //         AvgSalary = empList.Average(x => x.AnnualSalary),
    //         MaxSalary = empList.Max(x => x.AnnualSalary)
    //     }).ToList();

/*
    Find the departments where the average salary of employees 
    is higher than the average salary across all departments.
*/
        // var result2 = from d in employees
        // group d by d.DepartmentId
        // into empGroup
        // select new
        // {
        //     depId = empGroup.Key,
        //     Avg = empGroup.Average(x => x.AnnualSalary) > employees.Average(x => x.AnnualSalary)
        // };
/*
    Identify departments where the number of employees supervised by a manager exceeds a certain threshold.
*/
        // var threshold = 2;
        // var ans = from emp in employees
        //     join emp2 in employees on emp.ManagerId equals emp2.ManagerId
        //     where emp.Id != emp2.Id && emp.DepartmentId == emp2.DepartmentId
        //     select emp;
            
            
/*
    List the names of employees who earn more than their department's average salary.
*/
        // var ans = from emp in employees
        //     group emp by emp.DepartmentId
        //     into empGroup
        //     let avg = empGroup.Average(x => x.AnnualSalary)
        //     let maxSalary = empGroup.Select(x => x.AnnualSalary)
        //     from mx in maxSalary
        //     where mx > avg
        //     select new { Salary = mx, empGroup.Key };
/*
    Find the departments with the highest and lowest average salary among their employees.
*/
        // var ans = (from dep in departments
        //     join emp in employees on dep.Id equals emp.DepartmentId
        //         into empList
        //     let avgSalary = empList.Average(x => x.AnnualSalary)
        //     orderby avgSalary descending 
        //     select new
        //     {
        //         DepartmentName = dep.LongName,
        //         avgSalary,
        //         empList
        //     }).ToList();
        // var first = ans.Take(1);
        // var last = ans.TakeLast(1);

/*   List the departments along with the names of the managers and the total number of employees supervised by each manager. */

        // var ans = from dept in departments
        //     join emp in employees on dept.Id equals emp.DepartmentId into empList
        //     select new
        //     {
        //         DepartmentName = dept.LongName,
        //         ManagerList = (from empl in empList select empl.ManagerId).Distinct(),
        //         ManagerCountEmployee = from empl in empList group empl by empl.ManagerId
        //     };
        //
        // var result = from dept in departments
        //     join emp in employees on dept.Id equals emp.DepartmentId into empGroup
        //     select new
        //     {
        //         Managers = empGroup.Select(x => x.ManagerId).Distinct()
        //     };

        // var calls = Data.GetCalls();
        //
        // var result = (from call in calls
        //     group call by new { person1 = Math.Min(call.from_id, call.to_id), person2 = Math.Max(call.from_id, call.to_id) } 
        //     into groupedCalls
        //     select new
        //     {
        //         person1 = groupedCalls.Key.person1,
        //         person2 = groupedCalls.Key.person2,
        //         call_count = groupedCalls.Count(),
        //         total_duration = groupedCalls.Sum(c => c.duration)
        //     }).ToList();

        var weathers = Data.GetWeathers();
        
        var result = (from current in weathers
            join previous in weathers on current.RecordDate.AddDays(-1) equals previous.RecordDate
            where current.Temperature > previous.Temperature
            select new
            {
                id = current.Id,
                recordDate = current.RecordDate,
                Temperature = current.Temperature
            }).ToList();
    
Console.WriteLine();
Console.WriteLine();