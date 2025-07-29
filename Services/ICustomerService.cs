using BookStoreWebApi2.Models;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomerAsync();
    Task<Customer> GetCustomerByIdAsync(int id);
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(int id, Customer customer);
    Task DeleteCustomerAsync(int id);
}