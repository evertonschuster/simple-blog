using SimpleBlog.Domain.Core.Exceptions;
namespace SimpleBlog.Domain.Blogs.Exceptions
{
    public class TitleWhiteSpaceException : BusinessException
    {
        private const string message = "O título não pode ser vazio ou nulo.";
        public TitleWhiteSpaceException(string key) : base(key, message)
        {
        }

        public TitleWhiteSpaceException() : base(message)
        {
        }
    }
}
