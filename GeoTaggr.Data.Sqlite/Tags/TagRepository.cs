using System.Linq.Expressions;
using GeoTaggr.Core.Tags;
using GeoTaggr.Data.Tags;

namespace GeoTaggr.Data.Sqlite.Tags
{
    public class TagRepository : SqliteRepository, ITagRepository
    {
        public TagRepository(GeoTaggrContext context) 
            : base(context)
        {
        }

        public Task<bool> AddTagAsync(Tag tag) 
            => AddOneAsync(tag);

        public Task<bool> DeleteTagAsync(Tag tag)
            => DeleteOneAsync(tag);

        public Task<Tag?> GetTagAsync(int tagId)
            => ReadSingleAsync<Tag>(x => x.TagId == tagId);

        public Task<IReadOnlyCollection<Tag>> GetTagsAsync(TagFilter filter) 
            => ReadManyAsync(ToExpression(filter));

        private Expression<Func<Tag, bool>> ToExpression(TagFilter filter)
        {
            return x => 
                (x.UserId == filter.UserId) &&
                (filter.CountryId == null || x.CountryId == filter.CountryId);
        }
    }
}
