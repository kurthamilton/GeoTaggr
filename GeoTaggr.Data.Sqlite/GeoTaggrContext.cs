using Microsoft.EntityFrameworkCore;

namespace GeoTaggr.Data.Sqlite;

public class GeoTaggrContext(SqliteRepositorySettings settings) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(settings.ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GeoTaggrContext).Assembly);
    }
}
