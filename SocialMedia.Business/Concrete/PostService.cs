using SocialMedia.Business.Abstract;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Business.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostDal _postDal;

        public PostService(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            post.CreatedAt = DateTime.Now;
            await _postDal.AddAsync(post);
            return post;
        }

        public async Task<Post> UpdatePostAsync(Post post)
        {
            var existingPost = await _postDal.GetByIdAsync(post.Id);
            if (existingPost == null) throw new Exception("Post not found");

            existingPost.Description = post.Description;
            existingPost.Url = post.Url;
            existingPost.PostType = post.PostType;
            existingPost.IsHidden = post.IsHidden;

            await _postDal.UpdateAsync(existingPost);
            return existingPost;
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            return await _postDal.GetByIdAsync(postId);
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _postDal.GetAllAsync();
        }

        public async Task<List<Post>> GetPostsByUserAsync(string userId)
        {
            return await _postDal.GetPostsByUserAsync(userId);
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await _postDal.GetByIdAsync(postId);
            if (post == null) throw new Exception("Post not found");

            await _postDal.DeleteAsync(post);
        }

        public async Task HidePostAsync(int postId)
        {
            var post = await _postDal.GetByIdAsync(postId);
            if (post == null) throw new Exception("Post not found");

            post.IsHidden = true;
            await _postDal.UpdateAsync(post);
        }

        public async Task LikePostAsync(int postId, string userId)
        {
            var post = await _postDal.GetByIdAsync(postId);
            if (post == null) throw new Exception("Post not found");

            if (!post.Likes.Any(like => like.UserId == userId))
            {
                post.Likes.Add(new LikePost { PostId = postId, UserId = userId });
                await _postDal.UpdateAsync(post);
            }
        }

        public async Task UnlikePostAsync(int postId, string userId)
        {
            var post = await _postDal.GetByIdAsync(postId);
            if (post == null) throw new Exception("Post not found");

            var like = post.Likes.FirstOrDefault(l => l.UserId == userId);
            if (like != null)
            {
                post.Likes.Remove(like);
                await _postDal.UpdateAsync(post);
            }
        }

        public async Task AddCommentAsync(int postId, string commentText, string userId)
        {
            var post = await _postDal.GetByIdAsync(postId);
            if (post == null) throw new Exception("Post not found");

            post.Comments.Add(new Comment { PostId = postId, CommentText = commentText, UserId = userId });
            await _postDal.UpdateAsync(post);
        }

        public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            var post = await _postDal.GetByIdAsync(postId);
            if (post == null) throw new Exception("Post not found");

            return post.Comments.ToList();
        }

    }
}
