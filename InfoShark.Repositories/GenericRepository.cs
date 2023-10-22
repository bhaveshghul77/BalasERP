using Dapper;
using InfoShark.Helper;
using System.Data;
using System.Data.SqlClient;

namespace InfoShark.Repositories
{
    public class GenericRepository
    {
        private string? connectionString { get; }

        private DynamicParameters? param;

        public GenericRepository(string? connectionString)
        {
            this.connectionString = connectionString;
        }



        public async Task<T?> AddUpdate<T>(object obj, string module, string action)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                param = new DynamicParameters();
                param.AddDynamicParams(obj);
                return await con.QueryFirstOrDefaultAsync<T>(StoredProcedure.GetQueryName(module, action), param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<T?> Delete<T>(object obj, string module, string action)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                param = new DynamicParameters();
                param.AddDynamicParams(obj);
                return await con.QueryFirstOrDefaultAsync<T>(StoredProcedure.GetQueryName(module, action), param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<T?> GetFirstorDefault<T>(object obj, string module, string action)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                param = new DynamicParameters();
                param.AddDynamicParams(obj);
                return await con.QueryFirstOrDefaultAsync<T>(StoredProcedure.GetQueryName(module, action), param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T?>> GetList<T>(string module, string action)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                return await con.QueryAsync<T>(StoredProcedure.GetQueryName(module, action), commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T?>> GetListWithParam<T>(object obj, string module, string action)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                param = new DynamicParameters();
                param.AddDynamicParams(obj);
                return await con.QueryAsync<T>(StoredProcedure.GetQueryName(module, action), param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Response<T?>> GetListofData<T>(object obj, string module, string action)
        {
            var response = new Response<T?>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                param = new DynamicParameters();
                param.AddDynamicParams(obj);

                SqlMapper.GridReader data = await con.QueryMultipleAsync(StoredProcedure.GetQueryName(module, action), param, commandType: CommandType.StoredProcedure);
                if (data != null)
                {
                    response.List = await data.ReadAsync<T>();
                    response.RecordCount = await data.ReadFirstOrDefaultAsync<int>();
                }
            }

            return response;
        }
    }
}
