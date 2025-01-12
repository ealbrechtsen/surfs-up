using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using surfs_up_project.Models;
using System.Text;


namespace surfs_up_project.Controllers
{
    public class RentalController : Controller
    {
        private readonly string apiUrl = "https://localhost:7010/api"; // 7010 is defined when creating project

        private string csvDefault = @"C:\Users\Asus\source\repos\GIT_surfs-up\mvc\surfs-up-project\wwwroot\default.csv";
        private string csvBoards = @"C:\Users\Asus\source\repos\GIT_surfs-up\mvc\surfs-up-project\wwwroot\boards.csv";

        public async Task<IActionResult> Boards()
        {
            List<Product> productsGet = new List<Product>();

            List<Product> productsPost = new List<Product>();
            // Start

            using (var httpClient = new HttpClient())
            {
                // Post

                using (var response = await httpClient.GetAsync(apiUrl + "/rental/boards"))
                {
                    if (!response.IsSuccessStatusCode) return NotFound(response.StatusCode);
                    else
                    {
                        string payload = await response.Content.ReadAsStringAsync();
                        productsGet = JsonConvert.DeserializeObject<List<Product>>(payload);
                    }
                }
            }

            return View(productsGet);
        }

        public IActionResult Board(int? id)
        {
            var board = ProductRepository.GetProductById(id);
            return View(board);
        }

        //public IActionResult Wetsuit(int? id)
        //{
        //    var board = ProductRepository.GetProductById(id);
        //    return View(board);
        //}

        //public IActionResult Equipment(int? id)
        //{
        //    var board = ProductRepository.GetProductById(id);
        //    return View(board);
        //}
    }
}
