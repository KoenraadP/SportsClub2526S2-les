using Microsoft.AspNetCore.Mvc;

namespace SportsClub.WebApp.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
