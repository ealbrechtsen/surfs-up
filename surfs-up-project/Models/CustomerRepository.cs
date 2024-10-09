using surfs_up_project.Data;

namespace surfs_up_project.Models
{
    public class CustomerRepository
    {
        private readonly NCustomerDbContext _dbContext;

        //private List<Customer> _customers; // Liste til at holde kunderne i hukommelsen
        public CustomerRepository(NCustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public CustomerRepository()
        //{
        //    _customers = new List<Customer>(); // Initialiserer den interne liste
        //}

        // Tilføjer en ny kunde til listen
        public void AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        // Henter en kunde baseret på CustomerId
        public Customer GetCustomerById(int customerId)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        // Henter alle kunder
        public List<Customer> GetAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        // Opdaterer eksisterende kundeoplysninger
        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = GetCustomerById(customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.Address = customer.Address;
                existingCustomer.ZipCode = customer.ZipCode;
                existingCustomer.City = customer.City;

                _dbContext.Customers.Update(existingCustomer);
                _dbContext.SaveChanges();
            }
        }

        // Sletter en kunde baseret på CustomerId
        public void DeleteCustomer(int customerId)
        {
            var customer = GetCustomerById(customerId);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
            }
        }
    }
}



