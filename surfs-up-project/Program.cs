using Microsoft.EntityFrameworkCore;
using surfs_up_project.Data;
using Microsoft.AspNetCore.Identity;
using surfs_up_project.Models;

var builder = WebApplication.CreateBuilder(args);

// Connection strings
var connectionString = builder.Configuration.GetConnectionString("CustomerConnection");
var connectionString1 = builder.Configuration.GetConnectionString("DbConnectionString");

// Database context for AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString1));

// Database context for CustomerDbContext
builder.Services.AddDbContext<CustomerDbContext>(options =>
    options.UseSqlServer(connectionString));

// Identity services
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<CustomerDbContext>()
    .AddDefaultTokenProviders();

// Add services for controllers with views
builder.Services.AddControllersWithViews();

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout after 30 minutes of inactivity
    options.Cookie.HttpOnly = true; // Ensure cookie is only accessible via HTTP (not JavaScript)
    options.Cookie.IsEssential = true; // Mark the session cookie as essential
});

var app = builder.Build();

// Middleware pipeline
app.UseStaticFiles(); // Enable static files

app.UseRouting(); // Enable routing

app.UseAuthentication(); // Enable authentication
app.UseAuthorization(); // Enable authorization

app.UseSession(); // Enable session handling

// Map controller routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Initialize roles if needed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleInitializer.InitializeAsync(services);
}

// Run the application
app.Run();
