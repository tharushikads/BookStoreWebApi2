using BookStoreWebApi2.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

public class CustomerService : ICustomerService
{
    private readonly BookContext _context;

    public CustomerService(BookContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCustomerAsync(int id, Customer customer)
    {
        _context.Entry(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
