using EE579.Core.Infrastructure.Extensions;
using EE579.Domain;
using EE579.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace EE579.Core.Slices.Users
{
    public class CurrentUser : ICurrentUser
    {
        private readonly HttpContext _httpContext;
        private readonly DatabaseContext _db;
        public CurrentUser(IHttpContextAccessor httpContextAccessor, DatabaseContext db)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _db = db;
        }

        public User Get()
        {
            return _db.Users.Find(_httpContext.GetUserId());
        }
    }
}
