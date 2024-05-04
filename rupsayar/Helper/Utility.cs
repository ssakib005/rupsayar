using rupsayar.Models;
using rupsayar.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rupsayar.Helper
{
    public class Utility
    {
        public Tbl_Product_VM ConvertProductModelToVM(Tbl_Product tbl_Product) 
        {
            Tbl_Product_VM tbl_Product_VM = new Tbl_Product_VM();
            tbl_Product_VM.Id = tbl_Product.Id;
            tbl_Product_VM.Name = tbl_Product.Name;
            tbl_Product_VM.Description = tbl_Product.Description;

            tbl_Product_VM.Tbl_CategoryId = tbl_Product.Tbl_CategoryId;
            tbl_Product_VM.Tbl_Category = tbl_Product.Tbl_Category;
            tbl_Product_VM.UnitPrice = tbl_Product.UnitPrice;
            tbl_Product_VM.Quantity = tbl_Product.Quantity;
            tbl_Product_VM.Tbl_ProductVariants = tbl_Product.Tbl_ProductVariants;
            tbl_Product_VM.IsNewArrival = tbl_Product.IsNewArrival;
            tbl_Product_VM.IsActive = tbl_Product.IsActive;
            tbl_Product_VM.Tbl_ProductRates = tbl_Product.Tbl_ProductRates;
            tbl_Product_VM.Tbl_ProductImages = tbl_Product.Tbl_ProductImages;

            return tbl_Product_VM;
        }

        public Tbl_Product ConvertProductVMToModel(Tbl_Product_VM tbl_Product_VM)
        {
            Tbl_Product tbl_Product = new Tbl_Product();

            tbl_Product.Id = tbl_Product_VM.Id;
            tbl_Product.Name = tbl_Product_VM.Name;
            tbl_Product.Description = tbl_Product_VM.Description;
            tbl_Product.Tbl_CategoryId = tbl_Product_VM.Tbl_CategoryId;
            tbl_Product.UnitPrice = tbl_Product_VM.UnitPrice;
            tbl_Product.Quantity = tbl_Product_VM.Quantity;
            tbl_Product.IsNewArrival = tbl_Product_VM.IsNewArrival;
            tbl_Product.IsActive = tbl_Product_VM.IsActive;

            return tbl_Product;
        }
        public Tbl_Product EditProductVMToModel(Tbl_Product tbl_Product,Tbl_Product_VM tbl_Product_VM)
        {
            tbl_Product.Name = tbl_Product_VM.Name;
            tbl_Product.Description = tbl_Product_VM.Description;
            tbl_Product.Tbl_CategoryId = tbl_Product_VM.Tbl_CategoryId;
            tbl_Product.UnitPrice = tbl_Product_VM.UnitPrice;
            tbl_Product.Quantity = tbl_Product_VM.Quantity;
            tbl_Product.IsNewArrival = tbl_Product_VM.IsNewArrival;
            return tbl_Product;
        }
        public Tbl_Category_VM ConvertCategoryModelToVM(Tbl_Category tbl_Category)
        {
            Tbl_Category_VM tbl_Category_VM = new Tbl_Category_VM();
            tbl_Category_VM.Id = tbl_Category.Id;
            tbl_Category_VM.CategoryName = tbl_Category.CategoryName;
            tbl_Category_VM.IsActive = tbl_Category.IsActive;

            return tbl_Category_VM;
        }
    }
}