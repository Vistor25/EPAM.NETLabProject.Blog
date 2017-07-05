using System.Linq;
using DAL.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalMappers
    {
        public static DalUser ToDalUser(this User user)
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
                Comments = user.Comments.Select(item => item.ToDalComment()).ToList(),
                Roles = user.Roles.Select(item => item.ToDalRole()).ToList()
            };
        }

        public static User ToOrmUser(this DalUser user)
        {
            if (ReferenceEquals(user, null))
                return null;

            return new User
            {
                ID = user.ID,
                Login = user.Login,
                Password = user.Password,
                Nickname = user.Nickname,
                Articles = user.Articles.Select(item => item.ToOrmArticle()).ToList(),
                Comments = user.Comments.Select(item => item.ToOrmComment()).ToList(),
                Roles = user.Roles.Select(item => item.ToOrmRole()).ToList()
            };
        }

        public static DalArticle ToDalArticle(this Article article)
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
                Likes = article.UserLikes.Select(item => item.ToDalUser()).ToList(),
                Tags = article.Tags.Select(item => item.ToDalTag()).ToList()
            };
        }

        public static Article ToOrmArticle(this DalArticle article)
        {
            if (ReferenceEquals(article, null))
                return null;

            return new Article
            {
                ID = article.ID,
                Content = article.Content,
                CreationDate = article.CreationDate,
                Title = article.Title,
                UserID = article.UserID,
                Comments = article.Comments.Select(item => item.ToOrmComment()).ToList(),
                UserLikes = article.Likes.Select(item => item.ToOrmUser()).ToList(),
                Tags = article.Tags.Select(item => item.ToOrmTag()).ToList()
            };
        }

        public static Role ToOrmRole(this DalRole role)
        {
            if (ReferenceEquals(role, null))
                return null;

            return new Role
            {
                ID = role.ID,
                Name = role.Name
            };
        }

        public static DalRole ToDalRole(this Role role)
        {
            if (ReferenceEquals(role, null))
                return null;

            return new DalRole
            {
                ID = role.ID,
                Name = role.Name
            };
        }

        public static DalComment ToDalComment(this Comment comment)
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

        public static Comment ToOrmComment(this DalComment comment)
        {
            if (ReferenceEquals(comment, null))
                return null;

            return new Comment
            {
                ID = comment.ID,
                UserID = comment.UserID,
                CreationDate = comment.CreationDate,
                ArticleID = comment.ArticleID,
                Text = comment.Text
            };
        }

        public static DalTag ToDalTag(this Tag tag)
        {
            if (ReferenceEquals(tag, null))
                return null;

            return new DalTag
            {
                ID = tag.ID,
                Name = tag.Name
            };
        }

        public static Tag ToOrmTag(this DalTag tag)
        {
            if (ReferenceEquals(tag, null))
                return null;

            return new Tag
            {
                ID = tag.ID,
                Name = tag.Name
            };
        }
    }
}