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

    public Task<Country?> GetCountryByIsoCode2Async(string isoCode2)
    {
        return countryRepository.GetCountryByIsoCode2Async(isoCode2);
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

    public async Task<ServiceResult> UpdateCountryAsync(int countryId, string name)
    {
        IReadOnlyCollection<Country> countries = await GetCountriesAsync(new CountryFilterValues());

        Country? country = countries
            .FirstOrDefault(x => x.CountryId == countryId);
        if (country == null)
        {
            return ServiceResult.Failure("Country not found");
        }

        string originalName = country.Name;
        string newName = name.Trim();

        if (string.Equals(originalName, newName, StringComparison.OrdinalIgnoreCase))
        {
            return ServiceResult.Successful();
        }

        if (countries.Any(x => x.CountryId != countryId && 
            string.Equals(x.Name, newName, StringComparison.InvariantCultureIgnoreCase)))
        {
            return ServiceResult.Failure($"Country '{name}' already exists");
        }

        country.Name = newName;

        bool result = await countryRepository.UpdateCountryAsync(country);
        return result
            ? ServiceResult.Successful($"Country name updated from '{originalName}' to '{newName}'")
            : ServiceResult.Failure($"Error updating country '{originalName}'");
    }
}