using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi2.Models
{
    public class BookContext : DbContext
    {

    public BookContext(DbContextOptions<BookContext>options) : base(options){}

    public DbSet<Book> Books{get;set;}

    public DbSet<Category> Categories {get;set;}

    public DbSet<Customer> Customers{get;set;}

    public DbSet<Order> Orders{get;set;}

    public DbSet<Payment> Payments{get;set;}

    }
}