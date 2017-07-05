using System;
using System.Web.Helpers;
using System.Web.Security;
using BLL.Entities;
using BLL.Interfaces;
using Ninject;

namespace mvcPL.Infrastructure
{
    public class CustomUserMembershipProvider : MembershipProvider
    {
        private readonly NinjectDependencyResolver dependencyResolver =
            new NinjectDependencyResolver(new StandardKernel());

        private IUserService userService
            => (IUserService) dependencyResolver.GetService(typeof(IUserService));

        private IRoleService roleService
            => (IRoleService) dependencyResolver.GetService(typeof(IRoleService));

        public override bool EnablePasswordRetrieval { get; }
        public override bool EnablePasswordReset { get; }
        public override bool RequiresQuestionAndAnswer { get; }
        public override string ApplicationName { get; set; }
        public override int MaxInvalidPasswordAttempts { get; }
        public override int PasswordAttemptWindow { get; }
        public override bool RequiresUniqueEmail { get; }
        public override MembershipPasswordFormat PasswordFormat { get; }
        public override int MinRequiredPasswordLength { get; }
        public override int MinRequiredNonAlphanumericCharacters { get; }
        public override string PasswordStrengthRegularExpression { get; }

        public bool CreateUser(string name, string login, string password)
        {
            if (!userService.IsFreeLogin(login))
                return false;

            var user = new UserEntity
            {
                Login = login,
                Nickname = name,
                Password = Crypto.HashPassword(password)
            };

            var userRole = roleService.GetRoleEntityByName("User");

            if (!ReferenceEquals(userRole, null))
                user.Roles.Add(userRole);

            userService.CreateNewUser(user);

            var createdUser = userService.GetUserByLogin(user.Login);

            return true;
        }

        public override bool ValidateUser(string username, string password)
        {
            var user = userService.GetUserByLogin(username);

            if (!ReferenceEquals(user, null) && Crypto.VerifyHashedPassword(user.Password, password))
                return true;

            return false;
        }

        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion, string passwordAnswer,
            bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password,
            string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string login, bool userIsOnline)
        {
            var user = userService.GetUserByLogin(login);

            if (user == null) return null;

            var memberUser = new MembershipUser("CustomMembershipProvider", user.Login,
                null, null, null, null,
                false, false, DateTime.Now,
                DateTime.MinValue, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue);

            return memberUser;
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new NotImplementedException();
        }
    }
}