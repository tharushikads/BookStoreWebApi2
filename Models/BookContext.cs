using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookStoreWebApi2.Models;

namespace BookStoreWebApi2.Models
{
    public class BookContext : IdentityDbContext<IdentityUser>
    {

    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {

    }
    public DbSet<Book> Books{get;set;}

    public DbSet<Category> Categories {get;set;}

    public DbSet<Customer> Customers{get;set;}

    public DbSet<Order> Orders{get;set;}

    public DbSet<Payment> Payments{get;set;}

    

    }
}