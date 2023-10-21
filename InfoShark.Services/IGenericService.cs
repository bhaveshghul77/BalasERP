using InfoShark.Helper;

namespace InfoShark.Services
{
    public interface IGenericService
    {
        Task<Response<T>> AddUpdate<T>(object obj, string module, string action = "AddUpdate");

        Task<Response<T>> Delete<T>(object obj, string module, string action = "Delete");

        Task<Response<T>> GetFirstorDefault<T>(object obj, string module,string action = "FirstorDefault");

        Task<Response<T>> GetList<T>(object obj, string module, string action = "GetList");
    }
}
