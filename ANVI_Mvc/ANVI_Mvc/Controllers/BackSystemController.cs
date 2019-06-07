using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANVI_Mvc.Models;
using ANVI_Mvc.ViewModels;
using ANVI_Mvc.Helpers;

namespace ANVI_Mvc.Controllers
{
    public class BackSystemController : Controller
    {
        private AnviModel db = new AnviModel(); 
        private Helper hp = new Helper();
        public ActionResult Index()
        {
            ViewData["SideActive"] = 1;
            return View();
        }

        public ActionResult ListAllProduct(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.Products.Count()); //傳入總筆數

            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<Product> products = db.Products.OrderBy(x => x.ProductID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 2;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數
            return View(products);
        }
        public ActionResult ListAllProductDetail(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.ProductDetails.Count()); //傳入總筆數

            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<ProductDetail> productDetils = db.ProductDetails.OrderBy(x => x.PDID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 3;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數

            return View(productDetils);
        }
        public ActionResult ListAllCategory(int id = 1)
        {
            int activePage = id; //目前所在頁

            //計算Page頁數
            int Pages = hp.Cul_Pages(db.Categories.Count()); //傳入總筆數

            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<Category> categories = db.Categories.OrderBy(x => x.CategoryID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 4;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數

            return View(categories);
        }
        public ActionResult ListAllImage(int id = 1)
        {
            int activePage = id; //目前所在頁

            //計算Page頁數
            int Pages = hp.Cul_Pages(db.Images.Count()); //傳入總筆數
            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<Image> images = db.Images.OrderBy(x => x.ImgID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 5;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數

            return View(images);
        }
        public ActionResult ListAllSize(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.Sizes.Count()); //傳入總筆數
            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<Size> sizes = db.Sizes.OrderBy(x => x.SizeID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 6;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數

            return View(sizes);
        }
        public ActionResult ListAllColor(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.Colors.Count()); //傳入總筆數

            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<Color> colors = db.Colors.OrderBy(x => x.ColorID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 7;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數

            return View(colors);
        }
        public ActionResult ListAllDesDetail(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.DesDetails.Count()); //傳入總筆數

            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<DesDetail> desDetails = db.DesDetails.OrderBy(x => x.DDID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 8;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數

            return View(desDetails);
        }
        public ActionResult ListAllDesSubTitle(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.DesSubTitles.Count()); //傳入總筆數

            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<DesSubTitle> desSubTitles = db.DesSubTitles.OrderBy(x => x.DSTID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 9;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數

            return View(desSubTitles);
        }

        public ActionResult ListAllOrder(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.Orders.Count()); //傳入總筆數

            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<Order> orders  = db.Orders.OrderBy(x => x.OrderID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 10;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數

            return View(orders);
        }

        public ActionResult ListAllOrderDetail(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.OrderDetails.Count()); //傳入總筆數

            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<OrderDetail> orderDetails  = db.OrderDetails.OrderBy(x => x.OrderID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 11;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數

            return View(orderDetails);
        }

        public ActionResult ListAllShipper(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.Shippers.Count()); //傳入總筆數

            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<Shipper> shippers = db.Shippers.OrderBy(x => x.ShipperID).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 12;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數

            return View(shippers);
        }

        public ActionResult ListAllIdentityModels(int id = 1)
        {
            int activePage = id; //目前所在頁
            //計算Page頁數
            int Pages = hp.Cul_Pages(db.AspNetUsers.Count()); //傳入總筆數

            int startRow = (activePage - 1) * ConstantData.PageRows;  //起始記錄Index

            List<AspNetUser> aspNetUsers = db.AspNetUsers.OrderBy(x => x.Id).Skip(startRow).Take(ConstantData.PageRows).ToList();

            ViewData["PageActive"] = id;    //Active頁碼
            ViewData["SideActive"] = 13;    //Active Dashboard
            ViewData["Pages"] = Pages;  //頁數

            return View(aspNetUsers);
        }
    }
}