using Blog.Domain.Models.Auth;
using System.Threading.Tasks;

namespace Blog.Domain.Auth
{
    public interface IUserService
    {
        public string GenerateJwt(string userName, string userId);
        public Task<UserLoginModel> GetIdentity(string userName, string password);
    }
}
