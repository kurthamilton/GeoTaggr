using GeoTaggr.Core.Tags;
using GeoTaggr.Data.Tags;

namespace GeoTaggr.Services.Tags
{
    public interface ITagService
    {
        Task<ServiceResult> AddTagAsync(TagInput input, int userId);

        Task<ServiceResult> DeleteTagAsync(int tagId, int userId);

        Task<IReadOnlyCollection<Tag>> GetTagsAsync(TagFilter filter);
    }
}
