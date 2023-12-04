using GeoTaggr.Core.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoTaggr.Data.Sqlite.Tags
{
    public class TagMapper : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");

            builder.HasKey(x => x.TagId);

            builder
                .Property(x => x.TagId)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CountryId);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.Name);
            builder.Property(x => x.TagId);
            builder.Property(x => x.UserId);
        }
    }
}
