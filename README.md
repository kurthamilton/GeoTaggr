# geotaggr
GeoTaggr lets you add tags to geographic locations.

It is designed as a companion app to [GeoGuessr](https://www.geoguessr.com). 
Tag recognisable features at different locations to build your own knowledgebase.

## Getting started

1. Register for a Google Maps [API Key](https://developers.google.com/maps/documentation/javascript/get-api-key)
2. Add an `appsettings.Development.json` file to the `GeoTaggr.Web` project.
```
{
  "GoogleMapsApiKey": "<GOOGLE_MAPS_API_KEY>"
}
```
4. Install [EF Core CLI tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

## Contributing

### Updating the database schema

Create a new EF migration run the following command from the `GeoTaggr.Data.Sqlite.Migrations` project

`dotnet ef migrations add <NAME>`

This will create a migration stub in which you can write the migration (typically raw SQL). 
The new migration(s) will run on next project startup.