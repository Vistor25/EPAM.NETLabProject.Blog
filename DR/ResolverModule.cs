using System.Data.Entity;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DR
{
    namespace DependencyResolver
    {
        public static class ResolveConfig
        {
            public static void ConfigurateResolverWeb(this IKernel kernel, string connectionString)
            {
                Configure(kernel, true, connectionString);
            }

            public static void ConfigurateResolverConsole(this IKernel kernel, string connectionString)
            {
                Configure(kernel, false, connectionString);
            }

            private static void Configure(IKernel kernel, bool isWeb, string connectionString)
            {
                if (isWeb)
                {
                    kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                    kernel.Bind<DbContext>()
                        .To<BlogDBEntities>()
                        .InRequestScope()
                        .WithConstructorArgument(connectionString);
                    
                }
                else
                {
                    kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                    kernel.Bind<DbContext>().To<BlogDBEntities>().InSingletonScope();
                }
                kernel.Bind<ICommentService>().To<CommentService>();
                kernel.Bind<IRoleService>().To<RoleService>();
                kernel.Bind<IArticleService>().To<ArticleService>();
                kernel.Bind<ITagService>().To<TagService>();
                kernel.Bind<ITagRepository>().To<TagRepository>();
                kernel.Bind<IUserRepository>().To<UserRepository>();
                kernel.Bind<IUserService>().To<UserService>();
                kernel.Bind<IArticleRepository>().To<ArticleRepository>();
                kernel.Bind<IRoleRepository>().To<RoleRepository>();
                kernel.Bind<ICommentRepository>().To<CommentRepository>();
                //pukernel.Bind<ITagRepository>().To<TagRepository>();blic static class ResolverModule
                //{ kernel.Bind<ICommentRepository>().To<CommentRepository>();
                //    public static void ConfigurateResolver(this IKernel kernel)
                //    {
                //        kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                //        kernel.Bind<DbContext>().To<BlogDBEntities>().InRequestScope();

                //        kernel.Bind<IUserRepository>().To<UserRepository>();
                //        kernel.Bind<IArticleRepository>().To<ArticleRepository>();
                //        kernel.Bind<IRoleRepository>().To<RoleRepository>();
                //        kernel.Bind<ITagRepository>().To<TagRepository>();
                //        kernel.Bind<ICommentRepository>().To<CommentRepository>();

                //        kernel.Bind<IUserService>().To<UserService>();
                //        kernel.Bind<IArticleService>().To<ArticleService>();
                //        kernel.Bind<IRoleService>().To<RoleService>();
                //        kernel.Bind<ITagService>().To<TagService>();
                //        kernel.Bind<ICommentService>().To<CommentService>();
                //    }
                //}
            }
        }
    }
}