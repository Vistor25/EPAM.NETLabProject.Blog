using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface ITagService
    {
        TagEntity Create(TagEntity e);
        IEnumerable<TagEntity> GetAll();
        TagEntity GetTagByName(string name);
        IEnumerable<ArticleEntity> GetArticlesByTag(string name);
    }
}