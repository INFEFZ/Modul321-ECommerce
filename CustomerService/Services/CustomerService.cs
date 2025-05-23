using CustomerService.Models;

namespace CustomerService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerService(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerDbContext.Customers;
        }

        public async Task Create(Customer customer)
        {
            await _customerDbContext.Customers.AddAsync(customer);
            await _customerDbContext.SaveChangesAsync();
        }

        public async Task Delete(Customer customer)
        {
            _customerDbContext.Customers.Remove(customer);
            await _customerDbContext.SaveChangesAsync();
        }

        public async Task<Customer> GetById(int customerId)
        {
            var customer = await _customerDbContext.Customers.FindAsync(customerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            return customer;
        }

        public async Task Update(Customer customer)
        {
            _customerDbContext.Customers.Update(customer);
            await _customerDbContext.SaveChangesAsync();
        }
    }
}
