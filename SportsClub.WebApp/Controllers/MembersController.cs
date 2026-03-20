using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
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

        // methode voor de details pagina/view
        public IActionResult Details(int id)
        {
            // read methode uit service gebruiken om member te zoeken in db
            Member? m = memberService.Read(id);

            // controleren of m 'null' is (dus als er geen record met deze id gevonden werd)
            if (m == null)
            {
                // boodschap om door te sturen naar volgende pagina
                // een TempData object blijft in het geheugen van de app tot het één keer gelezen wordt
                // daarna verdwijnt het weer automatisch
                TempData["ErrorMessage"] = "Geen lid gevonden met id " + id;
                // terugkeren naar index pagina
                return RedirectToAction("Index");
            }

            // pagina tonen met info over member
            return View(m);
        }

        // methode om naar Edit view te gaan
        // zelfde code als Details
        public IActionResult Edit(int id)
        {
            // read methode uit service gebruiken om member te zoeken in db
            Member? m = memberService.Read(id);

            // controleren of m 'null' is (dus als er geen record met deze id gevonden werd)
            if (m == null)
            {
                // boodschap om door te sturen naar volgende pagina
                // een TempData object blijft in het geheugen van de app tot het één keer gelezen wordt
                // daarna verdwijnt het weer automatisch
                TempData["ErrorMessage"] = "Geen lid gevonden met id " + id;
                // terugkeren naar index pagina
                return RedirectToAction("Index");
            }

            // pagina tonen met info over member
            return View(m);
        }

        // POST methode voor edit
        [HttpPost]
        public IActionResult Edit(Member updatedMember)
        {
            // controleren of Member volledig correct is qua data
            if (ModelState.IsValid)
            {
                // controleren op e-mail duplicates
                if (memberService.EmailExists(updatedMember.Email,
                                              updatedMember.MemberId))
                {
                    // als het e-mail adres al in de db zit, custom boodschap tonen
                    ModelState.AddModelError("Email", "E-mail adres wordt al gebruikt!");
                    // opnieuw edit pagina tonen met data die al ingevuld werd
                    return View(updatedMember);
                }

                // update methode uit service gebruiken
                // om member in db aan te passen
                bool updateSuccessful = memberService.Update(updatedMember);

                if (updateSuccessful)
                {
                    // boodschap als het gelukt is
                    TempData["SuccessMessage"] = "Data voor "
                                                + updatedMember.FirstName + " "
                                                + updatedMember.LastName + " "
                                                + "aangepast";
                }
                else
                {
                    // boodschap als er iets fout gelopen is
                    TempData["ErrorMessage"] = "Update niet gelukt";
                }

                // terugkeren naar index
                return RedirectToAction("Index");
            }

            // als ModelState niet valid is --> dus als een property niet correct ingevuld werd
            // m wordt ook doorgegeven om de zaken die we al ingevuld hadden te behouden
            return View(updatedMember);
        }

        // methode om naar Delete view te gaan
        // zelfde code als Details
        public IActionResult Delete(int id)
        {
            // read methode uit service gebruiken om member te zoeken in db
            Member? m = memberService.Read(id);

            // controleren of m 'null' is (dus als er geen record met deze id gevonden werd)
            if (m == null)
            {
                // boodschap om door te sturen naar volgende pagina
                // een TempData object blijft in het geheugen van de app tot het één keer gelezen wordt
                // daarna verdwijnt het weer automatisch
                TempData["ErrorMessage"] = "Geen lid gevonden met id " + id;
                // terugkeren naar index pagina
                return RedirectToAction("Index");
            }

            // pagina tonen met info over member
            return View(m);
        }

        // POST methode voor Delete
        // methode MOET een andere naam krijgen omdat met dezelfde parameter gewerkt wordt
        // omdat deze wel moet 'gezien' worden als Delete door de view, extra attribute actionname
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // delete uit service uitvoeren en true/false opslaan
            bool deleteSuccessful = memberService.Delete(id);

            // als delete gelukt is (true)
            if (deleteSuccessful)
            {
                TempData["SuccessMessage"] = "Lid correct verwijderd";
            }
            // als delete niet gelukt is (false)
            else
            {
                TempData["ErrorMessage"] = "Probleem met verwijderen";
            }

            // terug naar index na delete
            return RedirectToAction("Index");
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
