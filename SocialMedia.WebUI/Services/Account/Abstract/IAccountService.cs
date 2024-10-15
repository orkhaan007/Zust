using SocialMedia.WebUI.Models.Account;

namespace SocialMedia.WebUI.Services.Account.Abstract;
public interface IAccountService
{
    public Task<bool> RegisterAsync(RegisterViewModel registerViewModel, IFormFile profileImageFile);
    public Task<bool> LoginAsync(LoginViewModel loginViewModel);
    public Task<bool> LogOutAsync();
}
