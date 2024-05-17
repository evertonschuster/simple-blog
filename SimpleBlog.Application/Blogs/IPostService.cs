using SimpleBlog.Application.Blogs.Dtos;

namespace SimpleBlog.Application.Blogs
{
    public interface IPostService
    {
        Task<PostDto> GetByIdAsync(Guid id);

        Task<PostDto> CreateAsync(PostDto postDto);

        Task<PostDto> UpdateAsync(PostDto postDto);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<PostDto>> ListAllAsync();
    }
}