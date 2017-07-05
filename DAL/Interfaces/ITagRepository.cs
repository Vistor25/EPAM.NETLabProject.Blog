using System.Collections.Generic;
using DAL.DTO;

namespace DAL.Interfaces
{
    public interface ITagRepository : IRepository<DalTag>
    {
        DalTag GetTagByName(string name);
        IEnumerable<DalArticle> GetArticlesByTag(string name);
    }
}