using InfoShark.Helper;
using InfoShark.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Constants = InfoShark.Helper.Constants;

namespace InfoShark.Services
{
    public class GenericService : IGenericService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private ISession session => httpContextAccessor.HttpContext.Session;
        private LoggedUser loggedUser;

        private readonly GenericRepository genericRepository;

        public GenericService(IOptions<Config>? config,
            IHttpContextAccessor httpContextAccessor)
        {
            this.genericRepository = new GenericRepository(config?.Value?.ConnectionString);
            this.httpContextAccessor = httpContextAccessor;

            loggedUser = SessionHelper.GetJsonObject<LoggedUser>(session, "loggedUser");
        }


        public async Task<T?> AddUpdate<T>(object obj, string module, string action)
        {
            try
            {
                Library.TrySetProperty(obj, "ActionBy", loggedUser.Id);
                Library.TrySetProperty(obj, "ActionName", action);

                return await this.genericRepository.AddUpdate<T>(obj, module, action);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T?> Delete<T>(object obj, string module, string action)
        {
            try
            {
                Library.TrySetProperty(obj, "ActionBy", loggedUser.Id);
                Library.TrySetProperty(obj, "ActionName", action);

                return await this.genericRepository.Delete<T>(obj, module, action);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T?> GetFirstorDefault<T>(object obj, string module, string action)
        {
            try
            {
                return await this.genericRepository.GetFirstorDefault<T>(obj, module, action);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<IEnumerable<T?>> GetList<T>(string module, string action)
        {
            try
            {
                return await this.genericRepository.GetList<T>(module, action);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }

        public async Task<IEnumerable<T?>> GetListWithParam<T>(object obj, string module, string action)
        {
            try
            {
                return await this.genericRepository.GetListWithParam<T>(obj, module, action);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }

        public async Task<Response<T?>> GetListofData<T>(object obj, string module, string action)
        {
            Response<T?> response = new Response<T?>();
            try
            {
                response = await genericRepository.GetListofData<T>(obj, module, action);

                if (response?.List?.Count() > 0)
                {
                    response.Status = true;
                    response.Message = Constants.DataListGotItSuccessfully;
                }
                else
                {
                    response.Status = false;
                    response.Message = Constants.NotFoundData;
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
