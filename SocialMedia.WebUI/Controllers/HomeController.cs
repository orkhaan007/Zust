using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Business.Abstract;
using SocialMedia.Entities.Enums;
using SocialMedia.Entities.Models;
using SocialMedia.WebUI.Consts;
using SocialMedia.WebUI.Models;
using SocialMedia.WebUI.Services.Other.Abstract;
using System.Diagnostics;

namespace SocialMedia.WebUI.Controllers;
public class HomeController : Controller
{
    private readonly UserManager<CustomIdentityUser> _userManager;
    private readonly IImageService _imageService;
    private readonly IPostService _postService;
    public HomeController(UserManager<CustomIdentityUser> userManager, IImageService imageService, IPostService postService)
    {
        _userManager = userManager;
        _imageService = imageService;
        _postService = postService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromForm] IFormFile image, [FromForm] string description)
    {
        var currentUser = await _userManager.GetUserAsync(HttpContext.User);
        if (currentUser == null) return Unauthorized();

        string imageUrl = null;
        if (image != null)
        {
            imageUrl = await _imageService.SaveFileAsync(image, "posts");
        }

        var newPost = new Post
        {
            Description = description,
            Url = imageUrl,
            UserId = currentUser.Id,
            CreatedAt = DateTime.Now,
            PostType = PostType.Image,
        };

        await _postService.CreatePostAsync(newPost);

        return Json(new
        {
            id = newPost.Id,
            description = newPost.Description,
            imageUrl = newPost.Url,
            userName = currentUser.UserName,
            userImageUrl = currentUser.ImageUrl
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        var posts = await _postService.GetAllPostsAsync();

        var postList = posts.Where(p => !p.IsHidden)
                            .Select(post => new
                            {
                                id = post.Id,
                                description = post.Description,
                                imageUrl = post.Url,
                                userName = post.User.UserName,
                                userImageUrl = post.User.ImageUrl,
                                createdAt = post.CreatedAt.ToString("dd MMM yyyy hh:mm tt")
                            });

        return Json(postList);
    }


    [HttpDelete("/Home/DeletePost/{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _postService.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        await _postService.DeletePostAsync(post.Id);

        return Ok();
    }

    [HttpPatch("/Home/HidePost/{id}")]
    public async Task<IActionResult> HidePost(int id)
    {
        var post = await _postService.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        post.IsHidden = true;
        await _postService.UpdatePostAsync(post);

        return Ok();
    }

    [HttpPut("Home/EditPost/{id}")]
    public async Task<IActionResult> EditPost(int id, [FromBody] Post updatedPost)
    {
        var post = await _postService.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        post.Description = updatedPost.Description;
        post.Url = updatedPost.Url;

        await _postService.UpdatePostAsync(post);

        return Ok(post);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    public IActionResult Notifications()=> View();

    public IActionResult Friends() => View();

    public IActionResult Messages() => View();

    public async Task<IActionResult> Index()
    {
        var currentUser = await _userManager.GetUserAsync(HttpContext.User);
        if (currentUser != null) return View();
        return RedirectToAction(WebUIConstants.LoginConstant, WebUIConstants.AccountConstant);
    }
}
