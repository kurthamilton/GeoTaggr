using GeoTaggr.Core.Countries;

namespace GeoTaggr.Services.Countries;

public interface ICountryService
{
    Task<IReadOnlyCollection<Country>> GetCountriesAsync(CountryFilterValues filter);

    Task<Country?> GetCountryByIsoCode2Async(string isoCode2);

    Task<IReadOnlyDictionary<int, Country>> GetCountryDictionaryAsync(CountryFilterValues filter);

    Task<ServiceResult> IncludeCountryAsync(int countryId);

    Task<ServiceResult> UpdateCountryAsync(int countryId, string name);
}
