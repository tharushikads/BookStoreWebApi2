using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace BookStoreWebApi2.Models
{
public class Order
{
   public int Id{get;set;}
   public int CustomerId{get;set;}
   public string? Status{get;set;}
   public decimal TotalAmount{get;set;}
   public string? Currency{get;set;}

   [JsonIgnore]
   public List<int> BookIds { get; set; }
   public DateTime OrderDate { get; set; }
}
}

