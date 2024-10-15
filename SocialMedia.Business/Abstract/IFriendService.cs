using SocialMedia.Entities.Models;

namespace SocialMedia.Business.Abstract;
public interface IFriendService
{
    public Task<List<Friend>> GetFriendsOfCurrentUserAsync(string key = "");
    public Task RemoveFriendAsync(string friendId);
    public Task AddFriendAsync(string friendId);
    public Task<List<CustomIdentityUser>> GetOtherPeopleAsync(string key = "");
}
