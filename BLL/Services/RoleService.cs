using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
        }

        public RoleEntity CreateRole(RoleEntity role)
        {
            var newRole = _roleRepository.Create(role.ToDalRole()).ToBllRole();
            _unitOfWork.Commit();
            return newRole;
        }

        public IEnumerable<RoleEntity> GetAllRoles()
        {
            return _roleRepository.GetAll().Select(role => role.ToBllRole());
        }

        public RoleEntity GetRoleEntityByID(long id)
        {
            return _roleRepository.GetById(id).ToBllRole();
        }

        public RoleEntity GetRoleEntityByName(string name)
        {
            return _roleRepository.GetByName(name).ToBllRole();
        }
    }
}