namespace SportsClub.WebApp.Models
{
    public class Member
    {
        // id is nodig voor databank, duidt specifieke records aan, dit is de 'Primary Key'
        public int MemberId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // lege constructor verplicht
        // anders error over 'parameterless constructor'
        public Member()
        {
            
        }

        // constructor met de nodige eigenschappen
        public Member(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
