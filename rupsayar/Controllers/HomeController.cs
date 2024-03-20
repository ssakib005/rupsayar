using rupsayar.Models;
using rupsayar.Models.VM;
using rupsayar.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rupsayar.Controllers
{
    public class HomeController : Controller
    {
        public IProductService _productService;
        public HomeController(IProductService productService) 
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Products = _productService.GetProductsByCondition(x => x.IsActive).Take(4).ToList();
            ViewBag.Title = "Home Page";
            return View(homeVM);
        }

        public ActionResult AllProducts()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Products = _productService.GetProductsByCondition(x => x.IsActive);
            ViewBag.Title = "All Products";
            return View(homeVM);
        }
    }
}
