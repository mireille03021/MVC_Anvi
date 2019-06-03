using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANVI_Mvc.Models;
using ANVI_Mvc.Services;

namespace ANVI_Mvc.Controllers
{
    public class SearchController : Controller
    {
        private AnviModel db;

        public SearchController()
        {
            db = new AnviModel();
        }
        public ActionResult SearchIndex()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SearchedProducts(string Context)
        {
            ProductsService service = new ProductsService(db);
            var pList = service.getPageOfProducts();
            switch (Context)
            {
                case "手環":
                    Context = "Bracelets";
                    break;
                case "耳環":
                    Context = "EarRings";
                    break;
                case "項鍊":
                    Context = "Necklaces";
                    break;
                case "戒指":
                    Context = "Rings";
                    break;
            }

            if (Context == null)
            {
                return RedirectToAction("SearchIndex");
            }
            if (db.Categories.Any(x => x.CategoryName == Context))
            {
                pList = pList.Where(x => x.CategoryName == Context).ToList();
            }
            else if(pList.Any(x=>x.ProductName.Contains(Context)))
            {
                pList = pList.Where(x => x.ProductName.Contains(Context)).ToList();
            }
            else
            {
                ViewBag.SearchResult = false;
                return View("SearchIndex");
            }
            ViewData.Model = pList;
            ViewBag.Context = Context;
            return View();
        }
    }
}