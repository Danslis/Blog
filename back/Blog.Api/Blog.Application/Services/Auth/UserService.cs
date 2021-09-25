using Blog.Application.Services.Auth.AuthOption;
using Blog.Domain.Auth;
using Blog.Domain.Models.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IOptions<AuthOptions> _authOptions;
        public UserService(IUserRepository repository, IOptions<AuthOptions> authOptions)
        {
            _repository = repository;
            _authOptions = authOptions;
        }        

        public async Task<string> GenerateJwt(string userName, string userId)
        {
            var authParams = _authOptions.Value;
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);                  

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),               
                new Claim("identityUserId", userId)                
            };

            var tokeOptions = new JwtSecurityToken(
                issuer: authParams.Issuer,
                audience: authParams.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);

        }

        public async Task<UserLoginModel> GetIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<UserLoginModel>(null);
            // get the user to verifty
            var result = await _repository.GetIdentity(userName, password);
            return result;
        }        
    }
}
