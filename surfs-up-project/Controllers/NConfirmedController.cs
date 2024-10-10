using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;
using surfs_up_project.Data;

public class NConfirmedController : Controller
{
    private readonly NCustomerDbContext _context;
    private ShoppingCart _shoppingCart = new ShoppingCart();

    public NConfirmedController(NCustomerDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SaveCustomer(Customer customer)
    {
        if (ModelState.IsValid)
        {
            // Add customer to the database
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            var order = new Order
            {
                OrderDate = DateTime.Now,
                CustomerId = customer.CustomerId
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Redirect to a confirmation page or show a success message
            return RedirectToAction("NOrderConfirmed", new {customerId = customer.CustomerId});
        }

        // If validation fails, return the same view with validation messages
        return View(customer);
    }

    // Success action (Optional)
    public async Task<IActionResult> NOrderConfirmed(int customerId)
    {
        var customer = await _context.Customers.FindAsync(customerId);

        if (customer == null)
        {
            return NotFound();
        }

        var viewModel = new OrderConfirmedVM
        {
            Customer = customer,
            Items = GetShoppingCartItems( customerId)
        };
        
        return View(viewModel);
        
    }

    public IActionResult Index()
    {
        // You can implement the final order confirmation logic here
        return View();
    }

    private List<ShoppingCartItem> GetShoppingCartItems(int customerId)
    {
        var product = new Product
        {
            Name = "Surfboard",
            Length = 6.0,
            Width = 22.0,
            Thickness = 2.5,
            Price = 499
        };

        var product1 = new Product
        {
            Name = "TestyTest",
            Length = 8.1,
            Width = 22.0,
            Thickness = 5.6,
            Price = 799
        };

        

        // Creating a ShoppingCartItem with dummy data
        var shoppingCartItem = new ShoppingCartItem(1, product, 2);
        // Return the list of products in the shopping cart (dummy data for now)
        return new List<ShoppingCartItem> { shoppingCartItem }; 
        {

        };
    }
}
