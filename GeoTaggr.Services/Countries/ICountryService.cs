using GeoTaggr.Core.Countries;

namespace GeoTaggr.Services.Countries;

public interface ICountryService
{
    Task<IReadOnlyCollection<Country>> GetCountriesAsync(CountryFilterValues filter);

    Task<IReadOnlyDictionary<int, Country>> GetCountryDictionaryAsync(CountryFilterValues filter);

    Task<ServiceResult> IncludeCountryAsync(int countryId);
}
