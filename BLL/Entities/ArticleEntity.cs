using System;
using System.Collections.Generic;

namespace BLL.Entities
{
    public class ArticleEntity
    {
        public ArticleEntity()
        {
            Comments = new List<CommentEntity>();
            Likes = new List<UserEntity>();
            Tags = new List<TagEntity>();
        }

        public long ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long UserID { get; set; }
        public DateTime CreationDate { get; set; }
        public List<CommentEntity> Comments { get; set; }
        public List<UserEntity> Likes { get; set; }
        public List<TagEntity> Tags { get; set; }
    }
}