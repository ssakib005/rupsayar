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
        public ActionResult ProductDetails(long id)
        {
            Tbl_Product tbl_Product = _productService.GetProductsByCondition(x => x.Id == id && x.IsActive == true).SingleOrDefault();
            Tbl_Product_VM tbl_Product_VM = new Tbl_Product_VM();
            if (tbl_Product != null) 
            {
                tbl_Product_VM = new Utility().ConvertProductModelToVM(tbl_Product);
                tbl_Product_VM.RelatedProducts =  _productService.GetProductsByCondition(x => x.IsActive == true && x.Tbl_CategoryId == x.Tbl_CategoryId).Take(4).ToList();
            }

            ViewBag.Title = "Product Details";
            return View(tbl_Product_VM);
        }
    }
}
