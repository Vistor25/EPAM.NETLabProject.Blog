using System.Linq;
using BLL.Entities;
using DAL.DTO;

namespace BLL.Mappers
{
    public static class BLLMappers
    {
        public static UserEntity ToBLLUser(this DalUser user)
        {
            if (ReferenceEquals(user, null))
                return null;

            return new UserEntity
            {
                ID = user.ID,
                Login = user.Login,
                Password = user.Password,
                Nickname = user.Nickname,
                Articles = user.Articles.Select(item => item.ToBllArticle()).ToList(),
                Commnets = user.Comments.Select(item => item.ToBllComment()).ToList(),
                Roles = user.Roles.Select(item => item.ToBllRole()).ToList()
            };
        }

        public static DalUser ToDalUser(this UserEntity user)
        {
            if (ReferenceEquals(user, null))
                return null;

            return new DalUser
            {
                ID = user.ID,
                Login = user.Login,
                Password = user.Password,
                Nickname = user.Nickname,
                Articles = user.Articles.Select(item => item.ToDalArticle()).ToList(),
                Comments = user.Commnets.Select(item => item.ToDalComment()).ToList(),
                Roles = user.Roles.Select(item => item.ToDalRole()).ToList()
            };
        }

        public static ArticleEntity ToBllArticle(this DalArticle article)
        {
            if (ReferenceEquals(article, null))
                return null;

            return new ArticleEntity
            {
                ID = article.ID,
                Content = article.Content,
                CreationDate = article.CreationDate,
                Title = article.Title,
                UserID = article.UserID,
                Comments = article.Comments.Select(item => item.ToBllComment()).ToList(),
                Likes = article.Likes.Select(item => item.ToBLLUser()).ToList(),
                Tags = article.Tags.Select(item => item.ToBLLTag()).ToList()
            };
        }

        public static DalArticle ToDalArticle(this ArticleEntity article)
        {
            if (ReferenceEquals(article, null))
                return null;

            return new DalArticle
            {
                ID = article.ID,
                Content = article.Content,
                CreationDate = article.CreationDate,
                Title = article.Title,
                UserID = article.UserID,
                Comments = article.Comments.Select(item => item.ToDalComment()).ToList(),
                Likes = article.Likes.Select(item => item.ToDalUser()).ToList(),
                Tags = article.Tags.Select(item => item.ToDalTag()).ToList()
            };
        }

        public static DalRole ToDalRole(this RoleEntity role)
        {
            if (ReferenceEquals(role, null))
                return null;

            return new DalRole
            {
                ID = role.ID,
                Name = role.Name
            };
        }

        public static RoleEntity ToBllRole(this DalRole role)
        {
            if (ReferenceEquals(role, null))
                return null;

            return new RoleEntity
            {
                ID = role.ID,
                Name = role.Name
            };
        }

        public static DalTag ToDalTag(this TagEntity tag)
        {
            if (ReferenceEquals(tag, null))
                return null;

            return new DalTag
            {
                ID = tag.ID,
                Name = tag.Name
            };
        }

        public static TagEntity ToBLLTag(this DalTag tag)
        {
            if (ReferenceEquals(tag, null))
                return null;

            return new TagEntity
            {
                ID = (int) tag.ID,
                Name = tag.Name
            };
        }

        public static DalComment ToDalComment(this CommentEntity comment)
        {
            if (ReferenceEquals(comment, null))
                return null;

            return new DalComment
            {
                ID = comment.ID,
                UserID = comment.UserID,
                CreationDate = comment.CreationDate,
                ArticleID = comment.ArticleID,
                Text = comment.Text
            };
        }

        public static CommentEntity ToBllComment(this DalComment comment)
        {
            if (ReferenceEquals(comment, null))
                return null;

            return new CommentEntity
            {
                ID = comment.ID,
                UserID = comment.UserID,
                CreationDate = comment.CreationDate,
                ArticleID = comment.ArticleID,
                Text = comment.Text
            };
        }
    }
}