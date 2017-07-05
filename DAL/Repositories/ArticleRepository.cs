using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DbContext _context;

        public ArticleRepository(DbContext context)
        {
            _context = context;
            if (_context == null)
                throw new ArgumentNullException();
        }

        public DalArticle Create(DalArticle e)
        {
            return _context.Set<Article>().Add(e.ToOrmArticle()).ToDalArticle();
        }

        public void DeleteArticle(long id)
        {
            _context.Set<Article>().Remove(_context.Set<Article>().FirstOrDefault(article => article.ID == id));
        }

        public IEnumerable<DalArticle> GetAll()
        {
            return _context.Set<Article>().ToList().Select(article => article.ToDalArticle());
        }

        /// <summary>
        ///     limit offset
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public DalArticle GetByCreationDate(int count)
        {
            return null; ///return _context.Set<Article>().Select(article => article.CreationDate);
        }

        public DalArticle GetById(long id)
        {
            var ORMArticle = _context.Set<Article>().FirstOrDefault(article => article.ID == id);
            return ORMArticle.ToDalArticle();
        }

        public IEnumerable<DalArticle> SearchArticlesByContent(string word)
        {
            return
                _context.Set<Article>()
                    .ToList()
                    .Where(article => article.Content.Contains(word))
                    .Select(article => article.ToDalArticle());
        }

        public IEnumerable<DalArticle> SearchArticlesByTag(string tag)
        {
            return _context.Set<Article>()
                .ToList()
                .Where(article => article.Tags.Any(t => t.Name == tag))
                .Select(a => a.ToDalArticle());
        }

        public void UpdateArticle(long id, string title, string content, IEnumerable<DalTag> tags)
        {
            var art = _context.Set<Article>().FirstOrDefault(article => article.ID == id);
            art.Title = title;
            art.Content = content;
            art.Tags = tags.Select(tag => tag.ToOrmTag()).ToList();
        }
    }
}