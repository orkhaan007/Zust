namespace SocialMedia.WebUI.Services.Other.Abstract;
public interface IImageService
{
    public Task<string> SaveFileAsync(IFormFile file, string folderName);
}