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
        public IActionResult Create(Activity a, IFormFile? logo)
        {
            if (ModelState.IsValid)
            {
                if (activityService.NameExists(a.ActivityName))
                {
                    ModelState.AddModelError("ActivityName", "Naam bestaat al!");
                    return View(a);
                }

                if (logo != null)
                {
                    // toegelaten extensies
                    string[] allowedExtensions = [".jpg", ".jpeg", ".png"];
                    // extensie van picture in variabele opslaan
                    // als ik bvb idris.jpg kies, zal deze variabele ".jpg" bevatten
                    string extension = Path.GetExtension(logo.FileName).ToLowerInvariant();

                    // controle op extensie --> als de extension NIET in de array zit
                    if (!allowedExtensions.Contains(extension))
                    {
                        // specifieke foutmelding bij picture
                        ModelState.AddModelError("LogoName", "Verkeerd type afbeelding!");
                        // create pagina tonen met errors
                        return View(a);
                    }

                    // pad naar map instellen waar foto moet opgeslagen worden
                    string imageFolder = Path.Combine(Directory.GetCurrentDirectory(),
                                            "wwwroot/images/activities");
                    // nieuwe naam maken voor afbeelding bestand
                    string pictureName = Guid.NewGuid() + extension;
                    // variabele voor VOLLEDIGE pad inclusief de afbeelding naam
                    string pictureFullPath = Path.Combine(imageFolder, pictureName);

                    using (var stream = new FileStream(pictureFullPath,
                                                        FileMode.Create))
                    {
                        logo.CopyTo(stream);
                    }

                    // picturename ook toevoegen aan member voor databank
                    a.LogoName = pictureName;
                }

                activityService.Create(a);
                return RedirectToAction("Index");
            }

            return View(a);
        }
    }
}
