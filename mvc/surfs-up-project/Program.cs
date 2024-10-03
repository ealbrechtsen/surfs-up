using Microsoft.EntityFrameworkCore;
using surfs_up_project.Data;
using Microsoft.AspNetCore.Identity;
using surfs_up_project.Models;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CustomerConnection");

var connectionString1 = builder.Configuration.GetConnectionString("DbConnectionString");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString1));


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CustomerDbContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<AppUser, IdentityRole> (
    options =>
    {
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
    }
    )
    .AddEntityFrameworkStores<CustomerDbContext>().AddDefaultTokenProviders();



builder.Services.AddDbContext<CustomerDbContext>(options => options.UseSqlServer(connectionString));



var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

//SeedDatabase(app);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleInitializer.InitializeAsync(services);
}

app.Run();


/*
// Program.cs SEEDING LOGIC (Måske)
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