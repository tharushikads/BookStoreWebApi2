using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace BookStoreWebApi2.Models
{
   public class Customer
   {
       public int Id{get;set;}
       [Required]
       [StringLength(100, MinimumLength = 3)]
       public string Name { get; set; }
       
       [JsonIgnore]
       public List<Book>? Books { get; set; }
}
}

   
