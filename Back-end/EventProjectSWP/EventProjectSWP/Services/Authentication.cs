﻿using EventProjectSWP.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventProjectSWP.Services
{
    public class Authentication
    {
        private readonly IConfiguration _configuration;
        public readonly DateTime EXPIRED_AT = DateTime.UtcNow.AddMinutes(20);

        public Authentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(UserInfo userInfo)
        {
            var signinCredentials = GetSigninCredentials();
            var claims = await GetClaims(userInfo);
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public UserInfo? GetUserInfo(AuthenticateResult info)
        {
            var email = info.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            if (email != null && !email.Value.EndsWith("fpt.edu.vn"))
            {
                return null;
            }
            var name = info.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);

            UserInfo userInfo = new UserInfo
            {
                Email = email.Value,
                UserName = name.Value,
            };

            return userInfo;
        }

        public JwtSecurityToken DecodeToken(string token)
        {
            var parsedToken = token.Replace("Bearer ", string.Empty);
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(parsedToken);
        }

        private SigningCredentials GetSigninCredentials()
        {
            var key = Encoding.UTF8.GetBytes("Help, pls god h elp, hmu rot mon gio dcmmm aewqeasfgsefaerwegdfgsdfadrqwrsdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private Task<List<Claim>> GetClaims(UserInfo userInfo)
        {
            var claims = new List<Claim>
            {
                new("email", userInfo.Email),
                new("name", userInfo.UserName),
                new("role", "user"),
            };

            return Task.FromResult(claims);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken
            (
                jwtSettings.GetSection("ValidIssuer").Value,
                jwtSettings.GetSection("ValidAudience").Value,
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }
    }
}