using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork, ITagRepository tagRepository)
        {
            _unitOfWork = unitOfWork;
            _tagRepository = tagRepository;
        }

        public TagEntity Create(TagEntity e)
        {
            var tag = _tagRepository.Create(e.ToDalTag()).ToBLLTag();
            _unitOfWork.Commit();
            return tag;
        }

        public IEnumerable<TagEntity> GetAll()
        {
            return _tagRepository.GetAll().Select(comment => comment.ToBLLTag());
        }

        public TagEntity GetTagByName(string name)
        {
            return _tagRepository.GetTagByName(name).ToBLLTag();
        }

        public IEnumerable<ArticleEntity> GetArticlesByTag(string name)
        {
            return _tagRepository.GetArticlesByTag(name).Select(article => article.ToBllArticle());
        }
    }
}