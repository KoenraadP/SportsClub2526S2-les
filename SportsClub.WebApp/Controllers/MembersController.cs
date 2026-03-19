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
            // controleren of Member volledig correct is qua data
            if (ModelState.IsValid)
            {
                // controleren op e-mail duplicates
                if (memberService.EmailExists(m.Email))
                {
                    // als het e-mail adres al in de db zit, custom boodschap tonen
                    ModelState.AddModelError("Email", "E-mail adres wordt al gebruikt!");
                    // opnieuw create pagina tonen met data die al ingevuld werd
                    return View(m);
                }

                // create methode uit service gebruiken
                // om member aan db toe te voegen
                memberService.Create(m);
                // terugkeren naar index
                return RedirectToAction("Index");
            }
            
            // als ModelState niet valid is --> dus als een property niet correct ingevuld werd
            // m wordt ook doorgegeven om de zaken die we al ingevuld hadden te behouden
            return View(m);
        }
    }
}
