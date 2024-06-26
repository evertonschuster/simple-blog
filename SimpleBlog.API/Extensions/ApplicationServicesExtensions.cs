﻿using SimpleBlog.API.Core;
using SimpleBlog.API.Hubs;
using SimpleBlog.Application.Blogs;
using SimpleBlog.Application.Core;

namespace SimpleBlog.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUser, UserService>();
            services.AddScoped<IPostNotificationService, NotificationHubWrapper>();

            return services;
        }
    }
}
