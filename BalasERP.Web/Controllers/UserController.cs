using BalasERP.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BalasERP.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUpdate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUpdate(UserModel model)
        {
            return View();
        }
    }
}
