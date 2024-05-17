namespace SimpleBlog.Domain.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string key, string message) : base(message)
        {
            Key = key;
        }

        public string? Key { get; }
    }
}
