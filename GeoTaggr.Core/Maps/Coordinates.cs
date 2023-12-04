namespace GeoTaggr.Core.Maps
{
    public class Coordinates(double lat, double @long)
    {
        public double Lat { get; } = lat;

        public double Long { get; } = @long;

        public static Coordinates? FromLatLong(double? lat, double? @long)
        {
            return lat != null && @long != null
                ? new Coordinates(lat.Value, @long.Value)
                : null;
        }

        public override string ToString()
        {
            return $"{Lat},{Long}";
        }
    }
}
