namespace CricBazaar.Domain.Entities.Players
{
    public class Player
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string? ShortName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? CountryId { get; set; }

        public string? CountryName { get; set; }

        public int PlayerRoleId { get; set; }

        public string? PlayerRoleName { get; set; }

        public string? BattingStyle { get; set; }

        public string? BowlingStyle { get; set; }

        public int? JerseyNumber { get; set; }

        public int? HeightCm { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string? Bio { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}