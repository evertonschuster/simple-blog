using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Blogs;
using SimpleBlog.Domain.Blogs.Repositories;
using SimpleBlog.Infrastructure.Core;

namespace SimpleBlog.Infrastructure.Blogs.Repositories
{
    internal class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Post>> ListAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
