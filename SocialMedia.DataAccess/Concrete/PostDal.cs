using SocialMedia.Core.DataAccess.Concrete;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities.Data;
using SocialMedia.Entities.Models;

namespace SocialMedia.DataAccess.Concrete;
public class PostDal : EFEntityRepositoryBase<Post,ZustDBContext>,IPostDal
{
    public PostDal(ZustDBContext context) : base(context) { }
}