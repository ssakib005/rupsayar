using rupsayar.Models;
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
            List<Tbl_Product> tbl_Products = _productService.GetProductsByCondition(x=>x.IsActive);
            
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
