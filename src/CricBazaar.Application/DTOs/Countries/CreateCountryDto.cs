using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricBazaar.Application.DTOs.Countries
{
    public class CreateCountryDto
    {
        public string Name { get; set; } = string.Empty;

        public string? ISOCode { get; set; }

        public string? FlagUrl { get; set; }
    }
}
