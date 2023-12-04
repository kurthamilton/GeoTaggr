# geotaggr
GeoTaggr lets you add tags to geographic locations.

It is designed as a companion app to [GeoGuessr](https://www.geoguessr.com). 
Tag recognisable features at different locations to build your own knowledgebase.

## Getting started

1. Create a local [SQLite](https://www.sqlite.org/index.html) database. 
	- File can be saved within the solution - *.sqlite3 files are gitignored
2. Register for a Google Maps [API Key](https://developers.google.com/maps/documentation/javascript/get-api-key)
3. Add an `appsettings.Development.json` file to the `GeoTaggr.Web` project.
```
{
  "ConnectionStrings": {
    "geotaggr-sql": "Data Source=<PATH_TO_SQLITE3_FILE>;"
  },
  "GoogleMapsApiKey": "<GOOGLE_MAPS_API_KEY>"
}
```

