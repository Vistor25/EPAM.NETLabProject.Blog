using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        UserEntity GetUserByID(long id);
        void CreateNewUser(UserEntity u);
        UserEntity GetUserByLogin(string login);
        IEnumerable<UserEntity> GetAllUsers();
        bool IsFreeLogin(string login);
        void UpdateUser(long id, RoleEntity role);
    }
}