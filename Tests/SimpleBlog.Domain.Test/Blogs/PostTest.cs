using SimpleBlog.Domain.Blogs;
using SimpleBlog.Domain.Blogs.Exceptions;

namespace SimpleBlog.Domain.Test.Blogs
{

    public class PostTest
    {
        private readonly string _title = "Test Title";
        private readonly string _body = "Test Body";
        private readonly List<string> _tags = new List<string> { "Test1", "Test2" };
        private readonly Guid _createdBy = Guid.NewGuid();

        [Fact]
        public void CreatePost_WithValidParameters_ShouldNotThrowException()
        {
            // Act
            var exception = Record.Exception(() => Post.Create(_title, _body, _tags, _createdBy));

            // Assert
            Assert.Null(exception);
        }

        [Fact]

        public void CreatePost_WithWhiteSpaceTitle_ShouldThrowTitleWhiteSpaceException()
        {
            // Arrange
            var title = "   ";

            // Act & Assert
            Assert.Throws<TitleWhiteSpaceException>(() => Post.Create(title, _body, _tags, _createdBy));
        }
    }
}
