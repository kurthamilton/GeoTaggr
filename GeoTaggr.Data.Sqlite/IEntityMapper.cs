using System.Data;

namespace GeoTaggr.Data.Sqlite
{
    public interface IEntityMapper<T>
    {        
        string InsertSql { get; }

        IReadOnlyCollection<string> SelectColumns { get; }

        string SelectColumnSql { get; }

        string TableName { get; }

        IReadOnlyCollection<IDataParameter> InsertParameters(T entity);

        T Map(IDataReader reader);
    }
}
