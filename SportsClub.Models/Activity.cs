using System.ComponentModel.DataAnnotations;

namespace SportsClub.Models
{
    public class Activity
    {
        // primary key property
        public int ActivityId { get; set; }
        [Required(ErrorMessage = "Naam mag niet leeg zijn!")]
        [StringLength(30,MinimumLength = 2, ErrorMessage = "Minimum 2, maximum 30 letters in de naam!")]
        [Display(Name = "Naam activiteit")]
        public string ActivityName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Aantal deelnemers mag niet leeg zijn!")]
        [Range(6,30,ErrorMessage = "Aantal deelnemers tussen 6 en 30")]
        [Display(Name = "Aantal deelnemers")]
        public int MaxParticipants { get; set; }

        // relatie property --> voor één activity kunnen veel members ingeschreven worden
        // de list wordt ook onmiddellijk al "geïnitialiseerd" met een lege list
        public List<Member> Members { get; set; } = new();

        public Activity()
        {
            
        }

        public Activity(string activityName, int maxParticipants)
        {
            ActivityName = activityName;
            MaxParticipants = maxParticipants;
        }
    }
}
