namespace CricBazaar.Domain.Entities.Teams
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;

        public int TeamTypeId { get; set; }

        public string? TeamTypeName { get; set; }

        public int? CountryId { get; set; }

        public string? CountryName { get; set; }

        public string? LogoUrl { get; set; }

        public int? OwnerUserId { get; set; }

        public string? OwnerName { get; set; }

        public string? Description { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}