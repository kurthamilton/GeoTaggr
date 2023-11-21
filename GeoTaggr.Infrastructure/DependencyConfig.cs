using GeoTaggr.Data.Countries;
using GeoTaggr.Data.Sqlite;
using GeoTaggr.Data.Sqlite.Countries;
using GeoTaggr.Data.Sqlite.Tags;
using GeoTaggr.Data.Tags;
using GeoTaggr.Services.Countries;
using GeoTaggr.Services.Tags;
using Microsoft.Extensions.Configuration;

namespace GeoTaggr.Infrastructure
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies(IDependencyContainer container, IConfiguration config)
        {
            RegisterData(container, config);
            RegisterServices(container);
        }

        private static void RegisterData(IDependencyContainer container, IConfiguration config)
        {
            container
                .AddSingleton(new SqliteRepositorySettings(config.GetConnectionString("geotaggr-sql") ?? ""))
                .AddScoped<ICountryRepository, CountryRepository>()
                .AddScoped<ITagRepository, TagRepository>();
        }

        private static void RegisterServices(IDependencyContainer container)
        {
            container
                .AddScoped<ICountryService, CountryService>()
                .AddScoped<ITagService, TagService>();
        }
    }
}
