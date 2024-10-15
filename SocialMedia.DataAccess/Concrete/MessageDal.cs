using SocialMedia.Core.DataAccess.Concrete;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities.Data;
using SocialMedia.Entities.Models;

namespace SocialMedia.DataAccess.Concrete;
public class MessageDal : EFEntityRepositoryBase<Message,ZustDBContext>,IMessageDal
{
    public MessageDal(ZustDBContext context) : base(context) { }
}
