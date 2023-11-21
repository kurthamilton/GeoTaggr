using System.Data;
using GeoTaggr.Core.Tags;
using GeoTaggr.Data.Sqlite.Extensions;

namespace GeoTaggr.Data.Sqlite.Tags
{
    public class TagMapper : EntityMapper<Tag>
    {
        public override IReadOnlyCollection<string> SelectColumns => new[]
        {
            "TagId",
            "CreatedDate",
            "UserId",
            "CountryId",
            "Name",
            "Value",
            "Lat",
            "Long",
            "Url"
        };

        public override string TableName => "Tags";

        public override IReadOnlyCollection<string> InsertColumns => SelectColumns.Skip(1).ToArray();

        public override IReadOnlyCollection<IDataParameter> InsertParameters(Tag entity)
        {
            return new[]
            {
                GetParameter("@CountryId", entity.CountryId, DbType.Int32),
                GetParameter("@CreatedDate", entity.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"), DbType.String),
                GetParameter("@UserId", entity.UserId, DbType.Int32),
                GetParameter("@Name", entity.Name, DbType.String),
                GetParameter("@Value", entity.Value, DbType.String),
                GetParameter("@Lat", entity.Lat, DbType.Double),
                GetParameter("@Long", entity.Lat, DbType.Double),
                GetParameter("@Url", entity.Lat, DbType.String)
            };
        }

        public override Tag Map(IDataReader reader)
        {
            return new Tag(
                tagId: reader.GetInt32(0),
                createdDate: DateTime.Parse(reader.GetString(1)),
                userId: reader.GetInt32(2),
                countryId: reader.GetInt32(3),
                name: reader.GetString(4),
                value: reader.GetString(5),
                lat: reader.GetDoubleOrNull(6),
                @long: reader.GetDoubleOrNull(7),
                url: reader.GetStringOrNull(8));
        }
    }
}
