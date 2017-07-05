using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Entities;
using BLL.Interfaces;
using mvcPL.Mappers;
using mvcPL.Models;

namespace mvcPL.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commnetService;
        private readonly ITagService _tagService;
        private readonly IUserService _userService;

        public ArticleController(IArticleService articleService, IUserService userService, ITagService tagService,
            ICommentService commentService)
        {
            _userService = userService;
            _articleService = articleService;
            _tagService = tagService;
            _commnetService = commentService;
        }

        private UserEntity CurrentUser => _userService.GetUserByLogin(HttpContext.User.Identity.Name);

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ArticleCreateModel article)
        {
            if (ModelState.IsValid)
            {
                var tags = new List<TagEntity>();

                foreach (var tagName in article.Tags.Split(',').Select(tag => tag.Trim()))
                {
                    var tag = _tagService.GetTagByName(tagName);

                    if (ReferenceEquals(tag, null))
                        tag = _tagService.Create(new TagEntity {Name = tagName});

                    tags.Add(tag);
                }

                article.CreationDate = DateTime.Now;
                _articleService.CreateArticle(article.ToBllArticke(CurrentUser.ID, tags));

                return RedirectToAction("Index", "Home");
            }

            return View(article);
        }

        [HandleError]
        public ActionResult View(long id)
        {
            var comments =
                _articleService.GetArticleById(id)
                    .Comments.Select(comment => comment.ToMVCComment(_userService.GetUserByID(comment.UserID).Nickname));
            var article = _articleService.GetArticleById(id);
            var user = _userService.GetUserByID(article.UserID);
            var mvcArticle = article.ToMVCArticle();
            mvcArticle.Tags = article.Tags;
            mvcArticle.UserName = user.Login;
            mvcArticle.Comments = new List<CommentModel>(comments);
            return View(mvcArticle);
        }

        [Authorize]
        public ActionResult AddComment(long id, string text)
        {
            var commentEntity = new CommentEntity
            {
                CreationDate = DateTime.Now,
                ArticleID = id,
                Text = text,
                UserID = CurrentUser.ID
            };
            _commnetService.Create(commentEntity);
            var commentModel = commentEntity.ToMVCComment(CurrentUser.Nickname);
            return PartialView("_Comment", commentModel);
        }

        public ActionResult Search(string partOfTheContent)
        {
            return
                View(
                    _articleService.SearchArticlesByContent(partOfTheContent.Trim())
                        .Select(article => article.ToViewArticke(_userService.GetUserByID(article.UserID).Nickname)));
        }

        public ActionResult SerchByTag(string tag)
        {
            return
                View("Search",
                    _articleService.SearchArticlesByTag(tag)
                        .Select(article => article.ToViewArticke(_userService.GetUserByID(article.UserID).Nickname)));
        }

        [Authorize]
        public ActionResult Edit(long id)
        {
            var article = _articleService.GetArticleById(id);
            var user = _userService.GetUserByLogin(User.Identity.Name);
            if (User.IsInRole("Admin") || article.UserID == user.ID)
                return View(article.ToArticleCreateModel());
            return RedirectToAction("Forbidden", "Error");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleCreateModel article)
        {
            var tags = new List<TagEntity>();

            foreach (var tagName in article.Tags.Split(',').Select(tag => tag.Trim()))
            {
                var tag = _tagService.GetTagByName(tagName);

                if (ReferenceEquals(tag, null))
                    tag = _tagService.Create(new TagEntity {Name = tagName});

                tags.Add(tag);
            }
            _articleService.UpdateArticle(article.ID, article.Title, article.Content, tags);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Delete(long id)
        {
            var article = _articleService.GetArticleById(id);
            var user = _userService.GetUserByLogin(User.Identity.Name);
            if (User.IsInRole("Admin") || article.UserID == user.ID)
            {
                _articleService.DeleteArticle(id);
                return RedirectToAction("Index", "Home");
            }
                
            return RedirectToAction("Forbidden", "Error");
          }
    }
}