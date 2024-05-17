using Microsoft.Extensions.DependencyInjection;
using SimpleBlog.Domain.Blogs.Repositories;
using SimpleBlog.Infrastructure.Blogs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
