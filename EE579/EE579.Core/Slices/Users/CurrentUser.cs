using System.Threading.Tasks;
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

        public async Task<User> Get()
        {
            return await _db.Users.FindAsync(_httpContext.GetUserId());
        }
    }
}
