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
    public class TagRepository : ITagRepository
    {
        private readonly DbContext _context;

        public TagRepository(DbContext context)
        {
            _context = context;
        }

        public DalTag Create(DalTag e)
        {
            return _context.Set<Tag>().Add(e.ToOrmTag()).ToDalTag();
        }

        public DalTag GetTagByName(string name)
        {
            return _context.Set<Tag>()
                .FirstOrDefault(tag => tag.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).ToDalTag();
        }

        public IEnumerable<DalTag> GetAll()
        {
            return _context.Set<Tag>().Select(tag => tag.ToDalTag());
        }

        public DalTag GetById(long id)
        {
            return _context.Set<Tag>()
                .FirstOrDefault(tag => tag.ID == id).ToDalTag();
        }

        public IEnumerable<DalArticle> GetArticlesByTag(string name)
        {
            var tag = _context.Set<Tag>().FirstOrDefault(t => t.Name.Contains(name));
            return tag.Articles.Select(article => article.ToDalArticle());
        }
    }
}