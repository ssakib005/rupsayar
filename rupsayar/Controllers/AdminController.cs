using PagedList;
using rupsayar.Helper;
using rupsayar.Models;
using rupsayar.Models.VM;
using rupsayar.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace rupsayar.Controllers
{
    public class AdminController : Controller
    {
        public IProductService _productService;
        public ICategoryService _categoryService;
        public IProductImageService _productImageService;
        public AdminController(IProductService productService, ICategoryService categoryService, IProductImageService productImageService) 
        {
            _productService = productService;
            _categoryService = categoryService;
            _productImageService = productImageService;
        }

        public ActionResult CreateProduct(string message = "", string fullMessage = "") 
        {
            List<Tbl_Category> tbl_Categories = _categoryService.GetCategoryByCondition(x=>x.IsActive);
            ViewBag.Categories = tbl_Categories;

            if (message == "success")
                ViewBag.SuccessMessage = "Product added successfully!";
            else if (message == "error")
                ViewBag.ErrorMessage = fullMessage;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(Tbl_Product_VM tbl_Product_VM)
        {
            try
            {
                Tbl_Product tbl_Product = new Utility().ConvertProductVMToModel(tbl_Product_VM);
                var attachmentlist = ProcessImage(tbl_Product_VM.Tbl_ProductImageList);
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        try
                        {
                            _productService.Add(tbl_Product);
                            foreach (var item in attachmentlist)
                            {
                                item.Tbl_ProductId = tbl_Product.Id;
                                _productImageService.Add(item);
                            }

                            scope.Complete();

                            return RedirectToAction("CreateProduct", new { message = "success" });
                        }
                        catch (Exception e)
                        {
                            Transaction.Current.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("CreateProduct", new { message = "error", fullMessage = "Something went wrong! please try again" });
            }
        }
        public ActionResult ProductList(int? page)
        {
            PagedListVM pagedListVM = new PagedListVM();
            pagedListVM.Page = (page ?? 1);
            pagedListVM.ItemsPerPage = 12;
            int totalCount;

            List<Tbl_Product> tbl_Products = _productService.GetProductsByConditionWithPagination(x => x.IsActive == true, pagedListVM, out totalCount);
            var utbl_ProductsAsIPagedList = new StaticPagedList<Tbl_Product>(tbl_Products, pagedListVM.Page, pagedListVM.ItemsPerPage, totalCount);

            ViewBag.Title = "Product List";
            return View(utbl_ProductsAsIPagedList);
        }
        public ActionResult ProductEdit(int id,string message = "", string fullMessage = "")
        {
            List<Tbl_Category> tbl_Categories = _categoryService.GetCategoryByCondition(x => x.IsActive);
            ViewBag.Categories = tbl_Categories;


            Tbl_Product tbl_Product = _productService.GetProductsByCondition(x => x.Id == id && x.IsActive == true).SingleOrDefault();
            if (string.IsNullOrEmpty(message) && tbl_Product == null)
            {
                ViewBag.ErrorMessage = "No product found !";
                return View();
            }

            Tbl_Product_VM tbl_Product_VM = new Tbl_Product_VM();
            if(tbl_Product != null)
                tbl_Product_VM = new Utility().ConvertProductModelToVM(tbl_Product);

            if (message == "success")
                ViewBag.SuccessMessage = "Product updated successfully!";
            else if (message == "error")
                ViewBag.ErrorMessage = fullMessage;

            return View(tbl_Product_VM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit(Tbl_Product_VM tbl_Product_VM)
        {
            try
            {
                Tbl_Product tbl_Product = _productService.GetProductsByCondition(x => x.Id == tbl_Product_VM.Id && x.IsActive == true).SingleOrDefault();

                tbl_Product = new Utility().EditProductVMToModel(tbl_Product,tbl_Product_VM);
                
                var attachmentlist = ProcessImage(tbl_Product_VM.Tbl_ProductImageEditList);
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        try
                        {
                            _productService.Update(tbl_Product);
                            foreach (var item in attachmentlist)
                            {
                                item.Tbl_ProductId = tbl_Product.Id;
                                _productImageService.Add(item);
                            }

                            scope.Complete();

                            return RedirectToAction("ProductEdit", new { message = "success" });
                        }
                        catch (Exception e)
                        {
                            Transaction.Current.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("ProductEdit", new { message = "error", fullMessage = "Something went wrong! please try again" });
            }
        }
        public ActionResult ProductDetails(int id, string message = "", string fullMessage = "")
        {
            List<Tbl_Category> tbl_Categories = _categoryService.GetCategoryByCondition(x => x.IsActive);
            ViewBag.Categories = tbl_Categories;


            Tbl_Product tbl_Product = _productService.GetProductsByCondition(x => x.Id == id && x.IsActive == true).SingleOrDefault();
            if (string.IsNullOrEmpty(message) && tbl_Product == null)
            {
                ViewBag.ErrorMessage = "No product found !";
                return View();
            }

            Tbl_Product_VM tbl_Product_VM = new Tbl_Product_VM();
            if (tbl_Product != null)
                tbl_Product_VM = new Utility().ConvertProductModelToVM(tbl_Product);

            if (message == "success")
                ViewBag.SuccessMessage = "Product updated successfully!";
            else if (message == "error")
                ViewBag.ErrorMessage = fullMessage;

            return View(tbl_Product_VM);
        }
        private List<Tbl_ProductImages> ProcessImage(List<HttpPostedFileBase> Tbl_ProductImages)
        {
            try
            {
                List<Tbl_ProductImages> attachmentlist = new List<Tbl_ProductImages>();

                string path = Server.MapPath("~/Attachments/Products/");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                foreach (HttpPostedFileBase postedFile in Tbl_ProductImages)
                {
                    Tbl_ProductImages image = new Tbl_ProductImages();

                    if (postedFile != null)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        postedFile.SaveAs(path + fileName);

                        image.FileName = fileName;
                        image.FilePath = "~/Attachments/Products/" + fileName;
                        attachmentlist.Add(image);

                    }
                }

                return attachmentlist;
            }
            catch(Exception e) 
            {
                throw e;
            }
        }

    }
}
