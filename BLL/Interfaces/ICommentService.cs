using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        void Create(CommentEntity e);
        IEnumerable<CommentEntity> GetAll();
    }
}