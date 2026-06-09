namespace CricBazaar.Application.DTOs.Players
{
    public class CreatePlayerDto
    {
        public string FullName { get; set; } = string.Empty;

        public string? ShortName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? CountryId { get; set; }

        public int PlayerRoleId { get; set; }

        public string? BattingStyle { get; set; }

        public string? BowlingStyle { get; set; }

        public int? JerseyNumber { get; set; }

        public int? HeightCm { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string? Bio { get; set; }
    }
}