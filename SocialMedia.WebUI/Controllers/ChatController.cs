using Microsoft.AspNetCore.Mvc;
using SocialMedia.Business.Abstract;

namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpGet("GetChatMessages")]
    public async Task<IActionResult> GetChatMessages(string user1Id,string user2Id)
    {
        var chat = await _chatService.GetChatAsync(user1Id, user2Id);
        return Ok(new { Messages = chat.Messages});
    }

    [HttpGet("GetChatBySenderReceiverId")]
    public async Task<IActionResult> GetChatBySenderReceiverId(string user1Id,string user2Id)
    {
        var chat = await _chatService.GetChatAsync(user1Id,user2Id);
        return Ok(new {Chat = chat});
    }

    [HttpGet("GetChatsBySenderOrReceiver")]
    public async Task<IActionResult> GetChatsBySenderOrReceiver(string id)
    {
        var chats = await _chatService.GetChatsByReceiverOrSenderIdAsync(id);
        return Ok(new { Chats = chats });
    }

    [HttpGet("ClearChatMessages")]
    public async Task<IActionResult> ClearChatMessages(string user1Id,string user2Id)
    {
        var chat = await _chatService.GetChatAsync(user1Id, user2Id);
        await _chatService.DeleteChatAsync(user1Id, user2Id);
        return Ok();
    }
}
