namespace CricBazaar.Application.DTOs.Teams
{
    public class TeamPlayerDto
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public string PlayerName { get; set; } = string.Empty;

        public int? ShirtNumber { get; set; }

        public bool IsCaptain { get; set; }

        public bool IsViceCaptain { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}