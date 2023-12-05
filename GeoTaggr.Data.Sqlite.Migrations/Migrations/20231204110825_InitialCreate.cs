using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoTaggr.Data.Sqlite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string sql = @"
CREATE TABLE Countries 
(
	CountryId	INTEGER NOT NULL,
	Name	    TEXT NOT NULL UNIQUE,
	IsoCode3	TEXT NOT NULL UNIQUE,
	IsoCode2	TEXT NOT NULL UNIQUE,
	HasCoverage	INTEGER NOT NULL DEFAULT 0,
	PRIMARY KEY(CountryId AUTOINCREMENT)
);

CREATE TABLE Users 
(
	UserId	INTEGER NOT NULL,
	Email	TEXT NOT NULL UNIQUE,
	PRIMARY KEY(UserId AUTOINCREMENT)
);

CREATE TABLE Tags (
	TagId	INTEGER NOT NULL,
	CountryId	INTEGER NOT NULL,
	Name	TEXT NOT NULL,
	Value	TEXT NOT NULL,
	Lat	NUMERIC,
	Long	NUMERIC,
	Url	TEXT,
	CreatedDate	TEXT NOT NULL,
	UserId	INTEGER NOT NULL,
	PRIMARY KEY(TagId AUTOINCREMENT),
	FOREIGN KEY(CountryId) REFERENCES Countries(CountryId),
	FOREIGN KEY(UserId) REFERENCES Users(UserId)
);
";
			migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
