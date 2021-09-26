using Blog.DataAccess.Entities;
using Blog.Domain.Auth;
using Blog.Domain.Models.Auth;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repositories.Auth
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserEntity> _userManager;
        public UserRepository(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserLoginModel> FindUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return new UserLoginModel()
                    {
                        UserId = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
        }
        public async Task<UserLoginModel> GetIdentity(string userName, string password)
        {
            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<UserLoginModel>(null);
            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                var user = await _userManager.FindByNameAsync(userName);            
                return new UserLoginModel()
                    {                        
                        UserId = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
            }
            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<UserLoginModel>(null);
        }
    }
}
