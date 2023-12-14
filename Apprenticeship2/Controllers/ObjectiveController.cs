using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apprenticeship2.Controllers
{
    public class ObjectiveController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
