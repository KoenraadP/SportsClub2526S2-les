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

        public IActionResult Edit(int id)
        {
            Activity? a = activityService.Read(id);

            if (a == null)
            {
                TempData["ErrorMessage"] = "Geen activiteit gevonden met id " + id;
                return RedirectToAction("Index");
            }

            return View(a);
        }

        [HttpPost]
        public IActionResult Edit(Activity updatedActivity)
        {
            if (ModelState.IsValid)
            {
                if (activityService.NameExists(updatedActivity.ActivityName,
                                              updatedActivity.ActivityId))
                {
                    ModelState.AddModelError("Activityname", "Naam activiteit wordt al gebruikt!");
                    return View(updatedActivity);
                }

                bool updateSuccessful = activityService.Update(updatedActivity);

                if (updateSuccessful)
                {
                    TempData["SuccessMessage"] = "Data voor "
                                                + updatedActivity.ActivityName + " "
                                                + "aangepast";
                }
                else
                {
                    TempData["ErrorMessage"] = "Update niet gelukt";
                }

                return RedirectToAction("Index");
            }

            return View(updatedActivity);
        }

        public IActionResult Delete(int id)
        {
            Activity? a = activityService.Read(id);

            if (a == null)
            {
                TempData["ErrorMessage"] = "Geen activiteit gevonden met id " + id;
                return RedirectToAction("Index");
            }

            return View(a);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            bool deleteSuccessful = activityService.Delete(id);

            if (deleteSuccessful)
            {
                TempData["SuccessMessage"] = "Activiteit correct verwijderd";
            }
            else
            {
                TempData["ErrorMessage"] = "Probleem met verwijderen";
            }

            return RedirectToAction("Index");
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
