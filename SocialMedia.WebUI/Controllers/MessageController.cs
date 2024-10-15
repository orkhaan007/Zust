using Microsoft.AspNetCore.Mvc;
using SocialMedia.Business.Abstract;
using SocialMedia.DataAccess.Abstract;

namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IMessageDal _messageDal;

    public MessageController(IMessageService messageService, IMessageDal messageDal)
    {
        _messageService = messageService;
        _messageDal = messageDal;
    }

    [HttpGet("AddMessage")]
    public async Task<IActionResult> AddMessage(int chatId,string senderId, string receiverId,string messageText)
    {
        await _messageService.AddMessageAsync(chatId, senderId, receiverId, messageText);
        return Ok();
    }

    [HttpGet("SetMessagesReaden")]
    public async Task<IActionResult> SetMessagesReaden(string senderId, string receiverId)
    {
        var messages = await _messageDal.GetListAsync();
        foreach (var message in messages)
        {
            if (message.SenderId == senderId && message.ReceiverId == receiverId)
            {
                message.IsRead = true;
                await _messageDal.UpdateAsync(message);
            }
        }
        return Ok();
    }
}
