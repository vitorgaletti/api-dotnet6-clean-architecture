﻿using Microsoft.IdentityModel.Tokens;
using MP.ApiDotNet6.Domain.Authentication;
using MP.ApiDotNet6.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MP.ApiDotNet6.Infra.Data.Authentication {
    public class TokenGenerator : ITokenGenerator {
        public dynamic Generator(User user) {

            var permission = string.Join(",", user.UserPermissions.Select(x => x.Permission?.PermissionName));
            var claims = new List<Claim> {
                new Claim("Email", user.Email),
                new Claim("ID", user.Id.ToString()),
                new Claim("Permissoes", permission)
            };

            var expires = DateTime.Now.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mTqE7fUg9W5nqA3YdpZM6k8H7jR4vT5L"));
            var tokenData = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
            return new {
                acess_token = token,
                expirations = expires
            };
        }
    }
}
