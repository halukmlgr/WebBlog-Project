using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();//13 ve 14 sat�r �dentity i�in fakat bunu yazd���m�z da blog sayfas� gelmiyor RegisterUser/index gitmek i�in bunu yazmak gerekiyor
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;

}).AddEntityFrameworkStores<Context>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = new PathString("/Login/AccessDenied");
});
// 10. sat�rdan 16.sat�ra kadar yaz�lan kod yetkilendirme i�lemi i�in yap�l�yor.
builder.Services.AddMvc(config =>
{

    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));

});
builder.Services.AddMvc();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)

    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    }
  
    );

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(



//    name: "default",
//    pattern: "{controller=BlogControllers}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}");

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

});

app.Run();
