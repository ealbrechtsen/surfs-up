using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Services; // Juster til dit faktiske namespace
using System.Threading.Tasks;
using surfs_up_project.Services;

namespace YourMvcNamespace.Controllers // Juster til dit faktiske namespace
{
    [Authorize(Roles = "Admin")] // Sørg for, at kun admin kan tilgå denne controller
    public class AdminController : Controller
    {
        private readonly ApiLogService _apiLogService;

        public AdminController(ApiLogService apiLogService)
        {
            _apiLogService = apiLogService;
        }

        public async Task<IActionResult> Index()
        {
            var userApiCallCounts = await _apiLogService.GetApiLogStatisticsAsync();
            return View(userApiCallCounts);
        }
    }
}
