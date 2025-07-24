namespace BookStoreWebApi2.Models
{
   public class Payment
   {
       public int Id{get;set;}
       public int OrderId{get;set;}
       public decimal Amount{get;set;}
       public string PaymentMethod{get;set;}
       public string Status { get; set; }
       public DateTime PaymentDate { get; set; }
       public string Currency{get;set;}
   }
}
