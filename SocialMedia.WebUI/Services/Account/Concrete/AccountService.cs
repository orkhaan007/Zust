using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Entities.Models;
using SocialMedia.WebUI.Consts;
using SocialMedia.WebUI.Models.Account;
using SocialMedia.WebUI.Services.Account.Abstract;
using SocialMedia.WebUI.Services.Other.Abstract;

namespace SocialMedia.WebUI.Services.Account.Concrete;
                                                                                                                                               
public class AccountService : IAccountService
{
                                                                                                                                                    
    private readonly UserManager<CustomIdentityUser> _userManager;
    private readonly RoleManager<CustomIdentityRole> _roleManager;
    private readonly SignInManager<CustomIdentityUser> _signInManager;
    private readonly IImageService _imageService;
    private readonly IHttpContextAccessor _contextAccessor;

                                                                                                                                                    
    public AccountService(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager, IImageService imageService, IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _imageService = imageService;
        _contextAccessor = contextAccessor;
    }

                                                                                                                                                   
    public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
    {
        SignInResult result = await _signInManager.PasswordSignInAsync(loginViewModel.Username,loginViewModel.Password,loginViewModel.RememberMe,false);
        if (result.Succeeded)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == loginViewModel.Username);
            user.IsOnline = true;
            await _userManager.UpdateAsync(user);
            return true;
        }
        return false;
    }

    public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel, IFormFile profileImageFile)
    {
        string imageUrl = null;

        if (profileImageFile != null)
        {
            imageUrl = await _imageService.SaveFileAsync(profileImageFile, "profiles");
        }

        var user = new CustomIdentityUser
        {
            Email = registerViewModel.Email,
            UserName = registerViewModel.Username,
            ImageUrl = imageUrl ?? "default_profile.jpg",
            IsOnline = true,
            ConnectTime = DateTime.Now.ToString()
        };

        IdentityResult result = await _userManager.CreateAsync(user, registerViewModel.Password);
        if (result.Succeeded)
        {
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                CustomIdentityRole role = new CustomIdentityRole { Name = "User" };
                IdentityResult roleResult = await _roleManager.CreateAsync(role);
                if (!roleResult.Succeeded)
                {
                    return false;
                }
            }

            await _userManager.AddToRoleAsync(user, "User");
            return true;
        }

        return false;
    }


    public async Task<bool> LogOutAsync()
    {
        var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
        if (user != null)
        {
            user.IsOnline = false;
            user.DisconnectTime = DateTime.UtcNow;
            await _signInManager.SignOutAsync();
            await _userManager.UpdateAsync(user);
            _contextAccessor.HttpContext.Session.SetString("UserViewModel", "");
            return true;
        }
        return false;
    }
}
