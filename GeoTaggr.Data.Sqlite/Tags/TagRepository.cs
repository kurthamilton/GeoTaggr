using GeoTaggr.Core.Tags;
using GeoTaggr.Data.Tags;

namespace GeoTaggr.Data.Sqlite.Tags
{
    public class TagRepository : SqliteRepository, ITagRepository
    {
        private static readonly IEntityMapper<Tag> TagMapper = new TagMapper();

        public TagRepository(SqliteRepositorySettings settings) 
            : base(settings)
        {
        }

        public Task<bool> AddTagAsync(Tag tag)
        {
            return AddOneAsync(tag, TagMapper);
        }

        public Task<IReadOnlyCollection<Tag>> GetTagsAsync(TagFilter filter)
        {
            return ReadManyAsync(TagMapper);
        }
    }
}
