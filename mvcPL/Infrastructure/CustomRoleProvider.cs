using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using BLL.Entities;
using BLL.Interfaces;
using Ninject;

namespace mvcPL.Infrastructure
{
    public class CustomRoleProvider : RoleProvider
    {
        private readonly NinjectDependencyResolver dependencyResolver =
            new NinjectDependencyResolver(new StandardKernel());

        private IUserService userService
            => (IUserService) dependencyResolver.GetService(typeof(IUserService));

        private IRoleService roleService
            => (IRoleService) dependencyResolver.GetService(typeof(IRoleService));


        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var user = userService.GetUserByLogin(username);

            if (ReferenceEquals(user, null)) return null;

            var roles = new string[user.Roles.Count];

            for (var i = 0; i < user.Roles.Count; i++)
                roles[i] = user.Roles.ElementAt(i).Name;

            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var userRole = roleService.GetRoleEntityByName(roleName);

            var user = userService.GetUserByLogin(username);

            if (ReferenceEquals(user, null)) return false;

            if (!ReferenceEquals(userRole, null) && user.Roles.Contains(userRole, new RoleCompare()))
                return true;

            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        internal class RoleCompare : IEqualityComparer<RoleEntity>
        {
            public bool Equals(RoleEntity x, RoleEntity y)
            {
                return x.Name.Equals(y.Name, StringComparison.InvariantCultureIgnoreCase);
            }

            public int GetHashCode(RoleEntity role)
            {
                return role.Name.GetHashCode() * role.ID.GetHashCode();
            }
        }
    }
}