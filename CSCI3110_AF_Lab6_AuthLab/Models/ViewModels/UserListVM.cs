using System.ComponentModel.DataAnnotations;

namespace CSCI3110_AF_Lab6_AuthLab.Models.ViewModels
{
    public class UserListVM
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        [Display(Name = "Number of Roles")]
        public int NumberOfRoles { get; set; }
        [Display(Name = "Role Names")]
        public string? RoleNames { get; set; }
    }
}
