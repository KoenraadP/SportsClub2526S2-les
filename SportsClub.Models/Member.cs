using System.ComponentModel.DataAnnotations;

namespace SportsClub.Models
{
    public class Member
    {
        // id is nodig voor databank, duidt specifieke records aan, dit is de 'Primary Key'
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Voornaam moet ingevuld worden!")]
        [StringLength(50,MinimumLength = 2, ErrorMessage = "Voornaam moet minstens 2 tekens zijn, maximaal 50")]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Achternaam moet ingevuld worden!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Achternaam moet minstens 2 tekens zijn, maximaal 50")]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-mail moet ingevuld worden!")]
        [EmailAddress(ErrorMessage = "Dit is geen correct e-mail adres!")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = string.Empty;

        // PhoneNumber is niet verplicht in te vullen, dus kan eventueel null zijn
        // duiden we aan door vraagteken na type te plaatsen
        [Phone(ErrorMessage = "Dit is geen correct telefoonnummer!")]
        [Display(Name = "Telefoonnummer")]
        public string? PhoneNumber { get; set; }

        // MinimumAge is onze eigen validatie class, zit in CustomValidation.cs
        [Required(ErrorMessage = "Geboortedatum moet ingevuld worden!")]
        [MinimumAge(18,ErrorMessage = "Lid moet minstens 18 jaar zijn!")]
        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public DateTime BirthDate { get; set; } 
        

        // relatie property voor lijst van activities
        // want een member kan ingeschreven zijn voor meerdere activities
        public List<Activity> Activities { get; set; } = new();

        // lege constructor verplicht
        // anders error over 'parameterless constructor'
        public Member()
        {
            
        }

        // constructor met de nodige eigenschappen
        public Member(string firstName, string lastName,
            string email, string? phoneNumber, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
        }
    }
}
