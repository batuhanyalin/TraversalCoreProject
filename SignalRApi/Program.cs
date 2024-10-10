using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Hubs;
using SignalRApi.Model;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<VisitorService>();
builder.Services.AddSignalR();
//Consume üzerinden API tüketilmesini saðlayan izni veren metottur. Dýþarýdan herhangi bir kaynaðýn bu serverý yani api ý consume edilmesine olanak saðlar.
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials();
    }));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); //VisitorControllerda DateTime.Now olarak deðer atamasý için kullanýlýyor.
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(opt =>

    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy"); //Burada oluþturulan Corse çaðrýlýyor.
app.UseAuthorization();

app.MapControllers();
app.MapHub<VisitorHub>("/VisitorHub"); //Burada API consume iþleminde nerenin consume edileceðini gösteriyoruz.

app.Run();

