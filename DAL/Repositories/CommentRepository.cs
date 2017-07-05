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
    public class CommentRepository : ICommentRepository
    {
        private readonly DbContext _context;

        public CommentRepository(DbContext context)
        {
            _context = context;
        }

        public DalComment Create(DalComment e)
        {
            return _context.Set<Comment>().Add(e.ToOrmComment()).ToDalComment();
        }

        public IEnumerable<DalComment> GetAll()
        {
            return _context.Set<Comment>().Select(comment => comment.ToDalComment());
        }

        public IEnumerable<DalComment> GetByCreationDate(long ArticleID)
        {
            throw new NotImplementedException();
        }

        public DalComment GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}