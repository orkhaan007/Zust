using Microsoft.AspNetCore.Mvc;
using SocialMedia.Business.Abstract;

namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FriendRequestController : ControllerBase
{
    private readonly IFriendRequestService _friendRequestService;

    public FriendRequestController(IFriendRequestService friendRequestService)
    {
        _friendRequestService = friendRequestService;
    }

    [HttpGet("SendFriendRequest")]
    public async Task<IActionResult> SendFriendRequest(string receiverId)
    {
        await _friendRequestService.SendFriendRequestAsync(receiverId);
        return Ok();
    }

    [HttpGet("AcceptFriendRequest")]
    public async Task<IActionResult> AcceptFriendRequest(string senderId)
    {
        await _friendRequestService.AcceptFriendRequestAsync(senderId);
        return Ok();
    }

    [HttpGet("RejectFriendRequest")]
    public async Task<IActionResult> RejectFriendRequest(string senderId)
    {
        await _friendRequestService.RejectFriendRequestAsync(senderId);
        return Ok();
    }

    [HttpGet("CancelFriendRequest")]
    public async Task<IActionResult> CancelFriendRequest(string receiverId)
    {
        await _friendRequestService.CancelFriendRequestAsync(receiverId);
        return Ok();
    }

    [HttpGet("GetAllFriendRequestsOfCurrentUser")]
    public async Task<IActionResult> GetAllFriendRequestsOfCurrentUser(string key = "")
    {
        var friendRequests = await _friendRequestService.GetFriendRequestsCurrentUserAsync(key);
        return Ok(new { FriendRequests = friendRequests });
    }

    [HttpGet("GetAllFriendRequests")]
    public async Task<IActionResult> GetAllFriendRequests()
    {
        var allFriendRequests = await _friendRequestService.GetAllFriendRequestsAsync();
        return Ok(new {AllFriendRequests = allFriendRequests});
    }

    [HttpGet("GetAllSentFriendRequestsOfCurrentUser")]
    public async Task<IActionResult>GetAllSentFriendRequestsOfCurrentUserAsync()
    {
        var sentFriendRequests = await _friendRequestService.GetAllSentFriendRequestsOfCurrentUserAsync();
        return Ok(new {SentFriendRequests = sentFriendRequests});
    }
}
