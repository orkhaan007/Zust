using SocialMedia.Core.DataAccess.Concrete;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities.Data;
using SocialMedia.Entities.Models;

namespace SocialMedia.DataAccess.Concrete;
public class ChatDal : EFEntityRepositoryBase<Chat,ZustDBContext>,IChatDal
{
    public ChatDal(ZustDBContext context) : base(context) { } 
}