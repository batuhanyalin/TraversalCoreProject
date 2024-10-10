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
//Consume �zerinden API t�ketilmesini sa�layan izni veren metottur. D��ar�dan herhangi bir kayna��n bu server� yani api � consume edilmesine olanak sa�lar.
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials();
    }));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); //VisitorControllerda DateTime.Now olarak de�er atamas� i�in kullan�l�yor.
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(opt =>

    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy"); //Burada olu�turulan Corse �a�r�l�yor.
app.UseAuthorization();

app.MapControllers();
app.MapHub<VisitorHub>("/VisitorHub"); //Burada API consume i�leminde nerenin consume edilece�ini g�steriyoruz.

app.Run();

