using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace surfs_up_project.Controllers
{/*
    public class ConfirmedController : Controller
    {
        private readonly NCustomerDbContext _context;
        private ShoppingCart _shoppingCart = new ShoppingCart();

        public ConfirmedController(NCustomerDbContext context)
        {
            _context = context;
        }

        // This is the action that loads the confirmation page
        public IActionResult Index(string firstName, string lastName, string email, string phoneNumber, string address, int zipCode, string city)
        {
            // Create a Customer object with the data passed from the form
            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                ZipCode = zipCode,
                City = city
            };

            // Get items from the shopping cart
            List<ShoppingCartItem> items = _shoppingCart.GetItems();

            // Create a ConfirmedViewModel object and assign the customer and items
            var model = new OrderConfirmedVM
            {
                Customer = customer,
                Items = items
            };

            // Pass the model to the view
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Save customer to the database
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync(); // Save the customer first to get the CustomerId

                // Create a new order after saving the customer
                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    CustomerId = customer.CustomerId // Link the order to the newly created customer
                };

                // Save the order to the Orders table
                _context.Orders.Add(order);
                await _context.SaveChangesAsync(); // Save the order

                // Redirect to the confirmation page, passing customer details
                return RedirectToAction("Index", new
                {
                    firstName = customer.FirstName,
                    lastName = customer.LastName,
                    email = customer.Email,
                    phoneNumber = customer.PhoneNumber,
                    address = customer.Address,
                    zipCode = customer.ZipCode,
                    city = customer.City
                });
            }

            // If validation fails, return the same view with validation messages
            return View(customer);
        }

            // If validation fails, return the same view with validation messages

        public IActionResult OrderConfirmed()
        {
            // You can implement the final order confirmation logic here
            return View();
        }
        
    }
   */     
}
