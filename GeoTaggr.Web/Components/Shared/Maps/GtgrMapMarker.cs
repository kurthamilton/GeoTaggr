namespace GeoTaggr.Web.Components.Shared.Maps
{
    public class GtgrMapMarker(double lat, double @long)
    {
        public double Lat { get; } = lat;

        public double Long { get; } = @long;
    }
}
