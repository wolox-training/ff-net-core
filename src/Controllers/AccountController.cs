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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace MvcMovie.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        
        public SignInManager<User> SignInManager { get { return this._signInManager; } }
        public UserManager<User> UserManager { get { return this._userManager; } }

        [HttpGet("Register")]
        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = uvm.UserName, Email = uvm.Email };
                var result = await UserManager.CreateAsync(user, uvm.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Movies");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }  
            }
            return View(uvm);
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public IActionResult Login() => View();

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                await SignInManager.SignOutAsync();
                var result = await SignInManager.PasswordSignInAsync(lvm.UserName, lvm.Password, lvm.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Movies");
                }
                ModelState.AddModelError(string.Empty, "Wrong username or password");
            }
            return View(lvm);
        }

        [AllowAnonymous]
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet("Registered")]
        public IActionResult Registered() => View(UserManager.Users.ToList().Select(u => new UserViewModel { UserName = u.UserName, Email = u.Email } ));
    }
}
