using SocialMedia.Core.Abstraction;
using SocialMedia.Entities.Enums;

namespace SocialMedia.Entities.Models;
public class Post : IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsHidden { get; set; }
    public string ? Description {  get; set; }
    public string ? Url { get; set; }
    public PostType PostType { get; set; }

    public virtual CustomIdentityUser ? User { get; set; }
    public virtual ICollection<LikePost> ? Likes { get; set; }
    public virtual ICollection<Comment> ? Comments { get; set; }
    
    public string ? UserId { get; set; }

    public Post()
    {
        Likes = new List<LikePost>();
        Comments = new List<Comment>();
    }
}
