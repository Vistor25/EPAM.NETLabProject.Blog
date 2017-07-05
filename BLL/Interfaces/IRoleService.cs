using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        RoleEntity CreateRole(RoleEntity role);
        RoleEntity GetRoleEntityByName(string name);
        IEnumerable<RoleEntity> GetAllRoles();
        RoleEntity GetRoleEntityByID(long id);
    }
}