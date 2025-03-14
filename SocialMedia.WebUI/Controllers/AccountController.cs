﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Entities.Models;
using SocialMedia.WebUI.Consts;
using SocialMedia.WebUI.Models.Account;
using SocialMedia.WebUI.Services.Account.Abstract;
using SocialMedia.WebUI.Services.Other.Abstract;
using Microsoft.AspNetCore.Authentication.Google;

namespace SocialMedia.WebUI.Controllers;
public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private readonly UserManager<CustomIdentityUser> _userManager;
    private readonly IImageService _imageService;
                                                                                                                               
    public AccountController(IAccountService accountService, UserManager<CustomIdentityUser> userManager, IImageService imageService)
    {
        _accountService = accountService;
        _userManager = userManager;
        _imageService = imageService;
    }
                                                                                                                                                   
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model, IFormFile profileImageFile)
    {
        if (ModelState.IsValid)
        {
            if(model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords must match");
                return View(model);
            }
            if (!model.AcceptPrivacy)
            {
                ModelState.AddModelError("", "You should accept our privacy and policy");
                return View();
            }
            if(await _accountService.RegisterAsync(model, profileImageFile))
            {
                return RedirectToAction(WebUIConstants.LoginConstant,WebUIConstants.AccountConstant);
            }
        }
        ModelState.AddModelError("", "Can not register the user !");
        return View(model);
    }

                                                                                                                                                   
    [HttpGet]
    public IActionResult Login()
    { 
        return View();
    }

    public async Task<IActionResult> GoogleResponse()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        if (result?.Principal != null)
        {
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            }).ToList();

            Console.WriteLine("Login Successful! User Claims:");
            foreach (var claim in claims)
            {
                Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
            }

            return RedirectToAction("Index", "Home");
        }

        Console.WriteLine("Login Failed: No Principal found.");
        return RedirectToAction("Error", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
           if(await _accountService.LoginAsync(model))
            {
                return RedirectToAction(WebUIConstants.IndexConstant,WebUIConstants.HomeConstant);
            }
        }
        ModelState.AddModelError("", "Invalid Login !");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CloseAccount([FromBody] CloseAccountViewModel model)
    {
        var currentUser = await _userManager.GetUserAsync(HttpContext.User);
        var isPasswordCorrect = await _userManager.CheckPasswordAsync(currentUser, model.Password);

        if (isPasswordCorrect && model.Email == currentUser.Email)
        {
            var result = await _userManager.DeleteAsync(currentUser);
            if (result.Succeeded)
            {
                return RedirectToAction(WebUIConstants.LoginConstant, WebUIConstants.AccountConstant);
            }
            else
            {
                return BadRequest("Failed to delete account.");
            }
        }
        return BadRequest("Invalid email or password.");
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
    {
        var currentUser = await _userManager.GetUserAsync(HttpContext.User);
        var isPasswordCorrect = await _userManager.CheckPasswordAsync(currentUser, model.OldPassword);

        if (isPasswordCorrect)
        {
            var result = await _userManager.ChangePasswordAsync(currentUser,model.OldPassword,model.NewPassword);
            if (result.Succeeded)
            {
                return RedirectToAction(WebUIConstants.LoginConstant, WebUIConstants.AccountConstant);
            }
            else
            {
                return BadRequest("Failed to change password.");
            }
        }
        return BadRequest("Invalid password.");
    }

    [HttpPost]
    public async Task<IActionResult> EditUser([FromBody] EditUserViewModel model)
    {
        var currentUser = await _userManager.GetUserAsync(HttpContext.User);
        if(model.Email.EndsWith("@gmail.com") && model.Email.Length>5 && model.Username.Length > 4)
        {
            currentUser.UserName = model.Username;
            currentUser.Email = model.Email;
            await _userManager.UpdateAsync(currentUser);
            return RedirectToAction(WebUIConstants.IndexConstant,WebUIConstants.HomeConstant);
        }
        return BadRequest("can not edit the user cause of invalid username and email !");
    }

                                                                                                                                                    
    [HttpGet]
    public async Task<IActionResult> GetCurrentUser()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null) return BadRequest();
        var obj = new {User = user};
        return Ok(obj);
    }

                                                                                                                                                    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers(string ? key)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null) return BadRequest();
        dynamic ? allUsersExpectCurrent;
        allUsersExpectCurrent = string.IsNullOrEmpty(key)  ? await _userManager.Users.Where(u => u.Id != user.Id).OrderByDescending(u => u.IsOnline).ToListAsync() : await _userManager.Users.Where(u => u.Id != user.Id && u.UserName.Contains(key)).OrderByDescending(u => u.IsOnline).ToListAsync();
        return Ok(new{ AllUsers = allUsersExpectCurrent});
    }

    [HttpGet]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u =>u.UserName == username);
        if (user == null) return BadRequest();
        return Ok(new { User = user });
    }

    [HttpGet]
    public async Task<IActionResult> GetUserById(string id)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) return BadRequest();
        return Ok(new { User = user });
    }
}
