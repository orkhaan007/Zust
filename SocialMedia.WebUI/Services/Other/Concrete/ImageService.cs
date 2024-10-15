using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using SocialMedia.Entities.Models;
using SocialMedia.WebUI.Services.Other.Abstract;

namespace SocialMedia.WebUI.Services.Other.Concrete;
public class ImageService : IImageService
{
    private readonly Cloudinary _cloudinary;

    public ImageService(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<string> SaveFileAsync(IFormFile file, string folderName)
    {
        if (file != null && file.Length > 0)
        {
            try
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + Guid.NewGuid() + Path.GetExtension(file.FileName);
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
                    Folder = folderName,
                    PublicId = fileName
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return uploadResult.Uri.ToString();
                }
                else
                {
                    throw new Exception("Image upload failed: " + uploadResult.Error.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading image: {ex.Message}");
                return null;
            }
        }

        return null;
    }

}