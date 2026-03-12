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
    }
}
