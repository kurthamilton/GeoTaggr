using GeoTaggr.Core.Countries;
using GeoTaggr.Data.Countries;

namespace GeoTaggr.Data.Sqlite.Countries
{
    public class CountryRepository : SqliteRepository, ICountryRepository
    {
        private static readonly CountryMapper CountryMapper = new CountryMapper();

        public CountryRepository(SqliteRepositorySettings settings)
            : base(settings)
        {
        }

        public Task<bool> AddCountryAsync(Country country)
        {
            return AddOneAsync(country, CountryMapper);
        }

        public Task<IReadOnlyCollection<Country>> GetCountriesAsync()
        {
            return ReadManyAsync(CountryMapper);
        }
    }
}
