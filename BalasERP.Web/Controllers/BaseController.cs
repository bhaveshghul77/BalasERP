using InfoShark.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BalasERP.Web.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionName = Convert.ToString(RouteData.Values["action"]).ToLower();
            var controllerName = Convert.ToString(RouteData.Values["controller"]).ToLower();

            LoggedUser loggedUser = SessionHelper.GetJsonObject<LoggedUser>(HttpContext.Session, "loggedUser");

            if (controllerName != "error")
            {
                if (controllerName != "login" && controllerName != "home")
                {
                    if (loggedUser == null)
                    {
                        if (controllerName == "account" && (actionName == "index" || actionName == "forgotpassword"))
                        {
                            return;
                        }
                        else
                        {
                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{
                                { "controller", "login" },
                                { "action", "index" }
                            });
                        }
                    }
                }
                else if (controllerName == "home")
                {
                    if (loggedUser == null)
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{
                            { "controller", "login" },
                            { "action", "index" }
                        });
                    }
                }
                else if (loggedUser != null && controllerName == "login" && actionName == "index")
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{
                        { "controller", "home" },
                        { "action", "index" }
                    });
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
