using GeoTaggr.Core.Countries;
using GeoTaggr.Data.Countries;

namespace GeoTaggr.Services.Countries;

public class CountryService(ICountryRepository countryRepository) : ICountryService
{
    public async Task<IReadOnlyCollection<Country>> GetCountriesAsync(CountryFilterValues filter)
    {
        IReadOnlyCollection<Country> countries = await countryRepository.GetCountriesAsync();

        return countries
            .Where(filter.IsMatch)
            .ToArray();
    }

    public async Task<IReadOnlyDictionary<int, Country>> GetCountryDictionaryAsync(CountryFilterValues filter)
    {
        IReadOnlyCollection<Country> countries = await GetCountriesAsync(filter);
        return countries
            .ToDictionary(x => x.CountryId)
            .AsReadOnly();
    }

    public async Task<ServiceResult> IncludeCountryAsync(int countryId)
    {
        Country? country = await countryRepository.GetCountryAsync(countryId);
        if (country == null) 
        {
            return ServiceResult.Failure("Country not found");
        }

        country.HasCoverage = true;

        bool success = await countryRepository.UpdateCountryAsync(country);
        return success
            ? ServiceResult.Successful("Country updated")
            : ServiceResult.Failure("Error updating country");
    }
}