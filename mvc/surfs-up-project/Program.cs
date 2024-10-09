using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using surfs_up_project.Models;

var builder = WebApplication.CreateBuilder(args);

// Tilf�j HttpClient med Dependency Injection
builder.Services.AddHttpClient();  // Dette tillader AccountController at lave API-kald via HttpClient

// Tilf�j controller og views
builder.Services.AddControllersWithViews();

// Identity og database services kan tilf�jes her, hvis du har dem i projektet
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

// Kortl�gning af ruter
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Database seeding (hvis n�dvendigt)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    // Hvis du vil lave seed logik, kan du k�re det her
    // SeedDatabase(app);
}

app.Run();