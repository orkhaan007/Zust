﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialMedia.Entities.Data;

#nullable disable

namespace SocialMedia.Entities.Migrations
{
    [DbContext(typeof(ZustDBContext))]
    [Migration("20241015153719_DB1")]
    partial class DB1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("User1Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User2Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("User1Id");

                    b.HasIndex("User2Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.CustomIdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.CustomIdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("BackgroundImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConnectTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DisconnectTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OwnId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("YourFriendId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OwnId");

                    b.HasIndex("YourFriendId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.FriendRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AcceptedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.LikeComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LikedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("LikesComments");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.LikePost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LikedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("LikesPosts");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NotificationText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("bit");

                    b.Property<int>("PostType")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Chat", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "User1")
                        .WithMany("Chats")
                        .HasForeignKey("User1Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "User2")
                        .WithMany()
                        .HasForeignKey("User2Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Comment", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Friend", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "Own")
                        .WithMany("Friends")
                        .HasForeignKey("OwnId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "YourFriend")
                        .WithMany()
                        .HasForeignKey("YourFriendId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Own");

                    b.Navigation("YourFriend");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.FriendRequest", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "Sender")
                        .WithMany("FriendRequests")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.LikeComment", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.Comment", "Comment")
                        .WithMany("Likes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.LikePost", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Message", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Chat");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Notification", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "Receiver")
                        .WithMany("ReceivedNotifications")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "Sender")
                        .WithMany("SentNotifications")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Post", b =>
                {
                    b.HasOne("SocialMedia.Entities.Models.CustomIdentityUser", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Comment", b =>
                {
                    b.Navigation("Likes");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.CustomIdentityUser", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("FriendRequests");

                    b.Navigation("Friends");

                    b.Navigation("Posts");

                    b.Navigation("ReceivedNotifications");

                    b.Navigation("SentNotifications");
                });

            modelBuilder.Entity("SocialMedia.Entities.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
