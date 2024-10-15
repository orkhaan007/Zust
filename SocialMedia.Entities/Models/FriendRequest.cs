using SocialMedia.Core.Abstraction;
using SocialMedia.Entities.Enums;

namespace SocialMedia.Entities.Models;
public class FriendRequest : IEntity
{
    public int Id { get; set; }

    public string ? SenderId { get; set; }
    public string ? ReceiverId { get; set; }

    public virtual CustomIdentityUser? Sender { get; set; }
    public virtual CustomIdentityUser? Receiver { get; set; }

    public DateTime RequestDate { get; set; } 
    public DateTime AcceptedDate { get; set; }
    public RequestStatus Status { get; set; }
}
