using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        DalRole GetByName(string name);
    }
}