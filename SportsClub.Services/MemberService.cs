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

        // methode om één member op te halen uit db
        public Member? Read(int id)
        {
            // .Find() gebruikt een primary key parameter
            // om één specifieke record in de db te zoeken
            Member? m = db.Members.Find(id);
            return m;
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

        // methode om member uit db te verwijderen
        public bool Delete(int id)
        {
            // member opzoeken in db, optie voor null voorzien
            Member? m = db.Members.Find(id);

            // als member niet kon gevonden worden, dan false als resultaat van methode
            if (m == null) return false;

            // delete klaar zetten
            db.Members.Remove(m);
            // delete effectief uitvoeren
            db.SaveChanges();
            // alles gelukt? resultaat is true
            return true;
        }

        // methode om member aan te passen in db
        // de member die binnen komt als parameter heeft de nieuwe data
        public bool Update(Member updatedMember)
        {
            // huidige record opzoeken in db via id van updatedMember
            Member? oldMember = db.Members.Find(updatedMember.MemberId);
            // probleem met member opzoeken --> resultaat false
            if (oldMember == null) return false;

            // update klaar zetten --> alle waarden van de oude record vervangen
            // met waarden in updatedMember
            // variant met db.Members.Update() is ook mogelijk
            oldMember.FirstName = updatedMember.FirstName;
            oldMember.LastName = updatedMember.LastName;
            oldMember.Email = updatedMember.Email;
            oldMember.PhoneNumber = updatedMember.PhoneNumber;
            oldMember.BirthDate = updatedMember.BirthDate;

            // effectief uitvoeren van update in db
            db.SaveChanges();
            // als update gelukt is, resultaat true
            return true;
        }

        #endregion

        #region validationmethods

        // methode om te controleren of een e-mail adres al aanwezig is in db
        public bool EmailExists(string email, int? id = null)
        {
            // alle member records checken en e-mail vergelijken
            if (db.Members.Any(m => m.Email == email
                               && m.MemberId != id)) return true;
            // e-mail nog niet in db? alles ok dus 'false'
            return false;
        }

        #endregion
    }
}
