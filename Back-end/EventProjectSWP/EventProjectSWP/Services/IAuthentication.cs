using EventProjectSWP.Models;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventProjectSWP.Services
{
    public interface IAuthentication
    {
        public Task<string> GenerateToken(UserInfo userInfo);
        public UserInfo? GetUserInfo(AuthenticateResult info);
    }
}
