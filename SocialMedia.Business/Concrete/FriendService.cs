using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SocialMedia.Business.Abstract;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities.Models;

namespace SocialMedia.Business.Concrete;
public class FriendService : IFriendService
{
                                                                                                                                                    
    private readonly IFriendDal _friendDal;
    private readonly IHttpContextAccessor _context;
    private readonly UserManager<CustomIdentityUser> _userManager;
    private readonly IFriendRequestDal _friendRequestDal;
                                                                                                                                                    
    public FriendService(IFriendDal friendDal, IHttpContextAccessor context, UserManager<CustomIdentityUser> userManager, IFriendRequestDal friendRequestDal)
    {
        _friendDal = friendDal;
        _context = context;
        _userManager = userManager;
        _friendRequestDal = friendRequestDal;
    }

    public async Task AddFriendAsync(string friendId)
    {
        var currentUser = await _userManager.GetUserAsync(_context.HttpContext.User);
        var newFriend = new Friend
        {
            OwnId = currentUser.Id,
            YourFriendId = friendId,
        };
        await _friendDal.AddAsync(newFriend);
    }

    public async Task<List<Friend>> GetFriendsOfCurrentUserAsync(string key = "")
    {
        var currentUser = await _userManager.GetUserAsync(_context.HttpContext.User);
        var friends = await _friendDal.GetListAsync();
        if(key != "") return friends.Where(f => f.YourFriendId == currentUser.Id || f.OwnId == currentUser.Id && f.YourFriend.UserName.Contains(key) || f.Own.UserName.Contains(key)).ToList();
        return friends.Where(f => f.YourFriendId == currentUser.Id || f.OwnId == currentUser.Id).ToList();
    }

    public async Task RemoveFriendAsync(string friendId)
    {
        var currentUser = await _userManager.GetUserAsync(_context.HttpContext.User);
        var friends = await _friendDal.GetListAsync();
        var friendRow = friends.FirstOrDefault(f => f.YourFriendId == friendId && f.OwnId == currentUser.Id || f.OwnId == friendId && f.YourFriendId == currentUser.Id);

        var friendRequests = await _friendRequestDal.GetListAsync();
        var friendRequestRow = friendRequests.FirstOrDefault(fr => fr.SenderId == friendId && fr.ReceiverId == currentUser.Id || fr.ReceiverId == friendId && fr.SenderId == currentUser.Id);
        var friendRequest2Row = friendRequests.FirstOrDefault(fr => fr.SenderId == friendId && fr.ReceiverId == currentUser.Id || fr.ReceiverId == friendId && fr.SenderId == currentUser.Id);

        await _friendDal.DeleteAsync(friendRow);

        await _friendRequestDal.DeleteAsync(friendRequestRow);
        await _friendRequestDal.DeleteAsync(friendRequest2Row);
    }

    public async Task<List<CustomIdentityUser>> GetOtherPeopleAsync(string key = "")
    {
                                                                                                                                                        
        var currentUser = await _userManager.GetUserAsync(_context.HttpContext.User);

                                                                                                                                                        
        var users = await _userManager.Users.ToListAsync();

                                                                                                                                                       
        var currentUserFriends = currentUser.Friends.Select(f => f.YourFriendId).ToList();
        var currentUserFriends2 = currentUser.Friends.Select(f => f.OwnId).ToList();

        var allRequests = await _friendRequestDal.GetListAsync();
        var sentFriendRequests = allRequests.Where(fr => fr.SenderId == currentUser.Id).Select(fr => fr.ReceiverId).ToList();
        var receivedFriendRequests = allRequests.Where(fr => fr.ReceiverId == currentUser.Id).Select(fr => fr.SenderId).ToList();

                                                                                                                                                                                                                                                                                  
                                                                                                                                                        
        var otherUsers = users.Where(u =>
            u.Id != currentUser.Id &&                                                                                                                                                
            !currentUserFriends.Contains(u.Id) && !currentUserFriends2.Contains(u.Id) &&                                                                                                                                                  
            !sentFriendRequests.Contains(u.Id) &&                                                                                                                                                  
            !receivedFriendRequests.Contains(u.Id)                                                                                                                                                 
        );

                                                                                                                                                        
        if (!string.IsNullOrEmpty(key))
        {
            otherUsers = otherUsers.Where(u => u.UserName.Contains(key));
        }

        return otherUsers.ToList();
    }
}
