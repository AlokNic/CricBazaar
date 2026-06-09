namespace CricBazaar.Application.DTOs.Users
{
    public class UpdateUserDto
    {
        public string FullName { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? ProfileImageUrl { get; set; }

        public bool IsActive { get; set; }
    }
}