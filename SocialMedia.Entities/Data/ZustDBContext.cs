using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Entities.Models;

namespace SocialMedia.Entities.Data;
public class ZustDBContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
{
    public ZustDBContext(DbContextOptions<ZustDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyCustomConfigurations();
    }

    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<LikePost> LikesPosts { get; set; }
    public virtual DbSet<LikeComment> LikesComments { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<Chat> Chats { get; set; }
    public virtual DbSet<Friend> Friends { get; set; }
    public virtual DbSet<FriendRequest> FriendRequests { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }
}