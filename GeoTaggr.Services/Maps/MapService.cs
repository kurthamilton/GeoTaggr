using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using GeoTaggr.Core.Maps;

namespace GeoTaggr.Services.Maps
{
    public class MapService(MapServiceSettings settings) : IMapService
    {
        private static readonly IReadOnlyCollection<Regex> UrlRegexes = new[]
        {
            new Regex(@"google\.(\w|\.)+\/maps\/@(?<lat>\-?(\d|\.)+),(?<long>\-?(\d|\.)+),", RegexOptions.Compiled),
            new Regex(@"google\.(\w|\.)+\/maps\?.+cbll=(?<lat>\-?(\d|\.)+),(?<long>\-?(\d|\.)+)", RegexOptions.Compiled)
        };
        
        public string GetGoogleMapsApiKey() => settings.GoogleMapsApiKey;

        public bool TryParseLocation(string? url, 
            [NotNullWhen(true)] out Coordinates? location)
        {
            foreach (Regex regex in UrlRegexes)
            {
                Match match = regex.Match(url ?? "");
                if (!match.Success)
                {
                    continue;
                }

                double lat = double.Parse(match.Groups["lat"].Value);
                double @long = double.Parse(match.Groups["long"].Value);
                location = new Coordinates(lat, @long);
                return true;
            }

            location = null;
            return false;
        }
    }
}
