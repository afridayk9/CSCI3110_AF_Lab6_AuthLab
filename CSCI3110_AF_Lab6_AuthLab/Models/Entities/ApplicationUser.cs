using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSCI3110_AF_Lab6_AuthLab.Models.Entities;

public class ApplicationUser : IdentityUser
{
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
    [NotMapped]
    public ICollection<string> Roles { get; set; } = new List<string>();

    public bool HasRole (string roleName)
    {
        return Roles.Any(r => r == roleName);
    }
}
