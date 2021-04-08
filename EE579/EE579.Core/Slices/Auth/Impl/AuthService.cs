using AutoMapper;
using EE579.Core.Slices.Auth.Models;
using EE579.Core.Slices.Users.Models;
using EE579.Domain;
using EE579.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EE579.Core.Infrastructure.Exceptions;
using EE579.Core.Infrastructure.Exceptions.Models;
using Microsoft.AspNetCore.Identity;

namespace EE579.Core.Slices.Auth.Impl
{
    public class AuthService : IAuthService
    {

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AuthService(DatabaseContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<string> CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("zFXaqM10Dw55jz9SZla3EHl1jhcseBSClXhE0A2Q35HtXzTfGHQiNAqOB4MOOWb");
            var claims = await _userManager.GetClaimsAsync(user);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.Concat(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()), 
                })),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<SessionDto> Login(LoginInput input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user == null)
                throw new FormErrorException(new List<FieldError>
                {
                    new FieldError("email", "Invalid email or password"),
                    new FieldError("password", "Invalid email or password"),
                });

            if (!await _userManager.CheckPasswordAsync(user, input.Password))
                throw new FormErrorException(new List<FieldError>
                {
                    new FieldError("email", "Invalid email or password"),
                    new FieldError("password", "Invalid email or password"),
                });

            user.RefreshToken = Guid.NewGuid();
            await _context.SaveChangesAsync();

            var userDto = _mapper.Map<UserDto>(user);

            var session = new SessionDto { 
                User = userDto,
                Token = await CreateToken(user),
                RefreshToken = user.RefreshToken
            };

            return session;
        }

        public async Task<SessionDto> RefreshToken(RefreshTokenInput input)
        {
            throw new NotImplementedException();
        }
    }
}
