using SocialMedia.Core.Abstraction;

namespace SocialMedia.Entities.Models;
public class Friend : IEntity
{
    public int Id { get; set; }

    public string? YourFriendId { get; set; }
    public string? OwnId { get; set; }

    public virtual CustomIdentityUser? YourFriend { get; set; }
    public virtual CustomIdentityUser ? Own { get; set; }
}
