using BalasERP.Domain;
using InfoShark.Helper;
using InfoShark.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Constants = InfoShark.Helper.Constants;

namespace BalasERP.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IGenericService iGenericService;
        private string module = "User";
        private Pagination pagination;

        public UserController(IGenericService iGenericService)
        {
            this.iGenericService = iGenericService;
        }



        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddUpdate()
        {
            ViewBag.State = await iGenericService.GetList<StateModel>("State");
            ViewBag.UserGroup = await iGenericService.GetList<UserGroupModel>("Group");

            return View(new UserModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddUpdate(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var response = new Response<UserModel>();

                model.Password = Library.Encrypt(model.Password);
                UserModel? repo = await this.iGenericService.AddUpdate<UserModel>(model, module);

                if (repo?.ResponseCode > 0)
                {
                    response.Status = true;
                    response.Message = repo?.ResponseCode == 1 ?
                        Constants.InsertedSuccessfully :
                        Constants.UpdatedSuccessfully;
                    response.Data = repo;
                }
                else
                {
                    response.Status = false;
                    response.Message = Constants.SomethingWentWrong;
                }

                return Json(response);
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> GetById(int id)
        {
            var response = new Response<UserModel>();

            UserModel? repo = await iGenericService.GetFirstorDefault<UserModel>(new UserModel() { Id = id }, module);

            if (repo?.Id > 0)
            {
                ViewBag.State = await iGenericService.GetList<StateModel>("State");
                ViewBag.UserGroup = await iGenericService.GetList<UserGroupModel>("Group");

                repo.Password = Library.Decrypt(repo.Password);
                return View("AddUpdate", repo);
            }
            else
            {
                response.Status = false;
                response.Message = Constants.SomethingWentWrong;

                return Json(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new Response<UserModel>();

            UserModel? repo = await iGenericService.Delete<UserModel>(new UserModel() { Id = id }, module);

            if (repo?.ResponseCode > 0)
            {
                response.Status = true;
                response.Message = Constants.DeleteSuccessfully;
            }
            else
            {
                response.Status = false;
                response.Message = Constants.SomethingWentWrong;
            }

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> GetListofData()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            pagination = new Pagination()
            {
                PageNo = Convert.ToInt32(HttpContext.Request.Form["start"].FirstOrDefault()),
                PageSize = Convert.ToInt32(HttpContext.Request.Form["length"].FirstOrDefault()),
                SortField = HttpContext.Request.Form["columns[" + HttpContext.Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(),
                SortOrder = HttpContext.Request.Form["order[0][dir]"].FirstOrDefault(),
                KeyWord = HttpContext.Request.Form["search[value]"].FirstOrDefault(),
            };
            pagination.PageNo = pagination.PageNo == 0 ? 1 : ((pagination.PageNo / pagination.PageSize) + 1);

            Response<UserModel?> response = await this.iGenericService.GetListofData<UserModel>(pagination, module);
            if (response?.Status == true)
            {
                int? recordsTotal = 0;
                if (response?.List?.Any() == true)
                {
                    recordsTotal = response.RecordCount;
                }

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = response?.List, statusCode = response?.Status, message = response?.Message, moduleName = module });
            }

            return Json(new { draw = HttpContext.Request.Form["draw"].FirstOrDefault(), recordsFiltered = 0, recordsTotal = 0, data = new List<UserModel>(), statusCode = response?.Status, message = response?.Message, moduleName = module });
        }

        [HttpPost]
        public async Task<JsonResult> GetCityListByStateId(int stateId)
        {
            var response = new Response<CityModel?>();

            var pairs = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("Id", stateId),
            };

            IEnumerable<CityModel?> cities = await iGenericService.GetListWithParam<CityModel>(pairs, "City");

            if (cities?.Count() > 0)
            {
                response.Status = true;
                response.Message = Constants.DataListGotItSuccessfully;
                response.List = cities;
            }
            else
            {
                response.Status = false;
                response.Message = Constants.SomethingWentWrong;
                response.List = cities;
            }

            return Json(response);
        }
    }
}
