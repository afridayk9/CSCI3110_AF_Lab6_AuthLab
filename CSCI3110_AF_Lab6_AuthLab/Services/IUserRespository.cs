using CSCI3110_AF_Lab6_AuthLab.Models.Entities;

namespace CSCI3110_AF_Lab6_AuthLab.Services
{
    public interface IUserRespository
    {
        Task<ApplicationUser?> ReadByUserNameAsync(string userName);
        Task<ApplicationUser> CreateAsync(ApplicationUser user, string password);
        Task AssignUserToRoleAsync(string userName, string roleName);
        Task<IQueryable<ApplicationUser>> ReadAllAsync();
    }
}
