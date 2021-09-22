using Blog.DataAccess.Repositories;
using Blog.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Api.Extensions
{
    public static class RepositoriesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}
