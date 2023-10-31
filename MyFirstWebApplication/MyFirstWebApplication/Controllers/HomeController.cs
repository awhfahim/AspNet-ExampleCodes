using Microsoft.AspNetCore.Mvc;
using MyFirstWebApplication.Models;
using System.Diagnostics;

namespace MyFirstWebApplication.Controllers
{
    public class HomeController : Controller, IEmailUtility
    {
        private readonly ILogger<HomeController> _logger;
        private  IEmailUtility _emailUtility;

        public HomeController(ILogger<HomeController> logger, IEmailUtility emailUtility)
        {
            _logger = logger;
            _emailUtility = emailUtility;
        }

        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "a"});
            students.Add(new Student() { Id = 12, Name = "fa"});
            students.Add(new Student() { Id = 13, Name = "av"});
            ViewBag.Students = students;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void SendEmail(string receiverEmailAddress, string subject, string body)
        {
            throw new NotImplementedException();
        }

        public void ForwardEmail(string receiverEmailAddress, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}