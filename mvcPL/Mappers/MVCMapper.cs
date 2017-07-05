using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using BLL.Entities;
using mvcPL.Models;

namespace mvcPL.Mappers
{
    public static class MVCMapper
    {
        public static ArticlesListModel ToViewArticke(this ArticleEntity article, string userName)
        {
            if (article.Content.Length > 200)
            {
                article.Content = article.Content.Substring(0, 200) + "...";
            }
            return new ArticlesListModel
            {
                Id = article.ID,
                CreationDate = article.CreationDate.ToString("D"),
                Title = article.Title,
                Content = article.Content,
                UserName = userName
            };
        }

        public static ArticleEntity ToBllArticke(this ArticleCreateModel article, long userId, List<TagEntity> tags)
        {
            return new ArticleEntity
            {
                CreationDate = article.CreationDate,
                Title = article.Title,
                Content = article.Content,
                Tags = tags,
                UserID = userId,
                ID = article.ID
            };
        }

        public static ArticleCreateModel ToArticleCreateModel(this ArticleEntity article)
        {
            return new ArticleCreateModel
            {
                Title = article.Title,
                Content = article.Content,
                CreationDate = article.CreationDate,
                UserId = article.UserID,
                Tags = string.Join(",", article.Tags.Select(tag => tag.Name.ToString()))
            };
        }

        public static CommentEntity ToBllComment(this CommentModel comment)
        {
            return new CommentEntity
            {
                ID = comment.ID,
                ArticleID = comment.ArticleID,
                Text = comment.Text,
                UserID = comment.UserID,
                CreationDate = comment.CreationDate
            };
        }

        public static CommentModel ToMVCComment(this CommentEntity comment, string userName)
        {
            return new CommentModel
            {
                ID = comment.ID,
                ArticleID = comment.ArticleID,
                Text = comment.Text,
                UserID = comment.UserID,
                CreationDate = comment.CreationDate,
                UserName = userName
            };
        }

        public static ArticleVewModel ToMVCArticle(this ArticleEntity article)
        {
            return new ArticleVewModel
            {
                ID = article.ID,
                CreationDate = article.CreationDate,
                UserID = article.UserID,
                Content = article.Content,
                Title = article.Title,
                Comments = new List<CommentModel>()
            };
        }

        public static ProfileModel ToMVCuser(this UserEntity user)
        {
            return new ProfileModel
            {
                Nickname = user.Nickname,
                Login = user.Login,
                ID = user.ID
            };
        }
    }
}