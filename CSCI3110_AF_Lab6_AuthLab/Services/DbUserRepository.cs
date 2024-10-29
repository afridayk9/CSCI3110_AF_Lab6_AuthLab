using CSCI3110_AF_Lab6_AuthLab.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CSCI3110_AF_Lab6_AuthLab.Services
{
    public class DbUserRepository : IUserRespository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public DbUserRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AssignUserToRoleAsync(string userName, string rolename)
        {
            var roleCheck = await _roleManager.RoleExistsAsync(rolename);
            if (!roleCheck)
            {
                await _roleManager.CreateAsync(new IdentityRole(rolename));
            }
            var user = await ReadByUserNameAsync(userName);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, rolename);
            }
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
            return user;
        }

        public async Task<IQueryable<ApplicationUser>> ReadAllAsync()
        {
            var users = _db.Users;
            foreach (var user in users)
            {
                user.Roles = await _userManager.GetRolesAsync(user);                
            }
            return users;
        }

        public async Task<ApplicationUser?> ReadByUserNameAsync(string userName)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            if (user != null)
            {
                user.Roles = await _userManager.GetRolesAsync(user);
            }
            return user;
        }
    }
}
