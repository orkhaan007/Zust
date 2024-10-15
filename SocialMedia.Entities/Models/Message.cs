using SocialMedia.Core.Abstraction;

namespace SocialMedia.Entities.Models;
public class Message : IEntity
{
    public int Id { get; set; }

    public string? SenderId { get; set; }
    public string? ReceiverId { get; set; }
    public int ChatId { get; set; }

    public virtual CustomIdentityUser? Sender { get; set; }
    public virtual CustomIdentityUser? Receiver { get; set; }
    public virtual Chat ? Chat { get; set; }

    public string? MessageText { get; set; }
    public DateTime SentAt { get; set; }
    public bool IsRead { get; set; }
}