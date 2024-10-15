using SocialMedia.Core.Abstraction;

namespace SocialMedia.Entities.Models;
public class LikePost : IEntity
{
    public int Id { get; set; }

    public string ? UserId { get; set; }
    public int PostId { get; set; }

    public virtual CustomIdentityUser ? User { get; set; }
    public virtual Post ? Post { get; set; }

    public DateTime LikedAt { get; set; }
}
