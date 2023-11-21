using GeoTaggr.Core.Maps;

namespace GeoTaggr.Core.Tags
{
    public class Tag(int tagId, DateTime createdDate, int userId, int countryId, string name, string value,
        string? url, double? lat, double? @long)
    {
        public int CountryId { get; } = countryId;

        public DateTime CreatedDate { get; } = createdDate;        

        public double? Lat { get; set; } = lat;

        public Coordinates? Location => Coordinates.FromLatLong(Lat, Long); 

        public double? Long { get; set; } = @long;

        public string Name { get; set; } = name;

        public int TagId { get; } = tagId;

        public string? Url { get; set; } = url;

        public int UserId { get; } = userId;

        public string Value { get; set; } = value;
    }
}
