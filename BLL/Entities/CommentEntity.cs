using System;

namespace BLL.Entities
{
    public class CommentEntity
    {
        public long ID { get; set; }
        public string Text { get; set; }
        public long ArticleID { get; set; }
        public long UserID { get; set; }
        public DateTime CreationDate { get; set; }
    }
}