using System.Collections.Generic;
using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        TEntity Create(TEntity e);
    }
}