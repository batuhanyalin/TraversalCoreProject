using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Serilog;
using System.Reflection;
using TraversalCoreProject.BusinessLayer;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.BusinessLayer.Concrete;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.DataAccessLayer.EntityFramework;
using TraversalCoreProject.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TraversalContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<TraversalContext>().AddErrorDescriber<CustomIdentityValidator>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<validatorFinder>()); //Burada fluentvalidationý sisteme tanýmlýyoruz. Burada validator olarak oluþturduðum sýnýflarý bulabilmesi için validationFinder sýnýfýný Business katmaný içinde oluþturup burada tanýmlýyorum.
builder.Services.AddScoped<IAboutDAL, EFAboutDAL>();
builder.Services.AddScoped<IIndexBannerDAL, EFIndexBannerDAL>();
builder.Services.AddScoped<IContactDAL, EFContactDAL>();
builder.Services.AddScoped<IContactPageDAL, EFContactPageDAL>();
builder.Services.AddScoped<IDestinationDAL, EFDestinationDAL>();
builder.Services.AddScoped<IDestinationMatchGuideDAL, EFDestinationMatchGuideDAL>();
builder.Services.AddScoped<IGuideDAL, EFGuideDAL>();
builder.Services.AddScoped<INewsletterDAL, EFNewsletterDAL>();
builder.Services.AddScoped<ISocialMediaDAL, EFSocialMediaDAL>();
builder.Services.AddScoped<ITestimonialDAL, EFTestimonialDAL>();
builder.Services.AddScoped<ITagDAL, EFTagDAL>();
builder.Services.AddScoped<IDestinationTagDAL, EFDestinationTagDAL>();
builder.Services.AddScoped<ICommentDAL, EFCommentDAL>();
builder.Services.AddScoped<IReservationDAL, EFReservationDAL>();

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
builder.Services.AddScoped<ITagService, TagManager>();
builder.Services.AddScoped<IDestinationTagService, DestinationTagManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IReservationService, ReservationManager>();

//Logging iþlemi
builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    //Burada loglevel seviyesi belirleniyor. Log iþlemi nereden itibaren baþlayacak onu seçiyoruz.
    x.SetMinimumLevel(LogLevel.Debug);
    //Bu loglarýn nereye loglanacaðýný gösteriyor
    x.AddDebug();
    //Burada hata loglarýnýn nereye yazýlacaðýný belirtiyoruz. Anadizine Logs adýnda bir klasör içine yazacak. Log seviyesini deðiþtirebiliriz, projemiz için error seviyesinde logluyoruz.
    x.AddFile($"{Directory.GetCurrentDirectory()}\\Logs\\log.txt", LogLevel.Error);
});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = new PathString("/error/error403");
    options.LoginPath = new PathString("/Login/Index");
    options.LogoutPath = new PathString("/Login/LogOut");
});

//Proje seviyesinde authentication iþlemi
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();


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
app.UseStatusCodePagesWithReExecute("/error/error404", "?code={0}"); //404 hatasý için.

app.UseRouting();
//authentication mutlaka authorizationdan önce olmalý.
app.UseAuthentication();
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
