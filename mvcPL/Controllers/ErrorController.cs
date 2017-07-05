using System.Web.Mvc;

namespace mvcPL.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }

        //public ActionResult NotFound() => View();

        public ActionResult Error() => View();

        //public ActionResult NotCompleteTest() => View();

        //public ActionResult ServerError() => View();
    }
}