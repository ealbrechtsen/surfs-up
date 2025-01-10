using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using surfs_up_project.Models;
using System.Text;


namespace surfs_up_project.Controllers
{
    public class RentalController : Controller
    {
        private readonly string apiUrl = "https://localhost:7010/api/"; // 7010 is defined when creating project


        public async Task<IActionResult> Boards()
        {
            // Define empty list of products
            List<Product>? products = [];

            // Convert CSV to list of Products
            List<Product>? productsToPost = CsvConverter.ToProducts(@"C:\Users\Asus\source\repos\GIT_surfs-up\mvc\surfs-up-project\wwwroot\boards.csv");

            // Serialize list of products to JSON
            string json = JsonConvert.SerializeObject(productsToPost);

            // Create content to send to API
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Create HttpClient instance to handle request
            using (var httpClient = new HttpClient())
            {
                // Call API and await response
                using (var response = await httpClient.PostAsync(apiUrl + "rental/boards/", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        // If success, do nothing
                    }
                    else
                    {
                        // Otherwise return error
                        return BadRequest($"API request failed with status code {response.StatusCode}");
                    }
                }

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
