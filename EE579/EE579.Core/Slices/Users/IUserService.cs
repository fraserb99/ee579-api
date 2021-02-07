using EE579.Core.Slices.Auth.Models;
using EE579.Core.Slices.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EE579.Core.Slices.Users
{
    public interface IUserService
    {
        public SessionDto Create(CreateUserInput input);
    }
}
