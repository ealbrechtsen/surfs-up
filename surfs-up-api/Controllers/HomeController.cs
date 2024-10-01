using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using surfs_up_api.Models;

namespace surfs_up_api.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            //Dependency injection
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {

            var products = _appDbContext.Products.ToList();
            return View();
        }
    }
}
