using ANVI_Mvc.Models;
using ANVI_Mvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ANVI_Mvc.Controllers
{
    public class CatrgoryController : Controller
    {
        protected AnviModel db;

        // GET: Catrgory
        [AllowAnonymous]
        public ActionResult BraceletsProductsPage(int page) //手鍊商品頁面
        {
            ViewData.Model = db.Products.ToList();
            ViewBag.Title = "BRACELETS";
            ViewBag.ActionName = "GetBraceletsProducts";
            ViewBag.Controller = "Catrgory";
            ViewBag.Page = page;
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetBraceletsProducts(string cat)  //抓取手鍊商品資訊
        {
            var ProductNumber = 8;
            ProductsService service = new ProductsService(db);
            ViewData.Model = service.getPageOfProducts().Where(x => x.CategoryName == cat).ToList();
            return PartialView("_ProductsPartial");
        }



        [AllowAnonymous]
        public ActionResult EarRingsProductsPage(int page) //耳環商品頁面
        {
            ViewData.Model = db.Products.ToList();
            ViewBag.Title = "EARPINGS";
            ViewBag.ActionName = "GetEarRingsProducts";
            ViewBag.Controller = "Catrgory";
            ViewBag.Page = page;
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetEarRingsProducts(int page)  //抓取商品資訊
        {
            var ProductNumber = 8;
            ProductsService service = new ProductsService(db);
            ViewData.Model = service.getPageOfProducts().Where(x => x.CategoryName == "EarRings").ToList();
            return PartialView("_ProductsPartial");
        }

        [AllowAnonymous]
        public ActionResult NecklacesProductsPage(int page) //項鍊商品頁面
        {
            ViewData.Model = db.Products.ToList();
            ViewBag.Title = "NECKLACES";
            ViewBag.ActionName = "GetNecklacesProducts";
            ViewBag.Controller = "Catrgory";
            ViewBag.Page = page;
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetNecklacesProducts(int page)  //抓取商品資訊
        {
            var ProductNumber = 8;
            ProductsService service = new ProductsService(db);
            ViewData.Model = service.getPageOfProducts().Where(x => x.CategoryName == "Necklaces").ToList();
            return PartialView("_ProductsPartial");
        }

        [AllowAnonymous]
        public ActionResult RingsProductsPage(int page) //戒指商品頁面
        {
            ViewData.Model = db.Products.ToList();
            ViewBag.Title = "RINGS";
            ViewBag.ActionName = "GetRingsProducts";
            ViewBag.Controller = "Catrgory";
            ViewBag.Page = page;
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetRingsProducts(int page)  //抓取商品資訊
        {
            var ProductNumber = 8;
            ProductsService service = new ProductsService(db);
            ViewData.Model = service.getPageOfProducts().Where(x => x.CategoryName == "Rings").ToList();
            return PartialView("_ProductsPartial");
        }
    }
}