using ANVI_Mvc.Models;
using ANVI_Mvc.Services;
using ANVI_Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ANVI_Mvc.Controllers
{
    public class CategoryController : Controller
    {
        protected AnviModel db;


        public CategoryController()
        {
            db = new AnviModel();
        }
        // GET: Catrgory
        [AllowAnonymous]
        public ActionResult Bracelets(int cat) //手鍊商品頁面
        {

            //抓產品的分類
            ViewData.Model = db.Products.Where(x => x.CategoryID == 1).ToList();

            //給上一頁下一頁按鈕使用
            ViewBag.mainController = "Category";
            ViewBag.mainActionName = "Bracelets";

            //給@Html.Action使用，取得HomeController的GetProducts方法
            ViewBag.Title = "BRACELETS";
            ViewBag.ActionName = "GetBraceletsProducts";
            ViewBag.Controller = "Category";
            ViewBag.Page = cat;
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetBraceletsProducts(int cat, List<Product> AllProducts)
        {
            //每八個一頁
            var ProductNumber = 8;
            //取得目前頁所需要顯示的物品
            var pList = AllProducts.Skip((cat - 1) * ProductNumber).Take(cat * ProductNumber).ToList();

            //建立全部商品
            ProductsService service = new ProductsService(db);
            var AllProductDetails = service.getPageOfProducts();
            var Model = new List<ProductPageViewModel>();

            for (var i = 0; i < pList.Count; i++)
            {
                //避免超出範圍，雖然不一定會用到
                if (i % 8 == 0 && i != 0) break;

                //取得此產品ID所有的PDID，並加進List<ProductPageViewModel> Model中
                var NowPid = pList[i].ProductID;
                var FilterList = AllProductDetails.Where(x => x.ProductID == NowPid);
                foreach (var item in FilterList)
                {
                    Model.Add(item);
                }
            }
            ViewData.Model = Model;
            return PartialView("_ProductsPartial");
        }

        [AllowAnonymous]
        public ActionResult EarRings(int cat) //耳環商品頁面
        {

            //抓產品的分類
            ViewData.Model = db.Products.Where(x => x.CategoryID == 2).ToList();

            //給上一頁下一頁按鈕使用
            ViewBag.mainController = "Category";
            ViewBag.mainActionName = "EarRings";

            //給@Html.Action使用，取得HomeController的GetProducts方法
            ViewBag.Title = "EARPINGS";
            ViewBag.ActionName = "GetEarRingsProducts";
            ViewBag.Controller = "Category";
            ViewBag.Page = cat;
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetEarRingsProducts(int cat, List<Product> AllProducts)
        {
            //每八個一頁
            var ProductNumber = 8;
            //取得目前頁所需要顯示的物品
            var pList = AllProducts.Skip((cat - 1) * ProductNumber).Take(cat * ProductNumber).ToList();

            //建立全部商品
            ProductsService service = new ProductsService(db);
            var AllProductDetails = service.getPageOfProducts();
            var Model = new List<ProductPageViewModel>();

            for (var i = 0; i < pList.Count; i++)
            {
                //避免超出範圍，雖然不一定會用到
                if (i % 8 == 0 && i != 0) break;

                //取得此產品ID所有的PDID，並加進List<ProductPageViewModel> Model中
                var NowPid = pList[i].ProductID;
                var FilterList = AllProductDetails.Where(x => x.ProductID == NowPid);
                foreach (var item in FilterList)
                {
                    Model.Add(item);
                }
            }
            ViewData.Model = Model;
            return PartialView("_ProductsPartial");
        }

        [AllowAnonymous]
        public ActionResult Necklaces(int cat) //項鍊商品頁面
        {

            //抓產品的分類
            ViewData.Model = db.Products.Where(x => x.CategoryID == 3).ToList();

            //給上一頁下一頁按鈕使用
            ViewBag.mainController = "Category";
            ViewBag.mainActionName = "Necklaces";

            //給@Html.Action使用，取得HomeController的GetProducts方法
            ViewBag.Title = "NECKLACES";
            ViewBag.ActionName = "GetNecklacesProducts";
            ViewBag.Controller = "Category";
            ViewBag.Page = cat;
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetNecklacesProducts(int cat, List<Product> AllProducts)
        {
            //每八個一頁
            var ProductNumber = 8;
            //取得目前頁所需要顯示的物品
            var pList = AllProducts.Skip((cat - 1) * ProductNumber).Take(cat * ProductNumber).ToList();

            //建立全部商品
            ProductsService service = new ProductsService(db);
            var AllProductDetails = service.getPageOfProducts();
            var Model = new List<ProductPageViewModel>();

            for (var i = 0; i < pList.Count; i++)
            {
                //避免超出範圍，雖然不一定會用到
                if (i % 8 == 0 && i != 0) break;

                //取得此產品ID所有的PDID，並加進List<ProductPageViewModel> Model中
                var NowPid = pList[i].ProductID;
                var FilterList = AllProductDetails.Where(x => x.ProductID == NowPid);
                foreach (var item in FilterList)
                {
                    Model.Add(item);
                }
            }
            ViewData.Model = Model;
            return PartialView("_ProductsPartial");
        }

        [AllowAnonymous]
        public ActionResult Rings(int cat) //戒指商品頁面
        {

            //抓產品的分類
            ViewData.Model = db.Products.Where(x => x.CategoryID == 4).ToList();

            //給上一頁下一頁按鈕使用
            ViewBag.mainController = "Category";
            ViewBag.mainActionName = "Rings";

            //給@Html.Action使用，取得HomeController的GetProducts方法
            ViewBag.Title = "RINGS";
            ViewBag.ActionName = "GetRingsProducts";
            ViewBag.Controller = "Category";
            ViewBag.page = cat;
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetRingsProducts(int cat, List<Product> AllProducts)
        {
            //每八個一頁
            var ProductNumber = 8;
            //取得目前頁所需要顯示的物品
            var pList = AllProducts.Skip((cat - 1) * ProductNumber).Take(cat * ProductNumber).ToList();

            //建立全部商品
            ProductsService service = new ProductsService(db);
            var AllProductDetails = service.getPageOfProducts();
            var Model = new List<ProductPageViewModel>();

            for (var i = 0; i < pList.Count; i++)
            {
                //避免超出範圍，雖然不一定會用到
                if (i % 8 == 0 && i != 0) break;

                //取得此產品ID所有的PDID，並加進List<ProductPageViewModel> Model中
                var NowPid = pList[i].ProductID;
                var FilterList = AllProductDetails.Where(x => x.ProductID == NowPid);
                foreach (var item in FilterList)
                {
                    Model.Add(item);
                }
            }
            ViewData.Model = Model;
            return PartialView("_ProductsPartial");
        }

        //[AllowAnonymous]
        //public ActionResult EarRingsProductsPage(int page = 1) //耳環商品頁面
        //{
        //    ViewData.Model = db.Products.ToList();
        //    ViewBag.Title = "EARPINGS";
        //    ViewBag.ActionName = "GetEarRingsProducts";
        //    ViewBag.Controller = "Catrgory";
        //    ViewBag.Page = page;
        //    return View();
        //}
        //[AllowAnonymous]
        //public ActionResult GetEarRingsProducts(int page = 1)  //抓取商品資訊
        //{
        //    var ProductNumber = 8;
        //    ProductsService service = new ProductsService(db);
        //    ViewData.Model = service.getPageOfProducts().Where(x => x.CategoryName == "EarRings").ToList();
        //    return PartialView("_ProductsPartial");
        //}
    }
}