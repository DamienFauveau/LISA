using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace BackOffice.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class ConnexionVerificationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var token = filterContext.HttpContext.Session["token"];
            if(token == null)
            {
                var routeValues = new RouteValueDictionary(new
                {
                    action = "Connexion",
                    controller = "Login"
                });
                filterContext.Result = new RedirectToRouteResult(routeValues);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}