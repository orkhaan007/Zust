using SocialMedia.Core.DataAccess.Concrete;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities.Data;
using SocialMedia.Entities.Models;

namespace SocialMedia.DataAccess.Concrete;
public class CommentDal : EFEntityRepositoryBase<Comment,ZustDBContext>,ICommentDal
{
    public CommentDal(ZustDBContext context) : base(context) { }
}
