using System.Data;
using System.Data.SQLite;

namespace GeoTaggr.Data.Sqlite
{
    public abstract class SqliteRepository
    {
        private readonly SqliteRepositorySettings _settings;

        protected SqliteRepository(SqliteRepositorySettings settings) 
        {
            _settings = settings;
        }        

        protected Task<bool> AddOneAsync<T>(T entity, IEntityMapper<T> mapper)
        {
            return ExecuteQueryAsync(mapper.InsertSql, mapper.InsertParameters(entity));
        }

        protected Task<bool> ExecuteQueryAsync(string sql, IEnumerable<IDataParameter> parameters)
        {
            using (IDbConnection connection = GetConnection())
            {
                connection.Open();

                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    using (IDbCommand command = GetCommand(connection, sql, parameters, transaction))
                    {
                        command.CommandType = CommandType.Text;

                        try
                        {
                            command.ExecuteNonQuery();
                            transaction.Commit();
                            return Task.FromResult(true);
                        }
                        catch
                        {
                            transaction.Rollback();
                            return Task.FromResult(false);
                        }
                    }
                }
            }
        }        

        protected Task<IReadOnlyCollection<T>> ReadManyAsync<T>(IEntityMapper<T> mapper)
        {
            string sql =
                $"SELECT {mapper.SelectColumnSql} " +
                $"FROM {mapper.TableName} ";

            return ReadManyAsync(sql, Array.Empty<IDataParameter>(), mapper);
        }

        protected Task<IReadOnlyCollection<T>> ReadManyAsync<T>(string sql, IEnumerable<IDataParameter> parameters,
            IEntityMapper<T> mapper)
        {
            using (IDbConnection conn = GetConnection())
            {
                using (IDbCommand cmd = GetCommand(conn, sql, parameters))
                {
                    conn.Open();

                    IDataReader reader = cmd.ExecuteReader();

                    List<T> entities = new();
                    if (!reader.Read())
                    {
                        return Task.FromResult((IReadOnlyCollection<T>)entities);
                    }
                    
                    do
                    {
                        T entity = mapper.Map(reader);
                        entities.Add(entity);
                    } while (reader.Read());

                    return Task.FromResult((IReadOnlyCollection<T>)entities);
                }
            }
        }

        protected Task<T?> ReadSingleAsync<T>(string sql, IEnumerable<IDataParameter> parameters, 
            IEntityMapper<T> mapper)
        {
            using (IDbConnection conn = GetConnection())
            {
                using (IDbCommand cmd = GetCommand(conn, sql, parameters))
                {
                    conn.Open();

                    T? result = default;

                    try
                    {                        
                        IDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            result = mapper.Map(reader);
                        }

                        return Task.FromResult(result);
                    }
                    catch
                    {
                        return Task.FromResult(result);
                    }
                }
            }
        }

        private IDbCommand GetCommand(IDbConnection conn, string sql, 
            IEnumerable<IDataParameter> parameters)
        {
            IDbCommand cmd = new SQLiteCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            
            foreach (IDataParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }

            return cmd;
        }

        private IDbCommand GetCommand(IDbConnection conn, string sql, 
            IEnumerable<IDataParameter> parameters, IDbTransaction transaction)
        {
            IDbCommand cmd = GetCommand(conn, sql, parameters);
            cmd.Transaction = transaction;
            return cmd;
        }

        private IDbConnection GetConnection()
        {
            return new SQLiteConnection(_settings.ConnectionString);
        }
    }
}