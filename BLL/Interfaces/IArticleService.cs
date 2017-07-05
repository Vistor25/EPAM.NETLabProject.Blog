using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IArticleService
    {
        IEnumerable<ArticleEntity> GetAllArticles();
        void CreateArticle(ArticleEntity article);
        ArticleEntity GetArticleById(long id);
        IEnumerable<ArticleEntity> SearchArticlesByContent(string word);
        IEnumerable<ArticleEntity> SearchArticlesByTag(string tag);
        void UpdateArticle(long id, string title, string content, IEnumerable<TagEntity> tags);
        void DeleteArticle(long id);
    }
}