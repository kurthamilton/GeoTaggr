namespace GeoTaggr.Core.Countries
{
    public class Country(int countryId, string name, string isoCode3, string isoCode2, bool hasCoverage)
    {
        public int CountryId { get; } = countryId;

        public bool HasCoverage { get; set; } = hasCoverage;

        public string IsoCode2 { get; } = isoCode2;

        public string IsoCode3 { get; } = isoCode3;

        public string Name { get; set; } = name;
    }
}
