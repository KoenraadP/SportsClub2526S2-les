using Microsoft.AspNetCore.Mvc;
using SportsClub.WebApp.Data;
using SportsClub.WebApp.Models;

namespace SportsClub.WebApp.Controllers
{
    // DI - dependency injection
    // we geven de class die we willen gebruiken door als parameter van deze class
    public class MembersController(ApplicationDbContext db) : Controller
    {
        // deze methode zorgt er voor dat /Members/Index werkt
        public IActionResult Index()
        {
            // alle members ophalen uit databank (db) en in list vorm opslaan
            List<Member> members = db.Members.ToList();
            // lijst van members doorsturen naar index pagina (view)
            return View(members);
        }
    }
}
