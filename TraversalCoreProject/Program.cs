using FluentValidation.AspNetCore;
using MediatR;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Serilog;
using System.Reflection;
using TraversalCoreProject.BusinessLayer;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.BusinessLayer.Abstract.AbstractUow;
using TraversalCoreProject.BusinessLayer.Concrete;
using TraversalCoreProject.BusinessLayer.Concrete.ConcreteUow;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.DataAccessLayer.EntityFramework;
using TraversalCoreProject.DataAccessLayer.UnitOfWork;
using TraversalCoreProject.EntityLayer.Concrete;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient(); //CORS için ekleniyor.
builder.Services.AddDbContext<TraversalContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<TraversalContext>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<TraversalContext>(); //Þifremi unuttum mu kýsmý için Token iþlemi
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
builder.Services.AddScoped<IAnnouncementDAL, EFAnnouncementDAL>();
builder.Services.AddScoped<IReservationStatusDAL, EFReservationStatusDAL>();
builder.Services.AddScoped<ICityDAL, EFCityDAL>();
builder.Services.AddScoped<ICountryDAL, EFCountryDAL>();
builder.Services.AddScoped<IContinentDAL, EFContinentDAL>();

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
builder.Services.AddScoped<IExcelService, ExcelManager>();
builder.Services.AddScoped<IPDFService, PDFManager>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();
builder.Services.AddScoped<IReservationStatusService, ReservationStatusManager>();
builder.Services.AddScoped<ICityService, CityManager>();
builder.Services.AddScoped<ICountryService, CountryManager>();
builder.Services.AddScoped<IContinentService, ContinentManager>();

builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
}); //Dil desteðinin bakýlacaðý klasörün adý veriliyor.




//CQRS Dependency Injection
builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationByIdQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<DeleteDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();

//MediatR kullanýldýðý için 
builder.Services.AddMediatR(typeof(Program)); //typeof kullanýlarak dependency injectioný bu þekilde otomatik tanýmlýyoruz.

//UnitOfWork Service
builder.Services.AddScoped<IAccountService, AccountManager>();
builder.Services.AddScoped<IAccountDAL, EFAccountDAL>();
builder.Services.AddScoped<IUowDAL, UowDAL>();

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
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization(); //Dil desteði için ekleniyor.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var supportedCultures = new[] { "tr", "en", "fr", "es", "gr", "de" };//Desteklenecek dillerin ön eklerini (suffixlerini giriyoruz)

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0]) // Default to Turkish if that's your main language
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions); //Dil konfigürasyonlarý 


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/error/error404", "?code={0}"); //404 hatasý için.

app.UseRouting();
//authentication mutlaka authorizationdan önce olmalý.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
