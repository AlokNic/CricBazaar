namespace CricBazaar.Application.DTOs.Players
{
    public class UpdatePlayerDto : CreatePlayerDto
    {
        public bool IsActive { get; set; }
    }
}