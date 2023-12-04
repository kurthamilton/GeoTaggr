using GeoTaggr.Data.Countries;
using GeoTaggr.Data.Sqlite;
using GeoTaggr.Data.Sqlite.Countries;
using GeoTaggr.Data.Sqlite.Tags;
using GeoTaggr.Data.Tags;
using GeoTaggr.Infrastructure.Extensions;
using GeoTaggr.Services.Countries;
using GeoTaggr.Services.Maps;
using GeoTaggr.Services.Tags;
using Microsoft.Extensions.Configuration;

namespace GeoTaggr.Infrastructure
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies(IDependencyContainer container, IConfiguration config)
        {
            RegisterData(container, config);
            RegisterServices(container, config);
        }

        private static void RegisterData(IDependencyContainer container, IConfiguration config)
        {
            container
                .AddScoped<GeoTaggrContext>()
                .AddSingleton(new SqliteRepositorySettings(config.GetConnectionString("geotaggr-sql") ?? ""))
                .AddScoped<ICountryRepository, CountryRepository>()
                .AddScoped<ITagRepository, TagRepository>();
        }

        private static void RegisterServices(IDependencyContainer container, IConfiguration config)
        {
            container
                .AddScoped<ICountryService, CountryService>()
                .AddScoped<IMapService, MapService>()
                .AddSingleton(new MapServiceSettings(config.GetValue("GoogleMapsApiKey")))
                .AddScoped<ITagService, TagService>();
        }
    }
}
