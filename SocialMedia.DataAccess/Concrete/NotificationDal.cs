using SocialMedia.Core.DataAccess.Concrete;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities.Data;
using SocialMedia.Entities.Models;

namespace SocialMedia.DataAccess.Concrete;

public class NotificationDal : EFEntityRepositoryBase<Notification,ZustDBContext>,INotificationDal
{
    public NotificationDal(ZustDBContext context) : base(context) { }
}
