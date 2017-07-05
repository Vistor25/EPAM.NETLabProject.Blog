using System;

namespace DAL.DTO
{
    public class DalComment : IEntity
    {
        public string Text { get; set; }
        public long ArticleID { get; set; }
        public long UserID { get; set; }
        public DateTime CreationDate { get; set; }
        public long ID { get; set; }
    }
}