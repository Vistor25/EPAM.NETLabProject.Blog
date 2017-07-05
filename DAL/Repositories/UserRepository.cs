using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Mappers;
using Ninject.Infrastructure.Language;
using ORM;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public DalUser Create(DalUser e)
        {
            return _context.Set<User>().Add(e.ToOrmUser()).ToDalUser();
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _context.Set<User>().Select(user => user.ToDalUser()).ToEnumerable();
        }

        public DalUser GetById(long id)
        {
            var ORMuser = _context.Set<User>().FirstOrDefault(user => user.ID == id);
            return ORMuser.ToDalUser();
        }

        public DalUser GetByLogin(string login)
        {
            var ORMuser = _context.Set<User>().FirstOrDefault(user => user.Login == login);
            return ORMuser.ToDalUser();
        }

        public void UpdateUser(long id, DalRole role)
        {
            var ORmUser = _context.Set<User>().FirstOrDefault(user => user.ID == id);
            ORmUser.Roles.Add(role.ToOrmRole());
        }
    }
}