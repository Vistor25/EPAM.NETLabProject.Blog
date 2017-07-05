using System;
using System.Collections.Generic;
using BLL.Entities;

namespace mvcPL.Models
{
    public class ArticleVewModel
    {
        public ArticleVewModel()
        {
            Comments = new List<CommentModel>();
            Likes = new List<UserEntity>();
            Tags = new List<TagEntity>();
        }

        public long ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long UserID { get; set; }
        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<UserEntity> Likes { get; set; }
        public List<TagEntity> Tags { get; set; }
    }
}