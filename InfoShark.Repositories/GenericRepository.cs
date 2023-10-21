using Dapper;
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

        public Task<T?> AddUpdate<T>(object obj, string module, string action)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete<T>(object obj, string module, string action)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetFirstorDefault<T>(object obj, string module, string action)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                param = new DynamicParameters();
                param.AddDynamicParams(obj);

                return await con.QueryFirstOrDefaultAsync<T>("", param, commandType: CommandType.StoredProcedure);
            }
        }

        public Task<IEnumerable<T>?> GetList<T>(object obj, string module, string action)
        {
            throw new NotImplementedException();
        }
    }
}
