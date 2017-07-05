using System.Collections.Generic;
using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IArticleRepository : IRepository<DalArticle>
    {
        DalArticle GetByCreationDate(int count);
        IEnumerable<DalArticle> SearchArticlesByContent(string word);
        IEnumerable<DalArticle> SearchArticlesByTag(string tag);
        void UpdateArticle(long id, string title, string content, IEnumerable<DalTag> tags);
        void DeleteArticle(long id);
    }
}