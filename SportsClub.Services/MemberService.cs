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
    }
}
