using GeoTaggr.Core.Countries;

namespace GeoTaggr.Data.Countries
{
    public interface ICountryRepository
    {
        Task<bool> AddCountryAsync(Country country);

        Task<IReadOnlyCollection<Country>> GetCountriesAsync();

        Task<Country?> GetCountryAsync(int countryId);

        Task<Country?> GetCountryByIsoCode2Async(string isoCode2);

        Task<bool> UpdateCountryAsync(Country country);
    }
}
