namespace SportsClub.Models
{
    public class Activity
    {
        // primary key property
        public int ActivityId { get; set; }
        public string ActivityName { get; set; } = string.Empty;
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
