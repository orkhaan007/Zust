using SocialMedia.Core.Abstraction;

namespace SocialMedia.Entities.Models;
public class Notification : IEntity
{
    public int Id { get; set; }

    public virtual CustomIdentityUser ? Receiver { get; set; }
    public virtual CustomIdentityUser ? Sender { get; set; }

    public string ? ReceiverId { get; set; }
    public string ? SenderId { get; set; }

    public DateTime SentAt { get; set; }
    public string ? NotificationText { get; set; }
}
