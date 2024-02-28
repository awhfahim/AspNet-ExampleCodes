// See https://aka.ms/new-console-template for more information
using Assignment3;
using Assignment3.TestCase1;

Console.WriteLine("Hello, World!");

var course = new Course()
{
    Id = Guid.Parse("9294745A-09B6-4E9E-9E6B-7913E7D51F6F"),
    Name = "Asp.Net",
    CreateDate = DateTime.Now,
    Fees = 50000,
    Topic = new List<Topic> 
    { 
        new Topic { Id = Guid.NewGuid(), Title = "Rest Api", Description = "lasfa asfa sdfAFD"}, 
        new Topic { Id = Guid.NewGuid(), Title = "Reflection", Description = "bubt af asf" } 
    },
    Teacher = new Instructor 
    { 
        Id = Guid.NewGuid(), 
        Name = "Imon Chowdhury", 
        Email = "info@chi.com", 
        PresentAddress = new Address { Id = Guid.NewGuid(), Street = "Mirpur Road", City = "Bandladesh", Country = "Bangladesh" },
        PermanentAddress = new Address 
        { 
            Id = Guid.NewGuid(), 
            Street = "Airport Road", 
            City = "Bandladesh", 
            Country = "Bangladesh",
            Areas = new List<Area>
            {
                new Area{ Id = Guid.NewGuid(), Name = "Nichu Colony", IsActive = true, AreaType = AreaType.Upozila },
                new Area{ Id = Guid.NewGuid(), Name = "Chowdhury Para", IsActive = true, AreaType = AreaType.Division }
            }
        },

        PhoneNumbers = new List<Phone> 
        { 
            new Phone { Id = Guid.NewGuid(),Number = "1581899069", CountryCode="+880",Extension = "Bd"},
            new Phone { Id = Guid.NewGuid(),Number = "1581899069", CountryCode="+880",Extension = "Bd"}
        }
    }
};

var courseUpdate = new Course()
{
    Id = Guid.Parse("336a1367-1f61-4bac-9040-41e8b2a552f5"),
    Name = "Update Test 2",
    CreateDate = DateTime.Now,
    Fees = 50000,
    Topic = new List<Topic>
    {
        new Topic { Id = Guid.Parse("2cba494e-7994-4c29-a8b2-d93e10ac22db"), Title = "Update Test", Description = "pakistan bangladesh"},
        new Topic { Id = Guid.Parse("91761608-38a1-441f-8490-c07162ddd0ff"), Title = "Update Test2", Description = "Saidpur cumilla" }
    },
    Teacher = new Instructor
    {
        Id = Guid.Parse("b13e0133-311f-4046-9ceb-182b591c4b80"),
        Name = "Sadman Sakib",
        Email = "sadman@devskill.com",
        PresentAddress = new Address { Id = Guid.Parse("7204f9ed-d717-4911-8695-b987886c2937"), Street = "Mirpur Road", City = "Saidpur", Country = "Bangladesh" },
        PermanentAddress = new Address { Id = Guid.Parse("4e3cc850-f3ba-408b-9198-bffdb714b9ef"), Street = "Nichu Colony Road", City = "Saidpur", Country = "Bangladesh" },
        PhoneNumbers = new List<Phone>
        {
            new Phone { Id = Guid.Parse("49f2754d-f749-4cf0-81c3-228539c88455"),Number = "01843746747", CountryCode="+880",Extension = "Bd"},
            new Phone { Id = Guid.Parse("83f32ae7-7045-427b-8192-4170b930a891"),Number = "01832788351", CountryCode="+880",Extension = "Bd"}
        }
    }
};

var courseDelete = new Course()
{
    Id = Guid.Parse("9294745A-09B6-4E9E-9E6B-7913E7D51F6F")
};

var item = new Item()
{
    Id = Guid.NewGuid(),
    Name = "Book",
    Description = "Ar Rahikul Makhtum Sirat Book by safiur rahman mubarakpuri",
    PhotoUrl = "www.google.com/photos/rahikulmakhtum",
    Colors = new List<Color>
    {
        new Color {Id = Guid.NewGuid(), Name = "Red", Code = "#342324"},
        new Color {Id = Guid.NewGuid(), Name = "Blue", Code = "#0034434"},
    },
    Feedbacks = new List<Feedback>
    {
        new Feedback 
        {
            Id = Guid.NewGuid(),
            Comment = "Best Sirat Book I have Ever Read", 
            Rating = 5.5,
            FeedbackGiver = new User
            {
                Id =  Guid.NewGuid(), 
                Name = "Abu Wabaidar Hasan Fahim", 
                Email = "fahimhasan314@gmail.com"
            }
        },

        new Feedback 
        {
            Id = Guid.NewGuid(),
            Comment = "English", 
            Rating = 4,
            FeedbackGiver = new User
            {
                Id =  Guid.NewGuid(), 
                Name = "Fahim", 
                Email = "winner3763@gmail.com"
            }
        }
    }
};

var itemUpdate = new Item()
{
    Id = Guid.Parse("af1c6fef-158d-421e-8b9b-262adc5234a2"),
    Name = "Keyboard",
    Description = "Logitech 512",
    PhotoUrl = "www.google.com/photos/rahikulmakhtum",
    Colors = new List<Color>
    {
        new Color {Id = Guid.NewGuid(), Name = "Red", Code = "#342324"},
        new Color {Id = Guid.NewGuid(), Name = "Blue", Code = "#0034434"},
    },
    Feedbacks = new List<Feedback>
    {
        new Feedback
        {
            Id = Guid.NewGuid(),
            Comment = "keyboard",
            Rating = 5.5,
            FeedbackGiver = new User
            {
                Id =  Guid.NewGuid(),
                Name = "Abu Wabaidar Hasan Fahim",
                Email = "fahimhasan314@gmail.com"
            }
        },

        new Feedback
        {
            Id = Guid.NewGuid(),
            Comment = "ald f",
            Rating = 4,
            FeedbackGiver = new User
            {
                Id =  Guid.NewGuid(),
                Name = "Fahadfasfim",
                Email = "waf adfl.com"
            }
        }
    }
};

var vendor = new Vendor() { Id = Guid.NewGuid(), Enlisted = true, Name = "Aws" };

var product = new Product 
{ 
    Id = Guid.NewGuid(),
    Name = "Camera",
    Price = 345434.34,
    Colors = new List<Color>
    {
        new Color { Id = Guid.NewGuid(), Name = "Magenda", Code = "#5434343"}, 
        new Color { Id = Guid.NewGuid(), Code = "#24235", Name = "Yellow"} 
    },
    Feedbacks = new List<Feedback>
    {
        new Feedback 
        { 
            Id = Guid.NewGuid(),
            Comment = "This Camera is Awesome", 
            Rating = 4.3,
            FeedbackGiver = new User {Id =  Guid.NewGuid(), Name = "Abu", Email = "md491484@gmail.com"}
        },
        
        new Feedback 
        { 
            Id = Guid.NewGuid(),
            Comment = "Loving it", 
            Rating = 4.5,
            FeedbackGiver = new User {Id =  Guid.NewGuid(), Name = "Hasan", Email = "hasan112@gmail.com"}
        },

    }
};

var updateProduct = new Product 
{ 
    Id = Guid.Parse("e4aebdec-2e3f-4c13-9f10-e49e4d3c9df9"),
    Name = "Mobile",
    Price = 56500.51,
    Colors = new List<Color>
    {
        new Color { Id = Guid.Parse("b911aaa2-3a3e-46b9-9406-41ece02592bd"), Name = "Black", Code = "#5434343"}, 
        new Color { Id = Guid.NewGuid(), Code = "#24235", Name = "Orange"} 
    },
    Feedbacks = new List<Feedback>
    {
        new Feedback 
        { 
            Id = Guid.NewGuid(),
            Comment = "This Camera is Awesome", 
            Rating = 4.3,
            FeedbackGiver = new User {Id =  Guid.NewGuid(), Name = "Abu", Email = "md491484@gmail.com"}
        },
        
        new Feedback 
        { 
            Id = Guid.NewGuid(),
            Comment = "Loving it", 
            Rating = 4.5,
            FeedbackGiver = new User {Id =  Guid.NewGuid(), Name = "Hasan", Email = "hasan112@gmail.com"}
        },

    }
};

var deleteItem = new Item { Id = Guid.Parse("79e2ee4d-9689-4d5d-ae7f-727bba3bf5d6") };

var deleteCourse = new Course { Id = Guid.Parse("ac22f575-a4bd-4c30-82d3-9c2041fd7378") };


var orm = new MyORM<Guid, Item>();
orm.Insert(item);
//var data = orm.GetAll();
//orm.Update(itemUpdate);
//orm.Delete(deleteItem);
//orm.Delete(Guid.Parse("e50ddc16-f9b2-43b4-a662-32fb56c7d7b9"));
//var res = orm.GetById(Guid.Parse("d9e0df3c-2243-42a1-92ba-41fd9b370a04"));
Console.WriteLine("fahim");