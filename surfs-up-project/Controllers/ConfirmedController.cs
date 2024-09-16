using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;
using System.Reflection.Emit;

namespace surfs_up_project.Controllers
{
    public class ConfirmedController : Controller
    {
        public IActionResult Index(string firstName, string lastName, string email, string phoneNumber, string address, int zipCode, string city)
        {
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

            return View(customer);
        }
    }


}
