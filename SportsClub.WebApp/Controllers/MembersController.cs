using Microsoft.AspNetCore.Mvc;
using SportsClub.Data;
using SportsClub.Models;
using SportsClub.Services;

namespace SportsClub.WebApp.Controllers
{
    // DI - dependency injection
    // we geven de class die we willen gebruiken door als parameter van deze class
    public class MembersController(MemberService memberService) : Controller
    {
        // deze methode zorgt er voor dat /Members/Index werkt
        public IActionResult Index()
        {
            // alle members ophalen uit databank via methode uit service
            List<Member> members = memberService.ReadAll();
            // lijst van members doorsturen naar index pagina (view)
            return View(members);
        }

        // create methode om de create pagina/view te genereren
        public IActionResult Create()
        {
            return View();
        }

        // tweede create methode aanduiden als de POST methode
        // hierdoor wordt de formulier data van de Create view 
        // automatisch naar deze methode doorgestuurd
        [HttpPost]
        public IActionResult Create(Member m)
        {
            // create methode uit service gebruiken
            // om member aan db toe te voegen
            memberService.Create(m);
            // terugkeren naar index
            return RedirectToAction("Index");
        }
    }
}
