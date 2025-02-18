using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using MyProject101.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();


// builder.Services.Configure<IdentityOptions>(options => {
//     options.Password.RequiredLength = 2;
//     options.Password.RequireNonAlphanumeric = false;
//     options.Password.RequireLowercase = false;
//     options.Password.RequireUppercase = false;
//     options.Password.RequireDigit = false;

//     options.User.RequireUniqueEmail = true;
//     options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

//     options.Lockout.MaxFailedAccessAttempts = 5;
//     options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);


// });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
