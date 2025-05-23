using CustomerService.Models;

namespace CustomerService.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();

        Task<Customer> GetById(int customerId);

        Task Create(Customer customer);

        Task Update(Customer customer);

        Task Delete(Customer customer);
    }
}
