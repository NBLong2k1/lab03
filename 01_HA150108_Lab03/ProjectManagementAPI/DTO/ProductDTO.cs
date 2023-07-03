using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.DTO
{
    public class ProductDTO
    {
     
   
      
        public string ProductName { get; set; }

        public int CategoryId { get; set; }
        public int UnitsInStock { get; set; }
    
        public decimal UnitPrice { get; set; }

       
    }
}
