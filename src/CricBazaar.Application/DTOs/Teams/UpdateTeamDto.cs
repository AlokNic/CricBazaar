namespace CricBazaar.Application.DTOs.Teams
{
    public class UpdateTeamDto
    {
        public string Name { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;

        public int TeamTypeId { get; set; }

        public int? CountryId { get; set; }

        public string? LogoUrl { get; set; }

        public int? OwnerUserId { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }
    }
}