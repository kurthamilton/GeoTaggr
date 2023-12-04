namespace GeoTaggr.Data.Tags
{
    public class TagFilter(int userId)
    {
        public int? CountryId { get; set; }

        public int UserId { get; } = userId;
    }
}
