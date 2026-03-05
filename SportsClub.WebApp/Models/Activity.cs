namespace SportsClub.WebApp.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; } = string.Empty;
        public int MaxParticipants { get; set; }

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
