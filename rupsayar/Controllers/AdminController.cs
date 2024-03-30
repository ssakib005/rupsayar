using PagedList;
using rupsayar.Helper;
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
    public class AdminController : Controller
    {
        public IProductService _productService;
        public AdminController(IProductService productService) 
        {
            _productService = productService;
        }

        public ActionResult CreateProduct() 
        {
            return View();
        }

    }
}
