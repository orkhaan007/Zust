using Microsoft.AspNetCore.Mvc;
using SocialMedia.Business.Abstract;

namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FriendController : ControllerBase
{
    private readonly IFriendService _friendService;

    public FriendController(IFriendService friendService)
    {
        _friendService = friendService;
    }

    [HttpGet("RemoveFriend")]
    public async Task<IActionResult> RemoveFriend(string friendId)
    {
        await _friendService.RemoveFriendAsync(friendId);
        return Ok();
    }

    [HttpGet("GetAllFriendsOfCurrentUser")]
    public async Task<IActionResult> GetAllFriendsOfCurrentUser(string key = "")
    {
        var allFriends =await _friendService.GetFriendsOfCurrentUserAsync(key);
        return Ok(new { AllFriends = allFriends});
    }

    [HttpGet("GetOtherPeople")]
    public async Task<IActionResult> GetOtherPeople(string key = "")
    {
        var otherPeople = await _friendService.GetOtherPeopleAsync(key);
        return Ok(new {OtherPeople = otherPeople});
    }
}
