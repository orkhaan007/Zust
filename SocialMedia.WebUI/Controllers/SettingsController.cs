using Microsoft.AspNetCore.Mvc;
using SocialMedia.WebUI.Consts;
using SocialMedia.WebUI.Services.Account.Abstract;
using SocialMedia.WebUI.Services.Other.Abstract;

namespace SocialMedia.WebUI.Controllers;
public class SettingsController : Controller
{
    private readonly IAccountService _accountService;
    private readonly IImageService _imageService;

    public SettingsController(IAccountService accountService, IImageService imageService)
    {
        _accountService = accountService;
        _imageService = imageService;
    }

    public IActionResult MyProfile()
    {
        return View();
    }

    public IActionResult Setting()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult HelpAndSupport()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _accountService.LogOutAsync();
        return RedirectToAction(WebUIConstants.LoginConstant, WebUIConstants.AccountConstant);
    }
}
