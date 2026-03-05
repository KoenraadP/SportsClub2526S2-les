using Microsoft.AspNetCore.Mvc;

namespace SportsClub.WebApp.Controllers
{
    public class CafetariaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
