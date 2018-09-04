using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DunlyStad_Web.Controllers;
using DunlyStad_Web.Code.Helpers;

namespace DunlyStad_Web.Code.Filters
{
    public class BackofficeLoginFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            Controller controller = filterContext.Controller as Controller;

            BackofficeUser bou = SessionHelper.Get<BackofficeUser>("bou");

            if (bou != null )
            {
                BackofficeHelper boh = new BackofficeHelper();

                Callback cb = boh.isUserLoggedIn(bou);
                if( !cb.success)
                {
                    controller.HttpContext.Response.Redirect("/backoffice/login");
                    filterContext.Result = new EmptyResult();
                }
            }
            else
            {
                controller.HttpContext.Response.Redirect("/backoffice/login");
                filterContext.Result = new EmptyResult();
            }

            this.OnActionExecuting(filterContext);
        }
    }


}