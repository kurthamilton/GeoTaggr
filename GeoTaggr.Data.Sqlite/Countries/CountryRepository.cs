using GeoTaggr.Core.Countries;
using GeoTaggr.Data.Countries;

namespace GeoTaggr.Data.Sqlite.Countries
{
    public class CountryRepository : SqliteRepository, ICountryRepository
    {
        public CountryRepository(GeoTaggrContext context)
            : base(context)
        {
        }

        public Task<bool> AddCountryAsync(Country country) 
            => AddOneAsync(country);

        public Task<IReadOnlyCollection<Country>> GetCountriesAsync() 
            => ReadManyAsync<Country>();
        
        public Task<Country?> GetCountryAsync(int countryId) 
            => ReadSingleAsync<Country>(x => x.CountryId == countryId);

        public Task<Country?> GetCountryByIsoCode2Async(string isoCode2)
            => ReadSingleAsync<Country>(x => x.IsoCode2 == isoCode2);

        public Task<bool> UpdateCountryAsync(Country country)
            => UpdateOneAsync(country);
    }
}
