using SportsClub.Data;
using SportsClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Services
{
    // moet public staan, anders kan deze niet gebruikt worden in WebApp
    // ApplicationDbContext is de link naar de databank
    public class MemberService(ApplicationDbContext db)
    {

        #region CRUD

        // deze class moet alle methodes bevatten
        // voor CRUD operations
        // Create
        // Read
        // Update
        // Delete

        // methode om alle members op te halen uit db
        public List<Member> ReadAll()
        {
            List<Member> members = db.Members.ToList();
            return members;
        }

        // methode om één member toe te voegen aan db
        // er komt via de controller al een nieuw 'Member' binnen
        // met voornaam en achternaam
        public void Create(Member m)
        {
            // toevoegen 'klaar zetten'
            db.Members.Add(m);
            // toevoegen effectief uitvoeren
            db.SaveChanges();
        }

        #endregion

        #region validationmethods

        // methode om te controleren of een e-mail adres al aanwezig is in db
        public bool EmailExists(string email)
        {
            // alle member records checken en e-mail vergelijken
            if (db.Members.Any(m => m.Email == email)) return true;
            // e-mail nog niet in db? alles ok dus 'false'
            return false;
        }

        #endregion
    }
}
