using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CricBazaar.Domain.Entities.Country;

namespace CricBazaar.Application.Interfaces.Countries
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync();

        Task<Country?> GetByIdAsync(int id);

        Task<int> CreateAsync(Country country);

        Task<bool> UpdateAsync(Country country);

        Task<bool> DeleteAsync(int id);
    }
}
