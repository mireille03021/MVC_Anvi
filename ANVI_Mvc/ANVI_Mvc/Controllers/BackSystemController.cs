using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANVI_Mvc.Models;
using ANVI_Mvc.ViewModels;
using ANVI_Mvc.Helpers;
using static ANVI_Mvc.Helpers.ConstantData;

namespace ANVI_Mvc.Controllers
{
    [Authorize]
    [Backend]
    public class BackSystemController : Controller
    {
        private AnviModel db = new AnviModel(); 
        private Helper hp = new Helper();
        public ActionResult Index()
        {
            ViewData["SideActive"] = (int)SideIndex.Index;
            return View();
        }

        [HttpGet]
        public ActionResult BackSystemRegister()  //後台註冊頁面
        {
            ViewBag.RoleString = new SelectList(db.AspNetRoles, "Name", "Name");
            ViewData["SideActive"] = (int)SideIndex.BackSystemRegister;
            return View();
        }

        [HttpPost]
        public ActionResult BackSystemRegister(RegisterViewModel model)
        {
            return RedirectToAction("Register", "Account");
        }

        public ActionResult AllStockChart()
        {
            List<ProductDetail> productDetils = db.ProductDetails.OrderBy(x => x.ProductID).ThenBy(x => x.PDID).ToList();
            ViewBag.Count = productDetils.Count;
            return View(productDetils);
        }
        public ActionResult AllKindChart()
        {
            return View();
        }

        public ActionResult ListAllProduct()
        {
            List<Product> products = db.Products.OrderBy(x => x.ProductID).ToList();
            return View(products);
        }
        public ActionResult ListAllProductDetail()
        {
            List<ProductDetail> productDetils = db.ProductDetails.OrderBy(x => x.ProductID).ThenBy(x => x.PDID).ToList();
            return View(productDetils);
        }
        public ActionResult ListAllCategory()
        {
            List<Category> categories = db.Categories.OrderBy(x => x.CategoryID).ToList();
            return View(categories);
        }
        public ActionResult ListAllImage()
        {
            List<Image> images = db.Images.OrderBy(x => x.ImgID).ToList();
            return View(images);
        }
        public ActionResult ListAllSize()
        {
            List<Size> sizes = db.Sizes.OrderBy(x => x.SizeID).ToList();
            return View(sizes);
        }
        public ActionResult ListAllColor()
        {
            List<Color> colors = db.Colors.OrderBy(x => x.ColorID).ToList();
            return View(colors);
        }
        public ActionResult ListAllDesDetail()
        {
            List<DesDetail> desDetails = db.DesDetails.OrderBy(x => x.DDID).ToList();
            return View(desDetails);
        }
        public ActionResult ListAllDesSubTitle()
        {
            List<DesSubTitle> desSubTitles = db.DesSubTitles.OrderBy(x => x.DSTID).ToList();
            return View(desSubTitles);
        }

        public ActionResult ListAllOrder()
        {
            List<Order> orders  = db.Orders.OrderBy(x => x.OrderID).ToList();
            return View(orders);
        }

        public ActionResult ListAllOrderDetail()
        {
            List<OrderDetail> orderDetails  = db.OrderDetails.OrderBy(x => x.OrderID).ToList();
            return View(orderDetails);
        }

        public ActionResult ListAllShipper()
        {
            List<Shipper> shippers = db.Shippers.OrderBy(x => x.ShipperID).ToList();
            return View(shippers);
        }

        public ActionResult ListAllIdentityModels()
        {
            List<AspNetUser> aspNetUsers = db.AspNetUsers.OrderBy(x => x.Id).ToList();
            return View(aspNetUsers);
        }
    }

    [Backend]
    public abstract class BaseController : Controller
    {
        public BaseController()
        {

        }
    }
}