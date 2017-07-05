using System;
using System.Collections.Generic;

namespace DAL.DTO
{
    public class DalArticle : IEntity
    {
        public DalArticle()
        {
            Comments = new List<DalComment>();
            Likes = new List<DalUser>();
            Tags = new List<DalTag>();
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public long UserID { get; set; }
        public DateTime CreationDate { get; set; }
        public List<DalComment> Comments { get; set; }
        public List<DalUser> Likes { get; set; }
        public List<DalTag> Tags { get; set; }

        public long ID { get; set; }
    }
}