using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces;
using mvcPL.Mappers;

namespace mvcPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IUserService _userService;
        //private UserEntity CurrentUser => _userService.GetUserByLogin(HttpContext.User.Identity.Name);

        public HomeController(IArticleService articleService, IUserService userService)
        {
            _articleService = articleService;
            _userService = userService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return
                View(
                    _articleService.GetAllArticles()
                        .Select(article => article.ToViewArticke(_userService.GetUserByID(article.UserID).Nickname)));
        }

        //public ActionResult View(int id)
        //{
        //    return RedirectToAction("View", "Article", new {id});
        //}
    }
}