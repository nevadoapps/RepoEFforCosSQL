using System.Collections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RepoEFCosSQLWeb.ConfigurationOptions;
using RepoEFCosSQLWeb.Context;
using RepoEFCosSQLWeb.Entities;
using RepoEFCosSQLWeb.Enums;
using RepoEFCosSQLWeb.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("AppSettings.json");

IConfiguration configuration = builder.Configuration;
AppSettings appSettings = new();
configuration.Bind(appSettings);

builder.Services.Configure<AppSettings>(configuration);

if (appSettings.ConnectionStrings.Where(f => f.IsActive).Count() == 1)
{
    string? connStr = string.Empty;
    CommonEnums.ConnType? connType;
    (connStr, connType) = GetConfiguration(appSettings);

    switch (connType)
    {
        case CommonEnums.ConnType.Sql:
            builder.Services.AddSqlDb();
            break;
        case CommonEnums.ConnType.Cosmos:
            builder.Services.AddCosmosDb();
            break;
        case null:
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Seed Data
using (var scope = app.Services.CreateScope())
{
    using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
    {
        Random rnd = new Random();
        var players = GetPlayers();
        context.Players.AddRange(players);
        context.SaveChanges();

        static IEnumerable<PlayerEntity> GetPlayers()
        {
            Random rnd = new Random();
            List<PlayerEntity> players = new();

            for (int i = 0; i < 100; i++)
            {
                players.Add(new PlayerEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"Player - {rnd.Next(10000000, 99999999)}",
                    Email = $"player{rnd.Next(10000000, 99999999)}@player.com",
                    IsActive = rnd.Next(0, 1) == 1 ? true : false
                });
            }

            return players.AsEnumerable();
        }
    }
}

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

static (string, CommonEnums.ConnType) GetConfiguration(AppSettings appSettings)
{
    if (appSettings.ConnectionStrings.Where(f => f.IsActive).Count() == 1)
    {
        return appSettings.ConnectionStrings.Where(f => f.IsActive == true)
            .Select(s => (s.ConnString, s.ConnType)).FirstOrDefault();
    }
    else
    {
        return (string.Empty, 0);
    }
}

