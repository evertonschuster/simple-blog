using Microsoft.Extensions.DependencyInjection;
using SimpleBlog.Domain.Blogs.Repositories;
using SimpleBlog.Infrastructure.Blogs.Repositories;

namespace SimpleBlog.Infrastructure.Extensions
{
    public static class ApplicationRepositoryExtensions
    {
        public static IServiceCollection AddAppRepository(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
