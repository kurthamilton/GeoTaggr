using GeoTaggr.Core.Tags;

namespace GeoTaggr.Data.Tags
{
    public interface ITagRepository
    {
        Task<bool> AddTagAsync(Tag tag);

        Task<IReadOnlyCollection<Tag>> GetTagsAsync(TagFilter filter);
    }
}
