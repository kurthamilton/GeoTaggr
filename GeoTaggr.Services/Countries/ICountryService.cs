using GeoTaggr.Core.Countries;

namespace GeoTaggr.Services.Countries
{
    public interface ICountryService
    {
        Task<ServiceResult> AddCountryAsync(Country country);

        Task<IReadOnlyCollection<Country>> GetCountriesAsync();

        Task<IReadOnlyDictionary<int, Country>> GetCountryDictionaryAsync();
    }
}
