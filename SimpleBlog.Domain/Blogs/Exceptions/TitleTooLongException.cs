using SimpleBlog.Domain.Core.Exceptions;

namespace SimpleBlog.Domain.Blogs.Exceptions
{
    public class TitleTooLongException : BusinessException
    {
        private const string message = "O título deve ter no máximo 100 caracteres.";
        public TitleTooLongException(string key) : base(key, message)
        {
        }

        public TitleTooLongException() : base(message)
        {
        }
    }
}
