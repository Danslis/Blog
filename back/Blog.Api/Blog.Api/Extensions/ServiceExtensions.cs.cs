using Blog.Application.Services;
using Blog.Application.Services.Auth;
using Blog.Domain;
using Blog.Domain.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
        
    }
}
