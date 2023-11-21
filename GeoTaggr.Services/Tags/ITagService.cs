using GeoTaggr.Core.Tags;
using GeoTaggr.Data.Tags;

namespace GeoTaggr.Services.Tags
{
    public interface ITagService
    {
        Task<ServiceResult> AddTagAsync(Tag tag);

        Task<IReadOnlyCollection<Tag>> GetTagsAsync(TagFilter filter);
    }
}
