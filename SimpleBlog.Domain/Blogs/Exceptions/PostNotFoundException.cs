using SimpleBlog.Domain.Core.Exceptions;

namespace SimpleBlog.Domain.Blogs.Exceptions
{
    public class PostNotFoundException : BusinessException
    {
        private const string message = "Postagem não encontrada.";

        public PostNotFoundException(Guid id) : base(id.ToString(), message)
        {
        }

        public PostNotFoundException() : base(message)
        {
        }
    }
}
