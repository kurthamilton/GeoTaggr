namespace GeoTaggr.Services.Tags
{
    public class TagInput
    {
        public int? CountryId { get; set; }

        public string? Name {  get; set; }
        
        public string? Value { get; set; }

        public double? Lat { get; set; }

        public double? Long { get; set; }

        public string? Url { get; set; }
    }
}
