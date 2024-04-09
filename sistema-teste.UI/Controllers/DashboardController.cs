using Microsoft.AspNetCore.Mvc;

namespace sistema_teste.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult BemVindo()
        {
            return View();
        }
    }
}
