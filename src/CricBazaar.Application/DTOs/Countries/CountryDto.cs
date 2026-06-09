using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricBazaar.Application.DTOs.Countries
{
    public class CountryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? ISOCode { get; set; }

        public string? FlagUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
