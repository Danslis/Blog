using Blog.Application.Services;
using Blog.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ITestService, TestService>();
            return services;
        }
        
    }
}
