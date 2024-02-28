// See https://aka.ms/new-console-template for more information
using demoAssignment3;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var ins = new Instructor()
{
    Age = 1,
    Description = "dffa",
    Name = "Test",
    PresentAddress = new Address() { City = "fd", Country = "fadf", PostalCode = "343", StreetNo = "3434"},
    ParmanentAddress = new Address() { City = "fdsf sdfd", Country = "fa3tretregeyerytdf", PostalCode = "3vsd443f", StreetNo = "3434" }

};

var context = new ApplicationDb();
//var result = context.Instructors.Add(ins);
//context.SaveChanges();

var instructor = context.Instructors.Include(x => x.PresentAddress).Include(x => x.ParmanentAddress).ToList();

Console.WriteLine();
