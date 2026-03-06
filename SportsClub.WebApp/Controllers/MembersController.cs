using Microsoft.AspNetCore.Mvc;
using SportsClub.WebApp.Models;

namespace SportsClub.WebApp.Controllers
{
    public class MembersController : Controller
    {
        // deze methode zorgt er voor dat /Members/Index werkt
        public IActionResult Index()
        {
            // enkele test members aanmaken
            Member m1 = new Member("Jef", "Piraat");
            Member m2 = new Member("Kabouter", "Paulus");
            // lijst maken voor members
            List<Member> members = new();
            // test members toevoegen aan lijst
            members.Add(m1);
            members.Add(m2);
            // lijst van members doorsturen naar index pagina (view)
            return View(members);
        }
    }
}
