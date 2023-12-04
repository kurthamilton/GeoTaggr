using CoreCountry = GeoTaggr.Core.Countries.Country;

namespace GeoTaggr.Web.Components.Pages;

public static class GtgrRouteParams
{
    public const string CountryIsoCode2 = "isoCode2";
}

public static class GtgrRoutes
{
    public const string Countries = "/countries";

    public const string Country = $"{Countries}/{{{GtgrRouteParams.CountryIsoCode2}}}";

    public const string TagOverview = "/tags/overview";

    public const string Tags = "/tags";

    public static string GetCountriesUrl(CoreCountry? country)
    {
        string url = Countries;
        if (country != null)
        {
            url += $"#{country.IsoCode2}";
        }

        return url;
    }

    public static string GetCountryUrl(CoreCountry country)
    {
        return Country
            .Replace($"{{{GtgrRouteParams.CountryIsoCode2}}}", country.IsoCode2);
    }
}
