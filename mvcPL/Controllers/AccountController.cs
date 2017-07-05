using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces;
using mvcPL.Infrastructure;
using mvcPL.Mappers;
using mvcPL.Models;

namespace mvcPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public AccountController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public ActionResult Register()
        {
            return View("RegistrationView");
        }


        public ActionResult Login(string returnUrl)
        {
            return View("LoginView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogInModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.LogIn, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.LogIn, viewModel.RememberMe);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login or password!");
            }
            return View("LoginView", viewModel);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();

                var isUserCreated = ((CustomUserMembershipProvider) Membership.Provider)
                    .CreateUser(viewModel.Nickname, viewModel.Login, viewModel.Password);

                if (isUserCreated)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Login, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "This login has been already taken!");

                ModelState.AddModelError("", "Error registration.");
            }
            return View("RegistrationView", viewModel);
        }

        public ActionResult UserProfile(string name)
        {
            return View("View", _userService.GetUserByLogin(name).ToMVCuser());
        }

        public ActionResult AddRole(long id, string rolename)
        {
            var role = _roleService.GetRoleEntityByName(rolename);
            _userService.UpdateUser(id, role);
            if (User.IsInRole("Admin"))
            {
                return View("View", _userService.GetUserByID(id).ToMVCuser());
            }
            return RedirectToAction("Forbidden", "Error");
        }
    }
}