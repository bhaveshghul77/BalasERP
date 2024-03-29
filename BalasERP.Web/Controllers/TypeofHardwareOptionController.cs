﻿using BalasERP.Domain;
using InfoShark.Helper;
using InfoShark.Services;
using Microsoft.AspNetCore.Mvc;

namespace BalasERP.Web.Controllers
{
    public class TypeofHardwareOptionController : Controller
    {
        private readonly IGenericService iGenericService;
        private string module = "TypeofHardwareOption";
        private Pagination pagination;

        public TypeofHardwareOptionController(IGenericService iGenericService)
        {
            this.iGenericService = iGenericService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddUpdate()
        {
            ViewBag.TypeofHardwares = await iGenericService.GetList<TypeofHardwareModel>("TypeofHardware");
            return View(new TypeofHardwareOptionModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddUpdate(TypeofHardwareOptionModel model)
        {
            if (ModelState.IsValid)
            {
                var response = new Response<TypeofHardwareOptionModel>();

                TypeofHardwareOptionModel? repo = await this.iGenericService.AddUpdate<TypeofHardwareOptionModel>(model, module);

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
            var response = new Response<TypeofHardwareOptionModel>();

            ViewBag.TypeofHardwares = await iGenericService.GetList<TypeofHardwareModel>("TypeofHardware");

            TypeofHardwareOptionModel? repo = await iGenericService.GetFirstorDefault<TypeofHardwareOptionModel>(new TypeofHardwareOptionModel() { Id = id }, module);

            if (repo?.Id > 0)
            {
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
            var response = new Response<TypeofHardwareOptionModel>();

            ViewBag.TypeofBackdatas = await iGenericService.GetList<TypeofHardwareModel>("TypeofHardware");

            TypeofHardwareOptionModel? repo = await iGenericService.Delete<TypeofHardwareOptionModel>(new TypeofHardwareOptionModel() { Id = id }, module);

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

            Response<TypeofHardwareOptionModel?> response = await this.iGenericService.GetListofData<TypeofHardwareOptionModel>(pagination, module);
            if (response?.Status == true)
            {
                int? recordsTotal = 0;
                if (response?.List?.Any() == true)
                {
                    recordsTotal = response.RecordCount;
                }

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = response?.List, statusCode = response?.Status, message = response?.Message, moduleName = module });
            }

            return Json(new { draw = HttpContext.Request.Form["draw"].FirstOrDefault(), recordsFiltered = 0, recordsTotal = 0, data = new List<TypeofHardwareOptionModel>(), statusCode = response?.Status, message = response?.Message, moduleName = module });
        }
    }
}
