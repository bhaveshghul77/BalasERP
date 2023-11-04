using InfoShark.Services;
using Microsoft.AspNetCore.Mvc;

namespace BalasERP.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IGenericService iGenericService;

        public HomeController(IGenericService iGenericService)
        {
            this.iGenericService = iGenericService;
        }

        public async Task<IActionResult> Index()
        {
            //await this.iGenericService.GetFirstorDefault<Object>(null, "");
            return View();
        }
    }
}