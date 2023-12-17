using Autofac;
using Microsoft.AspNetCore.Mvc;
using Practice1.Web.Areas.Hospital.Models;

namespace Practice1.Web.Areas.Hospital.Controllers
{
    [Area("Hospital")]
    public class PatientController : Controller
    {
        private readonly ILifetimeScope scope;
        private readonly ILogger<PatientController> logger;

        public PatientController(ILifetimeScope _scope, ILogger<PatientController> _logger)
            => (scope,logger) = (_scope, _logger);
        public IActionResult AddPatient()
        {
            var model = scope.Resolve<AddPatientModel>();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPatient(AddPatientModel model)
        {
            if(ModelState.IsValid)
            {
                model.Resolve(scope);
                await model.AddPatientAsync(model);
                return RedirectToAction("AddPatient");
            }
            return View();
        }
    }
}
