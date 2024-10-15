using SocialMedia.Core.DataAccess.Concrete;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities.Data;
using SocialMedia.Entities.Models;

namespace SocialMedia.DataAccess.Concrete;
public class FriendDal : EFEntityRepositoryBase<Friend,ZustDBContext>,IFriendDal
{
    public FriendDal(ZustDBContext context) : base(context) { }
}
