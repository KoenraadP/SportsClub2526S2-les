using Microsoft.AspNetCore.Mvc;
using SportsClub.WebApp.Data;
using SportsClub.WebApp.Models;

namespace SportsClub.WebApp.Controllers
{
    public class ActivitiesController(ApplicationDbContext db) : Controller
    {
        public IActionResult Index()
        {
            List<Activity> activities = db.Activities.ToList();
            return View(activities);
        }
    }
}
