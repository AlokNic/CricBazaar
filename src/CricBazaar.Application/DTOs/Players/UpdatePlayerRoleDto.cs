namespace CricBazaar.Application.DTOs.Players
{
    public class UpdatePlayerRoleDto
    {
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}