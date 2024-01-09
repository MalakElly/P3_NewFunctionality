using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace P3AddNewFunctionalityDotNetCore.Models.ViewModels
{
    public class ProductViewModel
    {
        [BindNever]
        public int Id { get; set; }
        [RegularExpression("^[a-zA-ZÀ-ÖØ-öø-ÿáéíóúýÁÉÍÓÚÝ ]+$", ErrorMessage = "InvalidName")]
        [Required(ErrorMessage = "ErrorMissingName")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }
        [Required(ErrorMessage = "ErrorStockValue")]
        [RegularExpression("^[1-9]\\d{0,50}$", ErrorMessage = "StockNotANumber")]//Les caractères doivent être des chiffres de 0 à 9
        [Range(1, int.MaxValue, ErrorMessage = "StockNotGreaterThanZero")]
        public string Stock { get; set; }

        [Required(ErrorMessage = "ErrorMissingPrice")]
        [RegularExpression("^[1-9]\\d{0,50}$", ErrorMessage = "PriceNotANumber")]
        [Range(1, int.MaxValue, ErrorMessage = "PriceNotGreaterThanZero")]
        public string Price { get; set; }
    }
}
