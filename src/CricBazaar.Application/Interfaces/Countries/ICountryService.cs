using CricBazaar.Application.DTOs.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricBazaar.Application.Interfaces.Countries
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();

        Task<CountryDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateCountryDto dto);

        Task<bool> UpdateAsync(
            int id,
            UpdateCountryDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
