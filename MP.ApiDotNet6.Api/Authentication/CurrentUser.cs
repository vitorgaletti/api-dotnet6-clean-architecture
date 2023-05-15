﻿using MP.ApiDotNet6.Domain.Authentication;

namespace MP.ApiDotNet6.Api.Authentication {
    public class CurrentUser : ICurrentUser {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Permissions { get; set; }
        public CurrentUser(IHttpContextAccessor httpContextAccessor) {
            var httpContext = httpContextAccessor.HttpContext;
            var claims = httpContext.User.Claims;

            if (claims.Any(x => x.Type == "ID")) {
                var id = Convert.ToInt32(claims.First(x => x.Type == "ID").Value);

                Id = id;
            }

            if (claims.Any(x => x.Type == "Email")) {
                Email = claims.First(x => x.Type == "Email").Value;
            }

            if (claims.Any(x => x.Type == "Permissoes")) {
                Permissions = claims.First(x => x.Type == "Permissoes").Value;
            }
        }
        
    }
}
