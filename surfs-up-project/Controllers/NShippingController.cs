using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;

public class NShippingController : Controller
{
    private readonly CustomerRepository _customerRepository;

    public NShippingController(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpPost]
    public IActionResult Confirmed(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _customerRepository.AddCustomer(customer); // Persist to the database
            return RedirectToAction("Success");
        }

        return View("Shipping", customer); // Reload the view with validation errors if the model is invalid
    }

    public IActionResult Success()
    {
        return View(); // Show a success page or redirect somewhere
    }
}
