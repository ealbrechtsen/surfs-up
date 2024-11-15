using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using surfs_up_project.Models;


namespace surfs_up_project.Controllers
{
    public class RentalController : Controller
    {
        private readonly string apiUrl = "https://localhost:7010/api/"; // 7010 is defined when creating project
        public async Task<IActionResult> Boards()
        {
            // Define empty list of products
            List<Product>? products = [];

            // Create httpClient to handle request
            using (var httpClient = new HttpClient())
            {
                // Call API and await response
                using (var response = await httpClient.GetAsync(apiUrl + "rental/boards/"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        // If success, add products to list
                        string payload = await response.Content.ReadAsStringAsync();
                        products = JsonConvert.DeserializeObject<List<Product>>(payload);
                    }
                    else
                    {
                        // Otherwise return error
                        return BadRequest($"API request failed with status code {response.StatusCode}");
                    }
                }
            }
            return View(products);
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
