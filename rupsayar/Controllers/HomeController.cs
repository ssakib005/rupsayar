using PagedList;
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
        public ActionResult AllProducts(int? page)
        {
            PagedListVM pagedListVM = new PagedListVM();
            pagedListVM.Page = (page ?? 1);
            pagedListVM.ItemsPerPage = 12;
            int totalCount;

            List<Tbl_Product> tbl_Products = _productService.GetProductsByConditionWithPagination(x=>x.IsActive == true, pagedListVM,out totalCount);
            var utbl_ProductsAsIPagedList = new StaticPagedList<Tbl_Product>(tbl_Products, pagedListVM.Page, pagedListVM.ItemsPerPage, totalCount);
            
            ViewBag.Title = "All Products";
            return View(utbl_ProductsAsIPagedList);
        }
    }
}
