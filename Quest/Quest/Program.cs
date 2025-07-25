using System;
using Microsoft.EntityFrameworkCore;
using QuestApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<QuestDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();



// Seed данни само ако сме в development
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<QuestDbContext>();
    db.Database.Migrate(); // по избор, ако ползваш миграции

    if (!db.AccessLinks.Any())
    {
        var accessLink = new AccessLink
        {
            Id = 1,
            Code = "TESTACCESS1",
            MaxUses = 10,
            UsedCount = 0,
            Expiration = DateTime.UtcNow.AddMonths(1)
        };

        var session = new GameSession
        {
            Id = 1,
            AccessLinkId = accessLink.Id,
            StartedAt = DateTime.UtcNow,
            DurationSeconds = 1800,
            IsActive = true
        };

        var payment = new Payment
        {
            Id = 1,
            AccessLinkId = accessLink.Id,
            StripePaymentId = "test_123456",
            PaidAt = DateTime.UtcNow,
            Amount = 19.99M,
            IsConfirmed = true
        };

        db.AccessLinks.Add(accessLink);
        db.GameSessions.Add(session);
        db.Payments.Add(payment);

        db.SaveChanges();
    }
}

    app.Run();
