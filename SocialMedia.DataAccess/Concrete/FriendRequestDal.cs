using SocialMedia.Core.DataAccess.Concrete;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities.Data;
using SocialMedia.Entities.Models;

namespace SocialMedia.DataAccess.Concrete;
public class FriendRequestDal : EFEntityRepositoryBase<FriendRequest,ZustDBContext>,IFriendRequestDal
{
    public FriendRequestDal(ZustDBContext context) : base(context) { }
}
