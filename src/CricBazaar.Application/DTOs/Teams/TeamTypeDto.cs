namespace CricBazaar.Application.DTOs.Teams
{
    public class TeamTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}