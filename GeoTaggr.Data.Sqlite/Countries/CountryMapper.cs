using GeoTaggr.Core.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoTaggr.Data.Sqlite.Countries
{
    public class CountryMapper : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(x => x.CountryId);
            builder.Property(x => x.IsoCode2);
            builder.Property(x => x.IsoCode3);
            builder.Property(x => x.Name);
        }
    }
}
