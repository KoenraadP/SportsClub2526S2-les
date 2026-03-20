using SportsClub.Data;
using SportsClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Services
{
    public class ActivityService(ApplicationDbContext db)
    {
        public List<Activity> ReadAll()
        {
            List<Activity> activities = db.Activities.ToList();
            return activities;
        }

        public Activity? Read(int id)
        {
            // .Find() gebruikt een primary key parameter
            // om één specifieke record in de db te zoeken
            Activity? a = db.Activities.Find(id);
            return a;
        }

        public void Create(Activity a)
        {
            // toevoegen 'klaar zetten'
            db.Activities.Add(a);
            // toevoegen effectief uitvoeren
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            Activity? a = db.Activities.Find(id);

            if (a == null) return false;

            db.Activities.Remove(a);
            db.SaveChanges();
            return true;
        }
        public bool Update(Activity updatedActivity)
        {
            Activity? oldActivity = db.Activities.Find(updatedActivity.ActivityId);
            if (oldActivity == null) return false;

            oldActivity.ActivityName = updatedActivity.ActivityName;
            oldActivity.MaxParticipants = updatedActivity.MaxParticipants;

            db.SaveChanges();
            return true;
        }

        #region validationmethods

        // methode om te controleren of een e-mail adres al aanwezig is in db
        public bool NameExists(string activityname, int? id = null)
        {
            if (db.Activities.Any(a => a.ActivityName == activityname
                                    && a.ActivityId != id)) return true;
            return false;
        }

        #endregion
    }
}
