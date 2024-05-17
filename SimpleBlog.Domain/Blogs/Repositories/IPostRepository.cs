using SimpleBlog.Domain.Core.Repositories;

namespace SimpleBlog.Domain.Blogs.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> ListAllAsync();
    }
}
