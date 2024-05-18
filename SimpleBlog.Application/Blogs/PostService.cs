using SimpleBlog.Application.Blogs.Dtos;
using SimpleBlog.Application.Core;
using SimpleBlog.Domain.Blogs.Exceptions;
using SimpleBlog.Domain.Blogs.Repositories;
using SimpleBlog.Domain.Core.Exceptions;

namespace SimpleBlog.Application.Blogs
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUser _user;

        public PostService(IPostRepository postRepository, IUser user)
        {
            _postRepository = postRepository;
            _user = user;
        }

        public async Task<PostDto> CreateAsync(PostDto postDto)
        {
            var userId = _user.Id;
            var model = postDto.ToModel(userId);

            model = await _postRepository.CreateAsync(model);

            return PostDto.From(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _postRepository.DeleteAsync(id);
        }

        public async Task<PostDto> GetByIdAsync(Guid id)
        {
            var model = await _postRepository.GetByIdAsync(id);

            return PostDto.From(model);
        }

        public async Task<PostDto> UpdateAsync(PostDto postDto)
        {
            if (!postDto.Id.HasValue)
            {
                throw new PostNotFoundException();
            }

            var userId = _user.Id;
            var model = await _postRepository.GetByIdAsync(postDto.Id.Value);

            if (model == null)
            {
                throw new PostNotFoundException(postDto.Id.Value);
            }
            if (model.CreatedBy != userId)
            {
                throw new UnauthorizedException(userId);
            }

            model.Update(postDto.Title, postDto.Body, postDto.Tags);
            model = await _postRepository.UpdateAsync(model);

            return PostDto.From(model);
        }

        public async Task<IEnumerable<PostDto>> ListAllAsync()
        {
            var models = await _postRepository.ListAllAsync();
            return models.Select(PostDto.From);
        }
    }
}
