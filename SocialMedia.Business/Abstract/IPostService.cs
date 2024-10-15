using SocialMedia.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Business.Abstract
{
    public interface IPostService
    {
        public Task<Post> CreatePostAsync(Post post);
        public Task<Post> UpdatePostAsync(Post post);
        public Task<Post> GetPostByIdAsync(int postId);
        public Task<List<Post>> GetAllPostsAsync();
        public Task<List<Post>> GetPostsByUserAsync(string userId);
        public Task DeletePostAsync(int postId);
        public Task HidePostAsync(int postId);
        public Task LikePostAsync(int postId, string userId);
        public Task UnlikePostAsync(int postId, string userId);
        public Task AddCommentAsync(int postId, string commentText, string userId);
        Task<List<Comment>> GetCommentsByPostIdAsync(int postId);
    }
}
