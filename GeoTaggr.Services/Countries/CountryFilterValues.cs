using GeoTaggr.Core.Countries;
using GeoTaggr.Data;

namespace GeoTaggr.Services.Countries;

public class CountryFilterValues : IFilter<Country>
{
    public bool IncludeNoCoverage { get; set; }

    public string? Name { get; set; }

    public bool IsMatch(Country entity)
    {
        return 
            (IncludeNoCoverage || entity.HasCoverage) && 
            (string.IsNullOrEmpty(Name) || entity.Name.Contains(Name, StringComparison.InvariantCultureIgnoreCase));
    }
}