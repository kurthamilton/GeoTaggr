using GeoTaggr.Core.Countries;

namespace GeoTaggr.Data.Countries
{
    public interface ICountryRepository
    {
        Task<bool> AddCountryAsync(Country country);

        Task<IReadOnlyCollection<Country>> GetCountriesAsync();
    }
}
