using System.Diagnostics.CodeAnalysis;
using GeoTaggr.Core.Maps;

namespace GeoTaggr.Services.Maps
{
    public interface IMapService
    {
        string GetGoogleMapsApiKey();

        bool TryParseLocation(string? url, 
            [NotNullWhen(true)] out Coordinates? location);
    }
}
