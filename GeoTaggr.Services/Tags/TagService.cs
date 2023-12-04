using GeoTaggr.Core.Countries;
using GeoTaggr.Core.Tags;
using GeoTaggr.Data.Countries;
using GeoTaggr.Data.Tags;

namespace GeoTaggr.Services.Tags;

public class TagService(ITagRepository tagRepository, ICountryRepository countryRepository) : ITagService
{
    public async Task<ServiceResult> AddTagAsync(TagInput input, int userId)
    {
        Country? country = await countryRepository.GetCountryAsync(input.CountryId ?? 0);
        if (country == null)
        {
            return ServiceResult.Failure("Country not found");
        }

        if (string.IsNullOrEmpty(input.Name))
        {
            return ServiceResult.Failure("Name required");
        }

        if (string.IsNullOrEmpty(input.Value))
        {
            return ServiceResult.Failure("Value required");
        }

        Tag tag = new Tag(
            tagId: 0,
            createdDate: DateTime.UtcNow,
            userId: userId,
            countryId: country.CountryId,
            name: input.Name,
            value: input.Value,
            url: input.Url,
            lat: input.Lat,
            @long: input.Long);

        bool success = await tagRepository.AddTagAsync(tag);
        return success
            ? ServiceResult.Successful("Tag created")
            : ServiceResult.Failure("Error creating tag");
    }

    public async Task<ServiceResult> DeleteTagAsync(int tagId, int userId)
    {
        Tag? tag = await tagRepository.GetTagAsync(tagId);
        if (tag == null || tag.UserId != userId)
        {
            return ServiceResult.Failure("Tag not found");
        }

        bool success = await tagRepository.DeleteTagAsync(tag);
        return success
            ? ServiceResult.Successful("Tag deleted")
            : ServiceResult.Failure("Error deleting tag");
    }

    public Task<IReadOnlyCollection<Tag>> GetTagsAsync(TagFilter filter)
    {
        return tagRepository.GetTagsAsync(filter);
    }
}
