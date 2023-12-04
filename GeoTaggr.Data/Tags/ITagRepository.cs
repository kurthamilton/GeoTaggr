using GeoTaggr.Core.Tags;

namespace GeoTaggr.Data.Tags
{
    public interface ITagRepository
    {
        Task<bool> AddTagAsync(Tag tag);

        Task<bool> DeleteTagAsync(Tag tag);

        Task<Tag?> GetTagAsync(int tagId);

        Task<IReadOnlyCollection<Tag>> GetTagsAsync(TagFilter filter);
    }
}
