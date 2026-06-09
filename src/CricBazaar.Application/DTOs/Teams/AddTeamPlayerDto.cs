namespace CricBazaar.Application.DTOs.Teams
{
    public class AddTeamPlayerDto
    {
        public int PlayerId { get; set; }

        public DateTime FromDate { get; set; }

        public int? ShirtNumber { get; set; }

        public bool IsCaptain { get; set; }

        public bool IsViceCaptain { get; set; }
    }
}