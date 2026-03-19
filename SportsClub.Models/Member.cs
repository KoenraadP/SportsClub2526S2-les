namespace SportsClub.Models
{
    public class Member
    {
        // id is nodig voor databank, duidt specifieke records aan, dit is de 'Primary Key'
        public int MemberId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // PhoneNumber is niet verplicht in te vullen, dus kan eventueel null zijn
        // duiden we aan door vraagteken na type te plaatsen
        public string? PhoneNumber { get; set; }
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
