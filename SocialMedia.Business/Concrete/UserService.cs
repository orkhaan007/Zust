//using Microsoft.AspNetCore.Http;
//using SocialMedia.Business.Abstract;
//using SocialMedia.DataAccess.Abstract;

//namespace SocialMedia.Business.Concrete
//{
//    public class UserService : IUserService
//    {
//        private readonly IUserDal _userDal;
//        private readonly IImageService _imageService;

//        public UserService(IUserDal userDal, IImageService imageService)
//        {
//            _userDal = userDal;
//            _imageService = imageService;
//        }

//        public async Task<bool> UploadCoverImageAsync(int userId, IFormFile file)
//        {
//            var folderName = "banners";
//            var imageUrl = await _imageService.SaveFileAsync(file, folderName);

//            if (string.IsNullOrEmpty(imageUrl))
//            {
//                return false;
//            }

//            var user = await _userDal.GetByIdAsync(userId);

//            if (user == null)
//            {
//                return false;
//            }

//            user.BackgroundImageUrl = imageUrl;
//            await _userDal.UpdateAsync(user);

//            return true;
//        }

//    }
//}
