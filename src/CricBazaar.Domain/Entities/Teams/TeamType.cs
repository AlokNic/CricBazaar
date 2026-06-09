namespace CricBazaar.Domain.Entities.Teams
{
    public class TeamType
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}