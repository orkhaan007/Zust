using SocialMedia.Core.DataAccess.Concrete;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities.Data;
using SocialMedia.Entities.Models;

namespace SocialMedia.DataAccess.Concrete;
public class LikeCommentDal : EFEntityRepositoryBase<LikeComment,ZustDBContext>,ILikeCommentDal
{
    public LikeCommentDal(ZustDBContext context) : base(context) { }
}
