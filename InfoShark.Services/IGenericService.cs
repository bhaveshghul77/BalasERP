using InfoShark.Helper;

namespace InfoShark.Services
{
    public interface IGenericService
    {
        Task<Response<T>> AddEdit<T>(object obj, string module, string action = "AddEdit");

        Task<Response<T>> Delete<T>(object obj, string module, string action = "Delete");

        Task<Response<T>> GetFirstorDefault<T>(object obj, string module,string action = "FirstorDefault");

        Task<Response<T>> GetList<T>(object obj, string module, string action = "GetList");
    }
}
