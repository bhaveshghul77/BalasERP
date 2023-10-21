using InfoShark.Helper;
using InfoShark.Repositories;
using Microsoft.Extensions.Options;

namespace InfoShark.Services
{
    public class GenericService : IGenericService
    {
        private readonly GenericRepository genericRepository;

        public GenericService(IOptions<Config>? config)
        {
            this.genericRepository = new GenericRepository(config?.Value?.ConnectionString);
        }


        public Task<Response<T>> AddEdit<T>(object obj, string module, string action)
        {
            throw new NotImplementedException();
        }

        public Task<Response<T>> Delete<T>(object obj, string module, string action)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<T>> GetFirstorDefault<T>(object obj, string module, string action)
        {
            try
            {
                await this.genericRepository.GetFirstorDefault<T>(null, "", action);
            }
            catch (Exception ex)
            {

                throw;
            }

            return new Response<T>();
        }

        public Task<Response<T>> GetList<T>(object obj, string module, string action)
        {
            throw new NotImplementedException();
        }
    }
}
