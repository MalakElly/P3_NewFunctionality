using System.Collections.Generic;


namespace P3AddNewFunctionalityDotNetCore.Models.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public int Id { get; set; }
    
        public string Description { get; set; }
       
        public string Details { get; set; }

      
        public string Name { get; set; }
      
  
        //[RegularExpression("^[0-9]+$", ErrorMessage = "PriceNotANumber")]
        //[Range(1, int.MaxValue, ErrorMessage = "PriceNotGreaterThanZero")]
        public double Price { get; set; }

   
        // [RegularExpression("^[0-9]", ErrorMessage = "StockNotANumber")]//Les caractères doivent être des chiffres de 0 à 9
        //[Range(1, int.MaxValue, ErrorMessage = "StockNotGreaterThanZero")]
        public int Quantity { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
