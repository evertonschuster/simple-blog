namespace SimpleBlog.API.Models
{
    public record LoginModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
