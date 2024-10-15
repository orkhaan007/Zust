using System.ComponentModel.DataAnnotations;

namespace SocialMedia.WebUI.Models.Account;
public class RegisterViewModel
{
    [Required]
    public string? Username { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? ConfirmPassword { get; set; }

    [Required(ErrorMessage = "You must accept the privacy policy.")]
    public bool AcceptPrivacy { get; set; }

    public IFormFile? ProfileImageFile { get; set; }
    public IFormFile ? BgImageFile { get; set; }
}
