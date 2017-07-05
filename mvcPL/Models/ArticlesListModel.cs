namespace mvcPL.Models
{
    public class ArticlesListModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string CreationDate { get; set; }
    }
}