using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using surfs_up_project.Models;
using surfs_up_project.Middleware;
using surfs_up_project.Services; // Tilføj denne linje

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ApiLogService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5001/"); // Juster til din API's URL
});
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// Her registrerer vi middleware
app.UseMiddleware<RequestLoggingMiddleware>(); // Tilføj denne linje

//SeedDatabase(app); // Hvis du har seeding logik, kan du genaktivere den her

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
}

app.Run();

/*
void SeedDatabase(IHost app)
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        //dbContext.Database.Migrate();

        if (!dbContext.Products.Any())
        {
            var products = ProductRepository.GetProducts();
            //dbContext.Products.AddRange(ProductRepository.GetProducts());
            dbContext.Products.AddRange(products);
            dbContext.SaveChanges();
        }
    }
}
*/
