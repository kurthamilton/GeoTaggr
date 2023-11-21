using GeoTaggr.Core.Tags;
using GeoTaggr.Data.Tags;

namespace GeoTaggr.Services.Tags
{
    public class TagService(ITagRepository tagRepository) : ITagService
    {
        public async Task<ServiceResult> AddTagAsync(Tag tag)
        {
            bool success = await tagRepository.AddTagAsync(tag);
            return success
                ? ServiceResult.Successful("Tag added")
                : ServiceResult.Failure("Error adding tag");
        }

        public Task<IReadOnlyCollection<Tag>> GetTagsAsync(TagFilter filter)
        {
            return tagRepository.GetTagsAsync(filter);
        }
    }
}
