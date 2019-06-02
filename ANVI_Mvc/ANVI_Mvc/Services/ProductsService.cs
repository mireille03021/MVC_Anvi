using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANVI_Mvc.Models;
using ANVI_Mvc.ViewModels;

namespace ANVI_Mvc.Services
{
    public class ProductsService
    {
        private AnviModel db;
        public ProductsService(AnviModel db)
        {
            this.db = db;
        }
        public List<ProductPageViewModel> getPageOfProducts()
        {
            var list = from cat in db.Categories
                join p in db.Products on cat.CategoryID equals p.CategoryID
                join pd in db.ProductDetails on p.ProductID equals pd.ProductID
                select new ProductPageViewModel
                {
                    ProductID = p.ProductID,
                    PDID = pd.PDID,
                    ColorID = pd.ColorID,
                    CategoryName = cat.CategoryName
                };
            return list.ToList();
        }
    }
}