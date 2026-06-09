namespace CricBazaar.Application.DTOs.Players
{
    public class PlayerDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string? ShortName { get; set; }

        public string? Country { get; set; }

        public string PlayerRole { get; set; } = string.Empty;

        public string? BattingStyle { get; set; }

        public string? BowlingStyle { get; set; }

        public int? JerseyNumber { get; set; }

        public string? ProfileImageUrl { get; set; }

        public bool IsActive { get; set; }
    }
}