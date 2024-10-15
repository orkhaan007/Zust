using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SocialMedia.Business.Abstract;
using SocialMedia.Business.Concrete;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.DataAccess.Concrete;
using SocialMedia.Entities.Data;
using SocialMedia.Entities.Models;
using SocialMedia.WebUI.Hubs;
using SocialMedia.WebUI.Services.Account.Abstract;
using SocialMedia.WebUI.Services.Account.Concrete;
using SocialMedia.WebUI.Services.Other.Abstract;
using SocialMedia.WebUI.Services.Other.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.WriteIndented = true;
        
    })
    .AddNewtonsoftJson(options =>
    {
                                                                                                                                                       
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    }); 


                                                                                                                                               
var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ZustDBContext>(options =>
{
    options.UseSqlServer(connection);
    options.UseLazyLoadingProxies();
});


builder.Services.AddSession();

builder.Services
    .AddIdentity<CustomIdentityUser, CustomIdentityRole>()
    .AddEntityFrameworkStores<ZustDBContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));
builder.Services.AddSingleton<Cloudinary>(provider =>
{
    var cloudinarySettings = provider.GetRequiredService<IOptions<CloudinarySettings>>().Value;
    var account = new Account(
        cloudinarySettings.CloudName,
        cloudinarySettings.ApiKey,
        cloudinarySettings.ApiSecret
    );
    return new Cloudinary(account);
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IMessageDal, MessageDal>();
builder.Services.AddScoped<IChatDal,ChatDal>();
builder.Services.AddScoped<INotificationDal, NotificationDal>();
builder.Services.AddScoped<IFriendRequestDal,FriendRequestDal>();
builder.Services.AddScoped<IFriendDal,FriendDal>();
builder.Services.AddScoped<IPostDal, PostDal>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IFriendRequestService, FriendRequestService>();
builder.Services.AddScoped<IFriendService, FriendService>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddSignalR();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapHub<ZustHub>("/zustHub");

app.Run();