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
builder.Services.AddHttpClient(); //CORS i�in ekleniyor.
builder.Services.AddDbContext<TraversalContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<TraversalContext>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<TraversalContext>(); //�ifremi unuttum mu k�sm� i�in Token i�lemi
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<validatorFinder>()); //Burada fluentvalidation� sisteme tan�ml�yoruz. Burada validator olarak olu�turdu�um s�n�flar� bulabilmesi i�in validationFinder s�n�f�n� Business katman� i�inde olu�turup burada tan�ml�yorum.

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
}); //Dil deste�inin bak�laca�� klas�r�n ad� veriliyor.




//CQRS Dependency Injection
builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationByIdQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<DeleteDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();

//MediatR kullan�ld��� i�in 
builder.Services.AddMediatR(typeof(Program)); //typeof kullan�larak dependency injection� bu �ekilde otomatik tan�ml�yoruz.

//UnitOfWork Service
builder.Services.AddScoped<IAccountService, AccountManager>();
builder.Services.AddScoped<IAccountDAL, EFAccountDAL>();
builder.Services.AddScoped<IUowDAL, UowDAL>();

//Logging i�lemi
builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    //Burada loglevel seviyesi belirleniyor. Log i�lemi nereden itibaren ba�layacak onu se�iyoruz.
    x.SetMinimumLevel(LogLevel.Debug);
    //Bu loglar�n nereye loglanaca��n� g�steriyor
    x.AddDebug();
    //Burada hata loglar�n�n nereye yaz�laca��n� belirtiyoruz. Anadizine Logs ad�nda bir klas�r i�ine yazacak. Log seviyesini de�i�tirebiliriz, projemiz i�in error seviyesinde logluyoruz.
    x.AddFile($"{Directory.GetCurrentDirectory()}\\Logs\\log.txt", LogLevel.Error);
});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = new PathString("/error/error403");
    options.LoginPath = new PathString("/Login/Index");
    options.LogoutPath = new PathString("/Login/LogOut");
});

//Proje seviyesinde authentication i�lemi
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization(); //Dil deste�i i�in ekleniyor.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var supportedCultures = new[] { "tr", "en", "fr", "es", "gr", "de" };//Desteklenecek dillerin �n eklerini (suffixlerini giriyoruz)

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0]) // Default to Turkish if that's your main language
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions); //Dil konfig�rasyonlar� 


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/error/error404", "?code={0}"); //404 hatas� i�in.

app.UseRouting();
//authentication mutlaka authorizationdan �nce olmal�.
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
