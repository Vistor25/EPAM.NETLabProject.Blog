using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public void CreateNewUser(UserEntity u)
        {
            _userRepository.Create(u.ToDalUser());
            _unitOfWork.Commit();
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            return _userRepository.GetAll().Select(user => user.ToBLLUser());
        }

        public UserEntity GetUserByID(long id)
        {
            return _userRepository.GetById(id).ToBLLUser();
        }

        public UserEntity GetUserByLogin(string login)
        {
            return _userRepository.GetByLogin(login).ToBLLUser();
        }

        public bool IsFreeLogin(string login)
        {
            return ReferenceEquals(null, _userRepository.GetByLogin(login));
        }

        public void UpdateUser(long id, RoleEntity role)
        {
            _userRepository.UpdateUser(id, role.ToDalRole());
            _unitOfWork.Commit();
        }
    }
}