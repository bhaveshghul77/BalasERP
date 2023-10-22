using InfoShark.Helper;

namespace InfoShark.Services
{
    public interface IGenericService
    {
        Task<T?> AddUpdate<T>(object obj, string module, string action = "AddEdit");

        Task<T?> Delete<T>(object obj, string module, string action = "Delete");

        Task<T?> GetFirstorDefault<T>(object obj, string module,string action = "FirstorDefault");

        Task<IEnumerable<T?>> GetList<T>(string module, string action = "GetList");

        Task<IEnumerable<T?>> GetListWithParam<T>(object obj, string module, string action = "GetListWithParam");

        Task<Response<T?>> GetListofData<T>(object obj, string module, string action = "GetListofData");
    }
}
