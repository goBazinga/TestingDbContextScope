using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mehdime.Entity;
using TestingDbContextScope.Data;
using TestingDbContextScope.Service;

namespace Testing_DbContextScope.Controllers
{
    public class ProductController : Controller
    {
       private readonly  IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        // GET: Product
        public ActionResult Index()
        {

            var prod = new Product()
            {
                Id = 3,
                Name = "Dell Inspiron",
                Description = "best laptop",
                CreatedBy = "bobby",
                UpdatedBy = "",
                CreatedOn = DateTime.Now
            };

            var prodList = new List<Product>();
            _productService.AddProduct(prod);
            return View("index", prodList);
        }
        
    }
}