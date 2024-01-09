using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace P3AddNewFunctionalityDotNetCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILanguageService _languageService;

        public ProductController(IProductService productService, ILanguageService languageService)
        {
            _productService = productService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            IEnumerable<ProductViewModel> products = _productService.GetAllProductsViewModel();
            return View(products);
        }

        [Authorize]
        public IActionResult Admin()
        {
            return View(_productService.GetAllProductsViewModel().OrderByDescending(p => p.Id));
        }

        [Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)//Si toutes les données saisies sont validées
            {
               
                _productService.SaveProduct(product);//Enregistrer le produit dans la base de données
                return RedirectToAction("Admin");//Retourner a la page d'accueil
            }
            else
            {
                return View(product);//Sinon afficher la vue Product
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Admin");
        }
    }
}