﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvcPL
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    Response.Clear();

        //    HttpException httpException = exception as HttpException;

        //    if (httpException != null)
        //    {

        //        string serverError = @"^5\d{2}$";
        //        if (httpException.GetHttpCode().ToString() == "404")
        //            Response.Redirect(String.Format("~/Error/NotFound/?message={0}", exception.Message));
        //        if (Regex.IsMatch(httpException.GetHttpCode().ToString(), serverError, RegexOptions.IgnoreCase))
        //            Response.Redirect(String.Format("~/Error/ServerError/?message={0}", exception.Message));
        //        else
        //            Response.Redirect(String.Format("~/Error/Error/?message={0}", exception.Message));
        //        Server.ClearError();

        //    }
        //}
    }
}