using SimpleBlog.Application.Core;
using System.Security.Claims;

namespace SimpleBlog.API.Core
{
    public class UserService : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid Id
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                return Guid.Parse(userId);
            }
        }
    }
}
