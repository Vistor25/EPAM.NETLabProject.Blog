using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Mappers;
using ORM;

namespace DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext _context;

        public RoleRepository(DbContext context)
        {
            _context = context;
        }

        public DalRole Create(DalRole e)
        {
            return _context.Set<Role>().Add(e.ToOrmRole()).ToDalRole();
        }

        public IEnumerable<DalRole> GetAll()
        {
            return _context.Set<Role>().Select(article => article.ToDalRole());
        }

        public DalRole GetById(long id)
        {
            return _context.Set<Role>().FirstOrDefault(role => role.ID == id).ToDalRole();
        }

        public DalRole GetByName(string name)
        {
            return _context.Set<Role>().FirstOrDefault(role => role.Name == name).ToDalRole();
        }
    }
}