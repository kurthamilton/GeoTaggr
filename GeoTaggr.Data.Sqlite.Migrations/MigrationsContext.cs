using Microsoft.EntityFrameworkCore;

namespace GeoTaggr.Data.Sqlite.Migrations;

public class MigrationsContext(SqliteRepositorySettings? settings = null) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // no connection string when adding migration, just when running migrations in the live app
        options.UseSqlite(settings?.ConnectionString ?? "");
    }
}
