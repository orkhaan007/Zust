namespace SocialMedia.Business.Abstract;
public interface INotificationService
{
    public Task AddNotificationAsync(string senderId,string receiverId,string notificationText);
    public Task RemoveNotificationAsync(int notificationId);
    public Task RemovingAllNotificationsOfUserAsync(string userId);
}
