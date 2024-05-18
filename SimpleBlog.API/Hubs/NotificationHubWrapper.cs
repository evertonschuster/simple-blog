using Microsoft.AspNetCore.SignalR;
using SimpleBlog.Application.Blogs;
using SimpleBlog.Application.Blogs.Dtos;

namespace SimpleBlog.API.Hubs
{
    public class NotificationHubWrapper : IPostNotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationHubWrapper(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task CreatedPost(PostDto post)
        {
            return _hubContext.Clients.All.SendAsync("new-post", post);
        }
    }
}
