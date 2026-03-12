namespace SportsClub.Models
{
    public class Snack
    {
        public int SnackId { get; set; }
        public string SnackName { get; set; } = string.Empty;
        public string SnackDescription { get; set; } = string.Empty;
        public decimal SnackPrice { get; set; }

        public Snack()
        {

        }

        public Snack(string snackName, string snackDescription,
            decimal snackPrice)
        {
            SnackName = snackName;
            SnackDescription = snackDescription;
            SnackPrice = snackPrice;
        }
    }
}
