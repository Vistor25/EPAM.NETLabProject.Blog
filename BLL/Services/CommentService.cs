using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork, ICommentRepository commentRepository)
        {
            _unitOfWork = unitOfWork;
            _commentRepository = commentRepository;
        }

        public void Create(CommentEntity e)
        {
            _commentRepository.Create(e.ToDalComment());
            _unitOfWork.Commit();
        }

        public IEnumerable<CommentEntity> GetAll()
        {
            return _commentRepository.GetAll().Select(comment => comment.ToBllComment());
        }
    }
}