using Classical_Music_Library_Web_App.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

// 1. Explicit configuration setup
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

// 2. Connection string with multiple fallbacks
var connectionString = config.GetConnectionString("DefaultConnection")
    ?? config.GetConnectionString("LocalDB")
    ?? "Server=(localdb)\\MSSQLLocalDB;Database=ClassicalMusicLibrary;Trusted_Connection=True;TrustServerCertificate=True;";

// Debug output
Console.WriteLine("=== Configuration Verification ===");
Console.WriteLine($"Config File: {Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")}");
Console.WriteLine($"Using Connection: {connectionString}");

// 3. DbContext configuration with validation
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MusicDbContext>(options =>
{
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    });

    // Debugging aids (remove in production)
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});

builder.Services.AddControllersWithViews();
var app = builder.Build();

// 4. Immediate database test
Console.WriteLine("\n=== Database Initialization ===");
try
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<MusicDbContext>();

        if (!db.Database.CanConnect())
        {
            Console.WriteLine("Creating database and applying migrations...");
            db.Database.Migrate();
        }

        Console.WriteLine($"Database state: Connected");
        Console.WriteLine($"Tables detected: {db.Model.GetEntityTypes().Count()}");
    }
}
catch (Exception ex)
{
    Console.WriteLine("\n❌ FATAL DATABASE ERROR:");
    Console.WriteLine(ex.Message);

    if (ex.InnerException != null)
    {
        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
    }

    Console.WriteLine("\nTROUBLESHOOTING:");
    Console.WriteLine("1. Verify SQL Server is running (services.msc)");
    Console.WriteLine("2. For LocalDB, run: sqllocaldb info MSSQLLocalDB");
    Console.WriteLine("3. Check firewall allows port 1433");
    Console.WriteLine("4. Validate appsettings.json exists in output directory");

    return; // Exit application
}

// 5. Standard middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

Console.WriteLine("\nApplication started successfully");
app.Run();