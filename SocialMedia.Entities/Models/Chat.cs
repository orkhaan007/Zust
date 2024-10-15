using SocialMedia.Core.Abstraction;

namespace SocialMedia.Entities.Models;
public class Chat : IEntity
{
                                                                                                                                                     
    public int Id { get; set; }

                                                                                                                                                    
    public virtual CustomIdentityUser ? User1{ get; set; }
    public virtual CustomIdentityUser ? User2{ get; set; }
    public virtual ICollection<Message> ? Messages { get; set; }

                                                                                                                                                     
    public string ? User1Id { get; set; }
    public string ? User2Id { get; set; }

                                                                                                                                                   
    public Chat()
    {
        Messages = new List<Message>();
    }
}
