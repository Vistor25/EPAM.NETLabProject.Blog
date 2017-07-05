using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork, IArticleRepository articleRepository)
        {
            _unitOfWork = unitOfWork;
            _articleRepository = articleRepository;
        }

        public IEnumerable<ArticleEntity> GetAllArticles()
        {
            return _articleRepository.GetAll().Select(article => article.ToBllArticle());
        }

        public void CreateArticle(ArticleEntity article)
        {
            _articleRepository.Create(article.ToDalArticle());
            _unitOfWork.Commit();
        }

        public ArticleEntity GetArticleById(long id)
        {
            return _articleRepository.GetById(id).ToBllArticle();
        }

        public IEnumerable<ArticleEntity> SearchArticlesByContent(string word)
        {
            return _articleRepository.SearchArticlesByContent(word).Select(article => article.ToBllArticle());
        }

        public IEnumerable<ArticleEntity> SearchArticlesByTag(string tag)
        {
            return _articleRepository.SearchArticlesByTag(tag).Select(article => article.ToBllArticle());
        }

        public void UpdateArticle(long id, string title, string content, IEnumerable<TagEntity> tags)
        {
            _articleRepository.UpdateArticle(id, title, content, tags.Select(tag => tag.ToDalTag()));
            _unitOfWork.Commit();
        }

        public void DeleteArticle(long id)
        {
            _articleRepository.DeleteArticle(id);
            _unitOfWork.Commit();
        }
    }
}