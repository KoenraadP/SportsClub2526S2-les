using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsClub.Models;

namespace SportsClub.WebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        // properties --> verantwoordelijk voor de databank tabellen
        public DbSet<Member> Members { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Snack> Snacks { get; set; }    

        // methode om default data aan de databank toe te voegen
        // wordt ook wel 'seeden' genoemd
        // om effectief uit te voeren, nog eens add-migration (naam bvb SeedData)
        // en update-database commando's in de console
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // members
            builder.Entity<Member>().HasData(
                new Member { MemberId = 1, FirstName = "Koenraad", LastName = "Pecceu" },
                new Member { MemberId = 2, FirstName = "Mieke", LastName = "Lapeire" },
                new Member { MemberId = 3, FirstName = "Jelle", LastName = "Vyncke" }
                );

            // activities
            builder.Entity<Activity>().HasData(
                new Activity { ActivityId = 1, ActivityName = "Voetbal", MaxParticipants = 30},
                new Activity { ActivityId = 2, ActivityName = "Tennis", MaxParticipants = 10}
                );

            // snacks
            builder.Entity<Snack>().HasData(
                new Snack { SnackId = 1, SnackName = "Chips", SnackDescription = "Salted potato chips (bag)", SnackPrice = 1.50m },
                new Snack { SnackId = 2, SnackName = "Chocolate Bar", SnackDescription = "Milk chocolate 50g", SnackPrice = 1.25m }
                );
        }
    }
}
