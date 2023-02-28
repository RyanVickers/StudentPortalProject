using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentPortalProject.Data;
using StudentPortalProject.Models;
using StudentPortalProject.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// Google Auth
builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = "645651591174-09v4da9vl9v2q25von7qur14iu0oclhc.apps.googleusercontent.com";
    googleOptions.ClientSecret = "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";
});

// SignalR -- chat service
builder.Services.AddSignalR();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
var app = builder.Build();
app.MapControllerRoute(
        name: "pusher_auth",
        pattern: "pusher/auth",
        defaults: new { controller = "Auth", action = "ChannelAuth" }
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// SignalR -- chat services
app.MapHub<ChatHub>("/chatHub");

app.Run();
