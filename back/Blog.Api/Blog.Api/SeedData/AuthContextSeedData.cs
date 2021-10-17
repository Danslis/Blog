using System;
using System.Linq;
using Blog.DataAccess.Context;
using Blog.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Blog.Api.SeedData
{
    public class AuthContextSeedData
    {
        private AppDbContext _context;

        public AuthContextSeedData(AppDbContext context)
        {
            _context = context;
        }

        public async void SeedAdminUser()
        {
            var user = new UserEntity
            {
                UserName = "Test@email.com",
                NormalizedUserName = "TEST@EMAIL.COM",
                Email = "Test@email.com",
                NormalizedEmail = "TEST@EMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "User"))
            {
                await roleStore.CreateAsync(new IdentityRole {Name = "User", NormalizedName = "USER" });
            }

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<UserEntity>();
                var hashed = password.HashPassword(user, "12345");
                user.PasswordHash = hashed;
                var userStore = new UserStore<UserEntity>(_context);
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "User".ToUpper());
            }

            await _context.SaveChangesAsync();
        }
    }
}
