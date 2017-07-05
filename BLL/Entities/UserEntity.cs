using System.Collections.Generic;

namespace BLL.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            Articles = new List<ArticleEntity>();
            Roles = new List<RoleEntity>();
            Commnets = new List<CommentEntity>();
        }

        public long ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public List<ArticleEntity> Articles { get; set; }
        public List<RoleEntity> Roles { get; set; }
        public List<CommentEntity> Commnets { get; set; }
    }
}