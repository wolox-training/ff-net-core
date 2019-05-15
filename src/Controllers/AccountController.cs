using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Repositories.Interfaces;
using MvcMovie.Repositories.Database;
using MvcMovie.Models.Views;
using MvcMovie.Models.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace MvcMovie.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;

        public SignInManager<User> SignInManager { get { return this._signInManager; } }
        public UserManager<User> UserManager { get { return this._userManager; } }

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        [HttpGet("Login")]
        public IActionResult Login() => View();

        [HttpGet("AccesDenied")]
        public IActionResult AccesDenied() => View();

        [HttpGet("Register")]
        public IActionResult Register() => View();

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserViewModel uservm)
        {
            var u = new User { UserName = uservm.UserName, Email = uservm.Email };
            var result = await _userManager.CreateAsync(u, uservm.Password);
            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(u, true);
                return RedirectToAction("Index", "Movies");
           }
            else
            {
                return RedirectToAction("Index", "Movies");
            }
        }
    }
}
