using SimpleBlog.Application.Blogs;
using SimpleBlog.Application.Blogs.Dtos;
using SimpleBlog.Application.Core;
using SimpleBlog.Domain.Blogs;
using SimpleBlog.Domain.Blogs.Exceptions;
using SimpleBlog.Domain.Blogs.Repositories;
using SimpleBlog.Domain.Core.Exceptions;

namespace SimpleBlog.Application.Test.Blogs
{
    public class PostServiceTest
    {
        private readonly IPostNotificationService _postNotification;
        private readonly IPostRepository _postRepository;
        private readonly IUser _user;
        private readonly PostService _postService;

        public PostServiceTest()
        {
            _postNotification = Substitute.For<IPostNotificationService>();
            _postRepository = Substitute.For<IPostRepository>();
            _user = Substitute.For<IUser>();
            _postService = new PostService(_postRepository, _user, _postNotification);

            _user.Id.Returns(Guid.NewGuid());
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnPostDto()
        {
            // Arrange
            var postDto = new PostDto { Title = "Test Title", Body = "Test Body", Tags = new List<string> { "Test1", "Test2" } };
            var userId = Guid.NewGuid();
            var model = postDto.ToModel(userId);
            _postRepository.CreateAsync(Arg.Any<Post>()).Returns(model);

            // Act
            var result = await _postService.CreateAsync(postDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(postDto.Title, result.Title);
            Assert.Equal(postDto.Body, result.Body);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnPostDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var post = new Post("Test Title", "Test Body", new List<string> { "Test1", "Test2" }, id);
            _postRepository.GetByIdAsync(id).Returns(post);

            // Act
            var result = await _postService.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(post.Title, result.Title);
            Assert.Equal(post.Body, result.Body);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowPostNotFoundException_WhenPostDoesNotExist()
        {
            // Arrange
            var postDto = new PostDto { Id = Guid.NewGuid(), Title = "Test Title", Body = "Test Body", Tags = new List<string> { "Test1", "Test2" } };
            _postRepository.GetByIdAsync(postDto.Id.Value).Returns((Post)null);

            // Act & Assert
            await Assert.ThrowsAsync<PostNotFoundException>(() => _postService.UpdateAsync(postDto));
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowUnauthorizedException_WhenUserIsNotCreator()
        {
            // Arrange
            var postDto = new PostDto { Id = Guid.NewGuid(), Title = "Test Title", Body = "Test Body", Tags = new List<string> { "Test1", "Test2" } };
            var post = new Post(postDto.Title, postDto.Body, postDto.Tags, Guid.NewGuid());
            _postRepository.GetByIdAsync(postDto.Id.Value).Returns(post);

            // Act & Assert
            await Assert.ThrowsAsync<UnauthorizedException>(() => _postService.UpdateAsync(postDto));
        }
    }
}