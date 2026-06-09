using System;
using System.Collections.Generic;
using System.Text;

namespace CricBazaar.Application.DTOs.Users
{
    public class UpdateTeamDto
    {
        public string Name { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;
    }
}
