using Blog.Domain.Models.Auth;
using System.Threading.Tasks;

namespace Blog.Domain.Auth
{
    public interface IUserRepository
    {
        public Task<UserLoginModel> GetIdentity(string userName, string password);
        public Task<UserLoginModel> FindUserByIdAsync(string userId);
    }
}
