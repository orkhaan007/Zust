using SocialMedia.Core.DataAccess.Abstract;
using SocialMedia.Entities.Models;

namespace SocialMedia.DataAccess.Abstract;
public interface IMessageDal : IEntityRepository<Message> { }