using Microsoft.AspNetCore.Http.Features;
using PLPhtotsWebAP.Models;
using PLPhtotsWebAP.Repository;
using PLPhtotsWebAP.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//auth
builder.Services.AddAuthentication("Cookies").AddCookie();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IPictureAppService, PictureAppService>();
builder.Services.AddScoped<IPictureRepository, PictureRepository>();

builder.Services.Configure<FormOptions>(options =>
{
    // Set the limit to 256 MB
    options.MultipartBodyLengthLimit = 256 * 1024 * 1024;
    options.MultipartBoundaryLengthLimit = 256 * 1024 * 1024;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//load config file
var config = app.Configuration;
string containerName = config.GetValue<string>("AzureBlobContainerName");
PictureRepository.ContainerName = containerName;
PictureRepository.BlobConnectionString = config.GetConnectionString("AzureBlobContainer");
PictureRepository.TableConnectionString = config.GetConnectionString("AzureTable");
PictureRepository.CDNDomain = config.GetValue<string>("PicDomain");
AlbumRepository.TableConnectionString = config.GetConnectionString("AzureTable");
UserData.UserName = config.GetSection("AdminUser").GetValue<string>("User");
UserData.UserPassword = config.GetSection("AdminUser").GetValue<string>("Password");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
