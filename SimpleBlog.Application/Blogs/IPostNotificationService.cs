using SimpleBlog.Application.Blogs.Dtos;

namespace SimpleBlog.Application.Blogs
{
    public interface IPostNotificationService
    {
        public Task CreatedPost(PostDto post);
    }
}
