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
        public ActionResult Bracelets(int page) //手鍊商品頁面
        {

            //抓產品的分類
            ViewData.Model = db.Products.Where(x => x.CategoryID == 1).ToList();

            //給上一頁下一頁按鈕使用
            ViewBag.mainController = "Category";
            ViewBag.mainActionName = "Bracelets";

            //給@Html.Action使用，取得HomeController的GetProducts方法
            ViewBag.Title = "BRACELETS";
            ViewBag.ActionName = "GetProducts";
            ViewBag.Controller = "Home";
            ViewBag.Page = page;
            return View();
        }
      

        [AllowAnonymous]
        public ActionResult EarRings(int page) //耳環商品頁面
        {

            //抓產品的分類
            ViewData.Model = db.Products.Where(x => x.CategoryID == 2).ToList();

            //給上一頁下一頁按鈕使用
            ViewBag.mainController = "Category";
            ViewBag.mainActionName = "EarRings";

            //給@Html.Action使用，取得HomeController的GetProducts方法
            ViewBag.Title = "EARPINGS";
            ViewBag.ActionName = "GetProducts";
            ViewBag.Controller = "Home";
            ViewBag.Page = page;
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult Necklaces(int page) //項鍊商品頁面
        {

            //抓產品的分類
            ViewData.Model = db.Products.Where(x => x.CategoryID == 3).ToList();

            //給上一頁下一頁按鈕使用
            ViewBag.mainController = "Category";
            ViewBag.mainActionName = "Necklaces";

            //給@Html.Action使用，取得HomeController的GetProducts方法
            ViewBag.Title = "NECKLACES";
            ViewBag.ActionName = "GetProducts";
            ViewBag.Controller = "Home";
            ViewBag.Page = page;
            return View();
        }

        [AllowAnonymous]
        public ActionResult Rings(int page) //戒指商品頁面
        {

            //抓產品的分類
            ViewData.Model = db.Products.Where(x => x.CategoryID == 4).ToList();

            //給上一頁下一頁按鈕使用
            ViewBag.mainController = "Category";
            ViewBag.mainActionName = "Rings";

            //給@Html.Action使用，取得HomeController的GetProducts方法
            ViewBag.Title = "RINGS";
            ViewBag.ActionName = "GetProducts";
            ViewBag.Controller = "Home";
            ViewBag.page = page;
            return View();
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