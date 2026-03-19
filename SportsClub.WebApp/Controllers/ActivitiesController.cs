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
            Activity? a = activityService.Read(id);

            if (a == null)
            {
                TempData["ErrorMessage"] = "Geen activiteit gevonden met id " + id;
                return RedirectToAction("Index");
            }

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

                activityService.Create(a);
                return RedirectToAction("Index");
            }

            return View(a);
        }
    }
}
