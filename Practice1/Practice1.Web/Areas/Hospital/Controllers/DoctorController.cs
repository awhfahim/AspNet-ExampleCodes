using Autofac;
using Microsoft.AspNetCore.Mvc;
using Practice1.Web.Areas.Hospital.Models;

namespace Practice1.Web.Areas.Hospital.Controllers
{
    [Area("Hospital")]
    public class DoctorController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<DoctorController> _logger;
        public DoctorController(ILifetimeScope scope, ILogger<DoctorController> logger)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult AddDoctor()
        {
            var model = _scope.Resolve<AddDoctorModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDoctor(AddDoctorModel model)
        {
            if(ModelState.IsValid)
            {
                model.Resolve(_scope);
                await model.AddDoctorAsync(model);
                return RedirectToAction("AddDoctor");
            }
            return View(model);
        }
    }
}
