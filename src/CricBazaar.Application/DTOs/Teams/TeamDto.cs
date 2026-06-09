namespace CricBazaar.Application.DTOs.Teams
{
    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;

        public string TeamType { get; set; } = string.Empty;

        public string? Country { get; set; }

        public string? LogoUrl { get; set; }

        public string? OwnerName { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }
    }
}