using SimpleBlog.Domain.Blogs;
using SimpleBlog.Domain.Blogs.Repositories;

namespace SimpleBlog.Infrastructure.Blogs.Repositories
{
    internal class PostRepository : IPostRepository
    {
        public Task<Post> CreateAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdateAsync(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
