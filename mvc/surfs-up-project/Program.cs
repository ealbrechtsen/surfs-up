using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using surfs_up_project.Models;

var builder = WebApplication.CreateBuilder(args);

// Tilføj HttpClient med Dependency Injection
builder.Services.AddHttpClient();  // Dette tillader AccountController at lave API-kald via HttpClient

// Tilføj controller og views
builder.Services.AddControllersWithViews();

// Identity og database services kan tilføjes her, hvis du har dem i projektet
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddIdentity<AppUser, IdentityRole>()
//     .AddEntityFrameworkStores<AppDbContext>()
//     .AddDefaultTokenProviders();

var app = builder.Build();

// Middleware
app.UseStaticFiles();  // For at servere statiske filer som CSS, JavaScript, etc.
app.UseRouting();
app.UseAuthentication();  // Hvis du bruger authentication (ex. med Identity)
app.UseAuthorization();   // Hvis du bruger roles eller policies

// Kortlægning af ruter
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Database seeding (hvis nødvendigt)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    // Hvis du vil lave seed logik, kan du køre det her
    // SeedDatabase(app);
}

app.Run();