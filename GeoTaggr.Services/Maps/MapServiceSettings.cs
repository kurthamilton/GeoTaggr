namespace GeoTaggr.Services.Maps
{
    public class MapServiceSettings(string googleMapsApiKey)
    {
        public string GoogleMapsApiKey { get; } = googleMapsApiKey;
    }
}
