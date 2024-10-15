namespace SocialMedia.Business.Abstract;
public interface IMessageService
{
    public Task AddMessageAsync(int chatId,string senderId, string receiverId, string messageText);
}
