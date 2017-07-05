using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByLogin(string login);
        void UpdateUser(long id, DalRole role);
    }
}