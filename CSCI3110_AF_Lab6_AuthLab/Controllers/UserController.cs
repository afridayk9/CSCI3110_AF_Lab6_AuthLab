using CSCI3110_AF_Lab6_AuthLab.Models.ViewModels;
using CSCI3110_AF_Lab6_AuthLab.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSCI3110_AF_Lab6_AuthLab.Controllers;

[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly IUserRespository _userRepo;

    public UserController(IUserRespository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userRepo.ReadAllAsync();
        var userList = users
           .Select(u => new UserListVM
           {
               Email = u.Email,
               UserName = u.UserName,
               NumberOfRoles = u.Roles.Count,
               RoleNames = string.Join(",", u.Roles.ToArray())
           });
        return View(userList);
    }

}
