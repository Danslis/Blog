using Blog.DataAccess.Repositories;
using Blog.DataAccess.Repositories.Auth;
using Blog.Domain;
using Blog.Domain.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Api.Extensions
{
    public static class RepositoriesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
