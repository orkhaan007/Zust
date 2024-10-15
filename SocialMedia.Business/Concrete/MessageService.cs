using SocialMedia.Business.Abstract;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities.Models;

namespace SocialMedia.Business.Concrete;
public class MessageService : IMessageService
{
                                                                                                                                                    
    private readonly IMessageDal _messageDal;

                                                                                                                                                    
    public MessageService(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }

                                                                                                                                                    
    public async Task AddMessageAsync(int chatId, string senderId, string receiverId, string messageText)
    {
        var msg = new Message
        {
            ChatId = chatId,
            SenderId = senderId,
            ReceiverId = receiverId,
            MessageText = messageText,
            IsRead = false,
            SentAt = DateTime.Now,
        };
        await _messageDal.AddAsync(msg);
    }
}
