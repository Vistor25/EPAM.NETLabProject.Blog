using System;

namespace mvcPL.Models
{
    public class CommentModel
    {
        public long ID { get; set; }
        public string Text { get; set; }
        public long ArticleID { get; set; }
        public long UserID { get; set; }
        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}