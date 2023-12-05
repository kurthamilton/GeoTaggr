using System.Reflection;
using GeoTaggr.Data.Countries;
using GeoTaggr.Data.Sqlite;
using GeoTaggr.Data.Sqlite.Countries;
using GeoTaggr.Data.Sqlite.Migrations;
using GeoTaggr.Data.Sqlite.Tags;
using GeoTaggr.Data.Tags;
using GeoTaggr.Infrastructure.Extensions;
using GeoTaggr.Services.Countries;
using GeoTaggr.Services.Maps;
using GeoTaggr.Services.Tags;
using Microsoft.Extensions.Configuration;

namespace GeoTaggr.Infrastructure;

public static class DependencyConfig
{
    public static void RegisterDependencies(IDependencyContainer container, IConfiguration config)
    {
        RegisterData(container, config);
        RegisterServices(container, config);
    }

    private static void RegisterData(IDependencyContainer container, IConfiguration config)
    {
        string connectionStringFormat = config.GetConnectionString("geotaggr-sqlite") ?? "";
        string dbRelativeFilePath = config.GetValue("Sqlite:Path") ?? "";
        string dbAbsoluteFilePath = ResolveAbsoluteFilePath(dbRelativeFilePath);
        string connectionString = connectionStringFormat.Replace("{path}", dbAbsoluteFilePath);

        container
            .AddScoped<GeoTaggrContext>()
            .AddScoped<MigrationsContext>()
            .AddSingleton(new SqliteRepositorySettings(connectionString))
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

    /// <summary>
    /// Resolves a file path relative to the solution root
    /// </summary>    
    private static string ResolveAbsoluteFilePath(string relativeFilePath)
    {        
        DirectoryInfo? projectDirectory = FindProjectDirectory();
        DirectoryInfo? solutionDirectory = projectDirectory?.Parent;

        if (solutionDirectory == null)
        {
            throw new Exception("Error resolving database file path");
        }

        string absoluteFilePath = solutionDirectory.FullName + relativeFilePath;
        return absoluteFilePath;
    }

    private static DirectoryInfo? FindProjectDirectory()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string currentFilePath = assembly.Location;
        DirectoryInfo? directory = new FileInfo(currentFilePath).Directory;

        while (directory != null)
        {
            if (string.Equals("bin", directory.Name, StringComparison.InvariantCultureIgnoreCase))
            {
                return directory.Parent;
            }

            directory = directory.Parent;
        }

        return null;
    }
}
