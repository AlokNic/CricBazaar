namespace CricBazaar.Domain.Entities.Teams
{
    public class TeamPlayer
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int PlayerId { get; set; }

        public string? PlayerName { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int? ShirtNumber { get; set; }

        public bool IsCaptain { get; set; }

        public bool IsViceCaptain { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}