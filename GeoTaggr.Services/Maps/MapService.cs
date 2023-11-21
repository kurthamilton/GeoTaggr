using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using GeoTaggr.Core.Maps;

namespace GeoTaggr.Services.Maps
{
    public class MapService(MapServiceSettings settings) : IMapService
    {
        private static readonly Regex UrlRegex = 
            new(@"google\.(\w|\.)+\/maps\/@(?<lat>\-?(\d|\.)+),(?<long>\-?(\d|\.)+),", RegexOptions.Compiled);
        
        public string GetGoogleMapsApiKey() => settings.GoogleMapsApiKey;

        public bool TryParseLocation(string? url, 
            [NotNullWhen(true)] out Coordinates? location)
        {
            Match match = UrlRegex.Match(url ?? "");
            if (!match.Success)
            {
                location = null;
                return false;
            }

            double lat = double.Parse(match.Groups["lat"].Value);
            double @long = double.Parse(match.Groups["long"].Value);
            location = new Coordinates(lat, @long);
            return true;
        }
    }
}
