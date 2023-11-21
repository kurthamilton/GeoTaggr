using System.Data;
using GeoTaggr.Core.Countries;

namespace GeoTaggr.Data.Sqlite.Countries
{
    public class CountryMapper : EntityMapper<Country>
    {
        public override IReadOnlyCollection<string> SelectColumns => new[]
        {
            "CountryId",
            "Name",
            "IsoCode3",
            "IsoCode2"
        };

        public override string TableName => "Countries";

        public override IReadOnlyCollection<string> InsertColumns => SelectColumns.Skip(1).ToArray();

        public override IReadOnlyCollection<IDataParameter> InsertParameters(Country country)
        {
            return new[]
            {
                GetParameter("@Name", country.Name, DbType.String),
                GetParameter("@IsoCode3", country.IsoCode3, DbType.String),
                GetParameter("@IsoCode2", country.IsoCode2, DbType.String)
            };
        }

        public override Country Map(IDataReader reader) => new Country(
            countryId: reader.GetInt32(0), 
            name: reader.GetString(1),
            isoCode3: reader.GetString(2),
            isoCode2: reader.GetString(3));
    }
}
