using Microsoft.AspNetCore.Mvc;
using SportsClub.Data;
using SportsClub.Models;
using SportsClub.Services;

namespace SportsClub.WebApp.Controllers
{
    public class ActivitiesController(ActivityService activityService) : Controller
    {
        public IActionResult Index()
        {
            List<Activity> activities = activityService.ReadAll();
            return View(activities);
        }

        public IActionResult Details(int id)
        {
            // read methode uit service gebruiken om member te zoeken in db
            Activity? a = activityService.Read(id);

            // controleren of m 'null' is (dus als er geen record met deze id gevonden werd)
            if (a == null)
            {
                // boodschap om door te sturen naar volgende pagina
                // een TempData object blijft in het geheugen van de app tot het één keer gelezen wordt
                // daarna verdwijnt het weer automatisch
                TempData["ErrorMessage"] = "Geen activiteit gevonden met id " + id;
                // terugkeren naar index pagina
                return RedirectToAction("Index");
            }

            // pagina tonen met info over member
            return View(a);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Activity a)
        {
            if (ModelState.IsValid)
            {
                if (activityService.NameExists(a.ActivityName))
                {
                    ModelState.AddModelError("ActivityName", "Naam bestaat al!");
                    return View(a);
                }
                // create methode uit service gebruiken
                // om member aan db toe te voegen
                activityService.Create(a);
                // terugkeren naar index
                return RedirectToAction("Index");
            }

            return View(a);
        }
    }
}
