using BalasERP.Domain;
using BalasERP.Domain.City;
using BalasERP.Domain.UserGroup;
using IBookedOnline.Domain;
using InfoShark.Helper;
using InfoShark.Services;
using Microsoft.AspNetCore.Mvc;

namespace BalasERP.Web.Controllers
{
    public class UserRightController : Controller
    {
        private readonly IGenericService iGenericService;
        private string module = "UserRight";
        private Pagination pagination;

        public UserRightController(IGenericService iGenericService)
        {
            this.iGenericService = iGenericService;
        }



        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddUpdate()
        {
            ViewBag.Users = await iGenericService.GetList<UserModel>("User");

            return View(new UserRightModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddUpdate(UserRightModel model)
        {
            if (ModelState.IsValid)
            {
                var response = new Response<UserRightModel>();

                UserRightModel? repo = await this.iGenericService.AddUpdate<UserRightModel>(model, module);

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
            var response = new Response<UserRightModel>();

            UserRightModel? repo = await iGenericService.GetFirstorDefault<UserRightModel>(new UserRightModel() { Id = id }, module);

            if (repo?.Id > 0)
            {
                ViewBag.Users = await iGenericService.GetList<UserModel>("User");

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
            var response = new Response<UserRightModel>();

            UserRightModel? repo = await iGenericService.Delete<UserRightModel>(new UserRightModel() { Id = id }, module);

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

            Response<UserRightModel?> response = await this.iGenericService.GetListofData<UserRightModel>(pagination, module);
            if (response?.Status == true)
            {
                int? recordsTotal = 0;
                if (response?.List?.Any() == true)
                {
                    recordsTotal = response.RecordCount;
                }

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = response?.List, statusCode = response?.Status, message = response?.Message, moduleName = module });
            }

            return Json(new { draw = HttpContext.Request.Form["draw"].FirstOrDefault(), recordsFiltered = 0, recordsTotal = 0, data = new List<UserRightModel>(), statusCode = response?.Status, message = response?.Message, moduleName = module });
        }

        [HttpPost]
        public async Task<JsonResult> GetGroupListByUserId(int userId)
        {
            var response = new Response<UserGroupModel?>();

            var pairs = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("Id", userId),
            };

            IEnumerable<UserGroupModel?> groups = await iGenericService.GetListWithParam<UserGroupModel>(pairs, "Group");

            if (groups?.Count() > 0)
            {
                response.Status = true;
                response.Message = Constants.DataListGotItSuccessfully;
                response.List = groups;
            }
            else
            {
                response.Status = false;
                response.Message = Constants.SomethingWentWrong;
                response.List = groups;
            }

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> GetMenuListByGroupId(int groupId)
        {
            var response = new Response<UserMenuModel?>();

            var pairs = new List<KeyValuePair<string, dynamic>>()
            {
                new KeyValuePair<string, dynamic>("Id", groupId),
            };

            IEnumerable<UserMenuModel?> menus = await iGenericService.GetListWithParam<UserMenuModel>(pairs, "Menu");

            if (menus?.Count() > 0)
            {
                response.Status = true;
                response.Message = Constants.DataListGotItSuccessfully;
                response.List = menus;
            }
            else
            {
                response.Status = false;
                response.Message = Constants.SomethingWentWrong;
                response.List = menus;
            }

            return Json(response);
        }
    }
}
