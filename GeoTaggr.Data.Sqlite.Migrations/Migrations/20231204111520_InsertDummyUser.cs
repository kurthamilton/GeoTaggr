using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoTaggr.Data.Sqlite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InsertDummyUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string sql = @"
INSERT INTO Users (Email) VALUES ('DUMMY@DUMMY.COM')
";
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
