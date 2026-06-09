namespace CricBazaar.Application.DTOs.Teams
{
    public class UpdateTeamPlayerDto
    {
        public DateTime? ToDate { get; set; }

        public int? ShirtNumber { get; set; }

        public bool IsCaptain { get; set; }

        public bool IsViceCaptain { get; set; }
    }
}