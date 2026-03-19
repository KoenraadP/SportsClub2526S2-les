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

        public void Create(Activity a)
        {
            // toevoegen 'klaar zetten'
            db.Activities.Add(a);
            // toevoegen effectief uitvoeren
            db.SaveChanges();
        }
    }
}
