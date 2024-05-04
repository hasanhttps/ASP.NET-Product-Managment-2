using Microsoft.AspNetCore.Mvc;
using ASP.NET_Product_Managment.Models.Conceretes;

using static ASP.NET_Product_Managment.Services.DatabaseService;

namespace ASP.NET_Product_Managment.Controllers {
    public class ProductController : Controller {

        // Actions

        public IActionResult AllProducts() {
            return View(Products);
        }

        public IActionResult ProductById(int id) {
            Product product= null;
            foreach (var item in Products)
                if (item.Id == id) product = item;

            return View(product);
        }

        [HttpGet]
        public IActionResult AddProduct() { 
            Product product = new Product() { Id = Products.LastIndexOf(Products.Last()) + 1};
            return View(product); 
        }

        [HttpPost]
        public IActionResult AddProduct(Product product) {
            Products.Add(product);
            return View(product);
        }

        [HttpGet]
        public IActionResult RemoveProduct() {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult RemoveProduct(Product product) {
            if (product.Id != -1) {
                DeleteById(product.Id);
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult GetProductById() {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult GetProductById(Product product) {
            return View(SearchById(product.Id));
        }

        [HttpGet]
        public IActionResult GetProductsByPrice(int price) {
            return View();
        }

        [HttpPost]
        public IActionResult GetProductsByPrice(List<Product>) {
            return View(SearchById(product.Id));
        }
    }
}
