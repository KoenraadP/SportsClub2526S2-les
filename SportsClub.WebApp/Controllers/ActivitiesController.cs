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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Activity a)
        {
            // create methode uit service gebruiken
            // om member aan db toe te voegen
            activityService.Create(a);
            // terugkeren naar index
            return RedirectToAction("Index");
        }
    }
}
