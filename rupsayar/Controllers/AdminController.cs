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
                tbl_Product.IsActive = true;
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
        [HttpPost]
        public string ProductDelete(int Id)
        {
            Tbl_Product tbl_Product = _productService.GetProductsByCondition(x => x.Id == Id && x.IsActive == true).SingleOrDefault();
            tbl_Product.IsActive = false;
            try
            {
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        _productService.Update(tbl_Product);
                        scope.Complete();

                        return "success";
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
                return "failed";
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

        public ActionResult CreateCategory(string message = "", string fullMessage = "")
        {
            if (message == "success")
                ViewBag.SuccessMessage = "Category added successfully!";
            else if (message == "error")
                ViewBag.ErrorMessage = fullMessage;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(Tbl_Category_VM tbl_Category_VM)
        {
            try
            {
                Tbl_Category tbl_Category = new Tbl_Category();
                tbl_Category.IsActive = true;
                tbl_Category.CategoryName = tbl_Category_VM.CategoryName;
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        try
                        {
                            _categoryService.Add(tbl_Category);
                            scope.Complete();

                            return RedirectToAction("CreateCategory", new { message = "success" });
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
                return RedirectToAction("CreateCategory", new { message = "error", fullMessage = "Something went wrong! please try again" });
            }
        }
        public ActionResult CategoryList(int? page)
        {
            PagedListVM pagedListVM = new PagedListVM();
            pagedListVM.Page = (page ?? 1);
            pagedListVM.ItemsPerPage = 12;
            int totalCount;

            List<Tbl_Category> tbl_Categories = _categoryService.GetCategoryByConditionWithPagination(x => x.IsActive == true, pagedListVM, out totalCount);
            var tbl_CategoriesAsIPagedList = new StaticPagedList<Tbl_Category>(tbl_Categories, pagedListVM.Page, pagedListVM.ItemsPerPage, totalCount);

            ViewBag.Title = "Category List";
            return View(tbl_CategoriesAsIPagedList);
        }
        public ActionResult CategoryEdit(int id, string message = "", string fullMessage = "")
        {
            Tbl_Category tbl_Category = _categoryService.GetCategoryByCondition(x => x.Id == id && x.IsActive == true).SingleOrDefault();
            if (string.IsNullOrEmpty(message) && tbl_Category == null)
            {
                ViewBag.ErrorMessage = "No category found !";
                return View();
            }

            Tbl_Category_VM tbl_Category_VM = new Tbl_Category_VM();
            if (tbl_Category != null)
                tbl_Category_VM = new Utility().ConvertCategoryModelToVM(tbl_Category);

            if (message == "success")
                ViewBag.SuccessMessage = "Category updated successfully!";
            else if (message == "error")
                ViewBag.ErrorMessage = fullMessage;

            return View(tbl_Category_VM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryEdit(Tbl_Category_VM tbl_Category_VM)
        {
            try
            {
                Tbl_Category tbl_Category = _categoryService.GetCategoryByCondition(x => x.Id == tbl_Category_VM.Id && x.IsActive == true).SingleOrDefault();
                tbl_Category.CategoryName = tbl_Category_VM.CategoryName;

                try
                {
                    using (var scope = new TransactionScope())
                    {
                        try
                        {
                            _categoryService.Update(tbl_Category);
                            scope.Complete();

                            return RedirectToAction("CategoryEdit", new { message = "success" });
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
                return RedirectToAction("CategoryEdit", new { message = "error", fullMessage = "Something went wrong! please try again" });
            }
        }
        
        [HttpPost]
        public string CategoryDelete(int Id)
        {
            Tbl_Category tbl_Category = _categoryService.GetCategoryByCondition(x => x.Id == Id && x.IsActive == true).SingleOrDefault();
            tbl_Category.IsActive = false;
            try
            {
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        _categoryService.Update(tbl_Category);
                        scope.Complete();

                        return "success";
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
                return "failed";
            }
        }
        public ActionResult CategoryDetails(int id, string message = "", string fullMessage = "")
        {
            Tbl_Category tbl_Category = _categoryService.GetCategoryByCondition(x => x.Id == id && x.IsActive == true).SingleOrDefault();
            if (string.IsNullOrEmpty(message) && tbl_Category == null)
            {
                ViewBag.ErrorMessage = "No category found !";
                return View();
            }

            Tbl_Category_VM tbl_Category_VM = new Tbl_Category_VM();
            if (tbl_Category != null)
                tbl_Category_VM = new Utility().ConvertCategoryModelToVM(tbl_Category);

            if (message == "success")
                ViewBag.SuccessMessage = "Category updated successfully!";
            else if (message == "error")
                ViewBag.ErrorMessage = fullMessage;

            return View(tbl_Category_VM);
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
