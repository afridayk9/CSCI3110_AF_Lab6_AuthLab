using CSCI3110_AF_Lab6_AuthLab.Models;
using CSCI3110_AF_Lab6_AuthLab.Models.Entities;
using CSCI3110_AF_Lab6_AuthLab.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace CSCI3110_AF_Lab6_AuthLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRespository _userRepo;
        private readonly Random _random = new Random();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> CreateTestUser()
        {
            var n = _random.Next(100);
            var check = await _userRepo.ReadByUserNameAsync($"test{n}@test.com");
            if (check == null)
            {
                var user = new ApplicationUser
                {
                    Email = $"test{n}@test.com",
                    UserName = $"test{n}@test.com",
                    FirstName = $"User{n}",
                    LastName = $"Userlastname{n}"
                };
                await _userRepo.CreateAsync(user, "Pass123!");
                return Content($"Created test user 'test{n}@test.com' with password 'Pass123!'");
            }
            return Content("The user was already created.");

        }
    }
}
