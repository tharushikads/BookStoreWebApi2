using System.ComponentModel.DataAnnotations;
namespace BookStoreWebApi2.Models
{
public class CustomerDTO
{
public int CustomerId { get; set; }
[Required]
[StringLength(100, MinimumLength = 3)]
public string Name { get; set; }
}
}
