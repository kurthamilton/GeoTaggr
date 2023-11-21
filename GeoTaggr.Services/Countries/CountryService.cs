using GeoTaggr.Core.Countries;
using GeoTaggr.Data.Countries;

namespace GeoTaggr.Services.Countries
{
    public class CountryService(ICountryRepository countryRepository) : ICountryService
    {
        public async Task<ServiceResult> AddCountryAsync(Country country)
        {
            IReadOnlyCollection<Country> countries = await GetCountriesAsync();
            if (countries.Any(x => string.Equals(x.Name, country.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return ServiceResult.Failure("Country name already exists");
            }

            bool success = await countryRepository.AddCountryAsync(country);
            return success
                ? ServiceResult.Successful("Country added")
                : ServiceResult.Failure("Error adding country");
        }

        public Task<IReadOnlyCollection<Country>> GetCountriesAsync()
        {
            return countryRepository.GetCountriesAsync();
        }

        public async Task<IReadOnlyDictionary<int, Country>> GetCountryDictionaryAsync()
        {
            IReadOnlyCollection<Country> countries = await GetCountriesAsync();
            return countries
                .ToDictionary(x => x.CountryId)
                .AsReadOnly();
        }
    }
}
