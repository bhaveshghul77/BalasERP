using BalasERP.Domain;
using InfoShark.Helper;
using InfoShark.Services;
using Microsoft.AspNetCore.Mvc;

namespace BalasERP.Web.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private ISession session => httpContextAccessor.HttpContext.Session;

        private readonly IGenericService iGenericService;
        private string module = "Login";

        public LoginController(IGenericService iGenericService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.iGenericService = iGenericService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("userlogin")]
        public async Task<IActionResult> UserLogin(LoginDTO loginDTO)
        {
            var response = new Response<UserModel>();
            if (ModelState.IsValid)
            {
                loginDTO.Password = Library.Encrypt(loginDTO.Password);
                UserModel? repo = await this.iGenericService.GetFirstorDefault<UserModel>(loginDTO, module);
                if (repo?.Id > 0)
                {
                    response.Status = true;
                    response.Message = Constants.LoginSuccessfully;
                    response.Data = repo;

                    #region Set Logged User Session
                    SessionHelper.SetJsonObject(httpContextAccessor.HttpContext.Session, "loggedUser", response.Data);
                    #endregion
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
                return View("index",loginDTO);
            }
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            if (HttpContext?.Session != null)
            {
                HttpContext.Session.Clear();
            }

            return RedirectToAction("Index", "login");
        }
    }
}
