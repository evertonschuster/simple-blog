using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleBlog.Infrastructure.Extensions
{
    public static class ApplicationDbContextExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=site.db", b => b.MigrationsAssembly("SimpleBlog.API")));

            return services;
        }
    }
}
