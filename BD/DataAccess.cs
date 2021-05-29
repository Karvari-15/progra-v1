using Dapper;
using Dapper.Mapper;
using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration config;

        public DataAccess(IConfiguration _config)
        {
            config = _config;
        }

        public SqlConnection DbConnection => new SqlConnection(
            new SqlConnectionStringBuilder(config.GetConnectionString("conn")).ConnectionString
            );

        #region Queries
        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, object param = null, int? timeout = null)
        {
            try
            {
                using (SqlConnection exec = DbConnection)
                {
                    await exec.OpenAsync();
                    return await exec.QueryAsync<T>(sql: sp, param: param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: timeout);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<dynamic>> QueryAsync(string sp, object param = null, int? timeout = null)
        {
            try
            {
                using (SqlConnection exec = DbConnection)
                {
                    await exec.OpenAsync();
                    return await exec.QueryAsync(sql: sp, param: param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: timeout);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B>(string sp, object param = null, int? timeout = null)
        {
            try
            {
                using (SqlConnection exec = DbConnection)
                {
                    await exec.OpenAsync();
                    return await exec.QueryAsync<T, B>(sql: sp, param: param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: timeout);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C>(string sp, object param = null, int? timeout = null)
        {
            try
            {
                using (SqlConnection exec = DbConnection)
                {
                    await exec.OpenAsync();
                    return await exec.QueryAsync<T, B, C>(sql: sp, param: param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: timeout);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D>(string sp, object param = null, int? timeout = null)
        {
            try
            {
                using (SqlConnection exec = DbConnection)
                {
                    await exec.OpenAsync();
                    return await exec.QueryAsync<T, B, C, D>(sql: sp, param: param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: timeout);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E>(string sp, object param = null, int? timeout = null)
        {
            try
            {
                using (SqlConnection exec = DbConnection)
                {
                    await exec.OpenAsync();
                    return await exec.QueryAsync<T, B, C, D, E>(sql: sp, param: param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: timeout);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F>(string sp, object param = null, int? timeout = null)
        {
            try
            {
                using (SqlConnection exec = DbConnection)
                {
                    await exec.OpenAsync();
                    return await exec.QueryAsync<T, B, C, D, E, F>(sql: sp, param: param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: timeout);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F, G>(string sp, object param = null, int? timeout = null)
        {
            try
            {
                using (SqlConnection exec = DbConnection)
                {
                    await exec.OpenAsync();
                    return await exec.QueryAsync<T, B, C, D, E, F, G>(sql: sp, param: param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: timeout);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        public async Task<T> QueryFirstAsync<T>(string sp, object Param = null, int? timeout = null)
        {
            try
            {
                using (SqlConnection exec = DbConnection)
                {
                    await exec.OpenAsync();
                    return await exec.QueryFirstOrDefaultAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: timeout);
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        public async Task<DBEntity> ExecuteAsync(string sp, object Param = null, int? timeout = null)
        {
            try
            {
                using (SqlConnection exec = DbConnection)
                {
                    await exec.OpenAsync();
                    DbDataReader result = await exec.ExecuteReaderAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: timeout);
                    await result.ReadAsync();

                    return new()
                    {
                        CodeError = result.GetInt32(0),
                        MsgError = result.GetString(1)
                    };
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
