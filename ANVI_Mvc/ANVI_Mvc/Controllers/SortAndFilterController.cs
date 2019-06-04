using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ANVI_Mvc.Models;

namespace ANVI_Mvc.Controllers
{
    public class SortAndFilterController : Controller
    {
        protected AnviModel db;

        public SortAndFilterController()
        {
            db = new AnviModel();
        }

        public ActionResult PriceLowToHigh(int page) //商品頁面
        {
            ViewData.Model = db.Products.OrderBy(x => x.UnitPrice).ToList();
            //給上一頁下一頁按鈕使用
            ViewBag.mainController = "SortAndFilter";
            ViewBag.mainActionName = "PriceLowToHigh";

            //給@Html.Action使用，取得HomeController的GetProducts方法
            ViewBag.Title = "PRODUCTS";
            ViewBag.ActionName = "GetProducts";
            ViewBag.Controller = "Home";
            
            ViewBag.Page = page;
            return View("../Home/ProductsPage");
        }
        public ActionResult PriceHighToLow(int page) //商品頁面
        {
            ViewData.Model = db.Products.OrderByDescending(x => x.UnitPrice).ToList();
            //給上一頁下一頁按鈕使用
            ViewBag.mainController = "SortAndFilter";
            ViewBag.mainActionName = "PriceHighToLow";

            //給@Html.Action使用，取得HomeController的GetProducts方法
            ViewBag.Title = "PRODUCTS";
            ViewBag.ActionName = "GetProducts";
            ViewBag.Controller = "Home";

            ViewBag.Page = page;
            return View("../Home/ProductsPage");
        }
    }
}