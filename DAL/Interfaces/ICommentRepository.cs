using System.Collections.Generic;
using DAL.DTO;

namespace DAL.Interfaces
{
    public interface ICommentRepository : IRepository<DalComment>
    {
        IEnumerable<DalComment> GetByCreationDate(long ArticleID);
    }
}