using Microsoft.AspNetCore.Mvc;

namespace BalasERP.Web.Controllers
{
	public class AccountController : BaseController
    {
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ForgotPassword()
		{
			return View();
		}
    }
}
