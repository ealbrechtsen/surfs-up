var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.

builder.Services.AddControllersWithViews(); 

var app = builder.Build();

app.UseStaticFiles();


app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
