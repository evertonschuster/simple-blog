
using SimpleBlog.Domain.Blogs;

namespace SimpleBlog.Application.Blogs.Dtos
{
    public class PostDto
    {
        public Guid? Id { get; set; }

        public required string Title { get; set; }

        public string? Body { get; set; }

        public List<string>? Tags { get; set; }

        public static PostDto From(Post model)
        {
            return new PostDto
            {
                Id = model.Id,
                Title = model.Title,
                Body = model.Body,
                Tags = model.Tags
            };
        }

        public Post ToModel(Guid userId)
        {
            return Post.Create(
                title: Title,
                body: Body,
                tags: Tags,
                createdBy: userId
            );
        }
    }
}
