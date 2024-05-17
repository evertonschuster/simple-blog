namespace SimpleBlog.Domain.Core
{
    public class Entity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public Guid CreatedBy { get; protected set; }

        public DateTimeOffset CreatedAt { get; protected set; } = DateTimeOffset.UtcNow;

        public Guid? UpdatedBy { get; protected set; }

        public DateTimeOffset? UpdatedAt { get; protected set; }
    }
}
