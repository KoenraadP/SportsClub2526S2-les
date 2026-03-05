using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsClub.WebApp.Models;

namespace SportsClub.WebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        // properties --> verantwoordelijk voor de databank tabellen
        public DbSet<Member> Members { get; set; }
    }
}
