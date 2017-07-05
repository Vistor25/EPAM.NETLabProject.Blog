using System.Collections.Generic;

namespace DAL.DTO
{
    public class DalUser : IEntity
    {
        public DalUser()
        {
            Articles = new List<DalArticle>();
            Roles = new List<DalRole>();
            Comments = new List<DalComment>();
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public List<DalArticle> Articles { get; set; }
        public List<DalRole> Roles { get; set; }
        public List<DalComment> Comments { get; set; }

        public long ID { get; set; }
    }
}