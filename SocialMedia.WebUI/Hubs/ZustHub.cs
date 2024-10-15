using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using SocialMedia.Entities.Models;

namespace SocialMedia.WebUI.Hubs;
public class ZustHub : Hub
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly UserManager<CustomIdentityUser> _userManager;
    public ZustHub(IHttpContextAccessor contextAccessor, UserManager<CustomIdentityUser> userManager)
    {
        _contextAccessor = contextAccessor;
        _userManager = userManager;
    }

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"User connected: {Context.ConnectionId}");
        await Clients.All.SendAsync("UpdateContacts");
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        if (_contextAccessor.HttpContext != null)
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);

            if (user != null)
            {
                user.IsOnline = false;
                await _userManager.UpdateAsync(user);
            }
        }

        await Clients.All.SendAsync("UpdateContacts");
    }


    public async Task UpdateContactsForAllUsers()
    {
        await Clients.All.SendAsync("UpdateContacts");
    }

    public async Task UpdateContactsForOtherUsers()
    {
        await Clients.Others.SendAsync("UpdateContacts");
    }

   public async Task UpdateUserMessagesForReceiver(string receiverId,string senderId)
    {
        await Clients.User(receiverId).SendAsync("UpdateAllMessages",senderId);
    }

    public async Task UpdateNotificationsForReceiver(string receiverId)
    {
        await Clients.User(receiverId).SendAsync("UpdateNotificationsForReceiver");
    }

    public async Task UpdateFriendRequestsAndFriendsForUsers()
    {
        await Clients.All.SendAsync("UpdateFriendRequestsAndFriends");
    }
}
