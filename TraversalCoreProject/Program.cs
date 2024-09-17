using System.Reflection;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.BusinessLayer.Concrete;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.DataAccessLayer.EntityFramework;
using TraversalCoreProject.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAboutDAL,EFAboutDAL>();
builder.Services.AddScoped<IIndexBannerDAL,EFIndexBannerDAL>();
builder.Services.AddScoped<IContactDAL,EFContactDAL>();
builder.Services.AddScoped<IContactPageDAL, EFContactPageDAL>();
builder.Services.AddScoped<IDestinationDAL, EFDestinationDAL>();
builder.Services.AddScoped<IDestinationMatchGuideDAL, EFDestinationMatchGuideDAL>();
builder.Services.AddScoped<IGuideDAL, EFGuideDAL>();
builder.Services.AddScoped<INewsletterDAL, EFNewsletterDAL>();
builder.Services.AddScoped<ISocialMediaDAL, EFSocialMediaDAL>();
builder.Services.AddScoped<ITestimonialDAL, EFTestimonialDAL>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactPageService, ContactPageManager>();
builder.Services.AddScoped<IDestinationService, DestinationManager>();
builder.Services.AddScoped<IDestinationMatchGuideService, DestinationMatchGuideManager>();
builder.Services.AddScoped<IGuideService, GuideManager>();
builder.Services.AddScoped<INewsletterService, NewsletterManager>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();

builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<IIndexBannerService, IndexBannerManager>();



builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<TraversalContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<TraversalContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
