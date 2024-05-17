
namespace SimpleBlog.Domain.Core.Exceptions
{
    public class UnauthorizedException : BusinessException
    {
        private const string message = "Usuário não autorizado.";

        public UnauthorizedException() : base(message)
        {
        }

        public UnauthorizedException(Guid id) : base(id.ToString(), message)
        {
        }
    }
}
