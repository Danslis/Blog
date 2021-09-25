using Microsoft.AspNetCore.Identity;

namespace Blog.DataAccess.Entities
{
    public class UserEntity : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
