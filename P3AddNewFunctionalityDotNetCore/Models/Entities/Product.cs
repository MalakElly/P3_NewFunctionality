using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P3AddNewFunctionalityDotNetCore.Models.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "MissingName")]
        public string Description { get; set; }
        [Required(ErrorMessage = "MissingName")]
        public string Details { get; set; }
        [Required(ErrorMessage = "MissingName")]
        public string Name { get; set; }
        [Required(ErrorMessage = "MissingPrice")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "PriceNotANumber")]
        [Range(1, int.MaxValue, ErrorMessage = "PriceNotGreaterThanZero")]
        public double Price { get; set; }
        [Required(ErrorMessage = "MissingQuantity")]
    
        [RegularExpression("^[0-9]+$", ErrorMessage = "StockNotANumber")]
        [Range(1, int.MaxValue, ErrorMessage = "StockNotGreaterThanZero")]
        public int Quantity { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
