﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using ANVI_Mvc.Models;
using ANVI_Mvc.Services;
using ANVI_Mvc.ViewModels;
using Dapper;

namespace ANVI_Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        protected AnviModel db;

        public HomeController()
        {
            db = new AnviModel();
        }
        [AllowAnonymous]
        public ActionResult Index()   //主頁面
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult ProductsPage(int page) //商品頁面
        {
            //取得此頁面是用什麼做分類的，因為這為總商品頁，所以不做分類
            ViewData.Model = db.Products/*.Where(x => x.CategoryID == 3)*/.ToList();

            //給上一頁下一頁按鈕使用
            ViewBag.mainController = "Home";
            ViewBag.mainActionName = "ProductsPage";

            //給@Html.Action使用，取得HomeController的GetProducts方法
            ViewBag.Title = "PRODUCTS";
            ViewBag.ActionName = "GetProducts";
            ViewBag.Controller = "Home";
            ViewBag.Page = page;
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetProducts(int page,List<Product> AllProducts)
        {
            //每八個一頁
            var ProductNumber = 8;  
            //取得目前頁所需要顯示的物品
            var pList = AllProducts.Skip((page-1)* ProductNumber).Take(page* ProductNumber).ToList();
            
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
                foreach(var item in FilterList)
                {
                    Model.Add(item);
                }
            }
            ViewData.Model = Model;
            return PartialView("_ProductsPartial");
        }
        //---------------------單一商品頁面-----------------------
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ProductDetailPage(int pid)  //單一商品頁面 Get
        {
            ProductViewModelService service = new ProductViewModelService(db, pid);
            var sPVM = service.PVM;
            ViewData.Model = sPVM;
            ViewBag.ColorList = db.Colors.ToList();
            ViewBag.JsonPVM = Newtonsoft.Json.JsonConvert.SerializeObject(sPVM.ProductDetailViewModels);

            ViewData["ColorName"] = sPVM.ProductDetailViewModels[0].ColorName;
            return View();
        }
        [MultiButton("ChangeColor")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ChangeColor(int pid, string DropDownList_Color)  //單一商品頁面Post
        {
            ProductViewModelService service = new ProductViewModelService(db, pid);
            var sPVM = service.PVM;
            ViewData.Model = sPVM;
            ViewBag.ColorList = db.Colors.ToList();
            ViewBag.JsonPVM = Newtonsoft.Json.JsonConvert.SerializeObject(sPVM.ProductDetailViewModels);

            ViewData["ColorName"] = DropDownList_Color;
            return View("ProductDetailPage");
        }

        [MultiButton("BuyItNow")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult BuyItNow(string pdid)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AnviConnection"].ConnectionString;
            string queryString = "select " +
                                 "cat.CategoryName, " +
                                 "p.ProductID, " +
                                 "p.ProductName, " +
                                 "p.UnitPrice, "+
                                 "s.SizeContext, " +
                                 "c.ColorID, " +
                                 "c.ColorName, " +
                                 "pd.PDID " +
                                 "from Products p " +
                                 "inner join ProductDetails pd on p.ProductID = pd.ProductID " +
                                 "inner join Sizes s on pd.SizeID = s.SizeID " +
                                 "inner join Colors c on pd.ColorID = c.ColorID " +
                                 "inner join Categories cat on p.CategoryID = cat.CategoryID " +
                                 "where pd.PDID = " + "'"+ pdid +"'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                CartItemViewModel product = conn.QueryFirstOrDefault<CartItemViewModel>(queryString);
                string image = string.Empty;

                product.Quantity = 1;
                ViewData.Model = product;

                if (db.Images.Any(x => x.PDID == pdid))
                {
                    image = db.Images.First(x => x.PDID == pdid).ImgName;
                }
                //如果這個物品本身沒有圖片
                else
                {
                    var sameProductImage =      //找出此物品所屬的產品所有關聯的圖片
                        from p in db.Products
                        join pd in db.ProductDetails on p.ProductID equals pd.ProductID
                        join img in db.Images on pd.PDID equals img.PDID
                        where p.ProductID == product.ProductID && pd.ColorID == product.ColorID
                        select new
                        {
                            ImgName = img.ImgName
                        };
                    image = sameProductImage.First().ImgName;
                }

                Session["CartToHere"] = false;
                Session["BuyItNow"] = new BuyOneViewModel() {CartItem = product, Image = image};
                //這是傳給HttpGet喔！
                return RedirectToAction("Order_Customer", "Home"/*, new {product = product, image = image}*/);
            }
        }
        //-----------------------------------------------------------------
        //----------------------------下單-----------------------------
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Order_Customer(/*CartItemViewModel product,string image*/)  //下單-客戶頁面(填入收件人)!沒有HEADER跟FOOTER
        {
            var Img = CartService.getEachProductImages(db);
            ViewBag.Img = Img;

            if (Session["Order_Session"] != null)
            {
                var OCVM = (OrderCustomerViewModel)Session["Order_Session"];
                ViewData["CustomerName"] = OCVM.CustomerName;
                ViewData["City"] = OCVM.City;
                ViewData["ZipCode"] = OCVM.ZipCode;
                ViewData["Address"] = OCVM.Address;
                ViewData["Phone"] = OCVM.Phone;
                ViewData["Email"] = OCVM.Email;
            }

            ViewBag.CartToHere = Session["CartToHere"];
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Order_Customer(OrderCustomerViewModel OCVM)
        {
            Session["Order_Session"] = OCVM;
            ViewData["CustomerName"] = OCVM.CustomerName;
            ViewData["City"] = OCVM.City;
            ViewData["ZipCode"] = OCVM.ZipCode;
            ViewData["Address"] = OCVM.Address;
            ViewData["Phone"] = OCVM.Phone;
            ViewData["Email"] = OCVM.Email;
            ViewBag.CartToHere = Session["CartToHere"];
            return View("Order_Ship");
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Order_Ship()  //下單-運送頁面!沒有HEADER跟FOOTER
        {
            var OCVM = (OrderCustomerViewModel)Session["Order_Session"];
            ViewData["Email"] = OCVM.Email;
            ViewData["Address"] = OCVM.Address;
            ViewData.Model = OCVM;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Order_Ship(string Nothing)  //下單-運送頁面!沒有HEADER跟FOOTER
        {
            var OCVM = (OrderCustomerViewModel)Session["Order_Session"];
            ViewData["CustomerName"] = OCVM.CustomerName;
            ViewData["City"] = OCVM.City;
            ViewData["ZipCode"] = OCVM.ZipCode;
            ViewData["Address"] = OCVM.Address;
            ViewData["Phone"] = OCVM.Phone;
            ViewData["Email"] = OCVM.Email;
            ViewBag.CartToHere = Session["CartToHere"];
            ViewData.Model = OCVM;

            return View("Order_Pay");
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Order_Pay()  //下單-付費頁面!沒有HEADER跟FOOTER
        {
            var OCVM = (OrderCustomerViewModel)Session["Order_Session"];
            ViewData["Email"] = OCVM.Email;
            ViewData["Address"] = OCVM.Address;
            ViewData.Model = OCVM;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Order_Pay(OrderCustomerViewModel Bill_OCVM, bool Order_Pay_Radio)  //下單-付費頁面!沒有HEADER跟FOOTER
        {
            var OCVM = (OrderCustomerViewModel)Session["Order_Session"];
            ViewData["CustomerName"] = OCVM.CustomerName;
            ViewData["City"] = OCVM.City;
            ViewData["ZipCode"] = OCVM.ZipCode;
            ViewData["Address"] = OCVM.Address;
            ViewData["Phone"] = OCVM.Phone;
            ViewData["Email"] = OCVM.Email;

            if(Order_Pay_Radio)
            {
                Session["Bill_Order_Seccion"] = Bill_OCVM;
                ViewData["Bill_CustomerName"] = Bill_OCVM.Bill_CustomerName;
                ViewData["Bill_City"] = Bill_OCVM.Bill_City;
                ViewData["Bill_ZipCode"] = Bill_OCVM.Bill_ZipCode;
                ViewData["Bill_Address"] = Bill_OCVM.Bill_Address;
                ViewData["Bill_Phone"] = Bill_OCVM.Bill_Phone;
            }

            //購買完成，清除購物車
            CartService.ClearCart();
            return View("Order_Check");
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Order_Check()  //下單-確認頁面!沒有HEADER跟FOOTER
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Order_Check(bool Order_Pay_Radio)  //下單-確認頁面!沒有HEADER跟FOOTER
        {
            var OCVM = (OrderCustomerViewModel)Session["Order_Session"];
            ViewData["CustomerName"] = OCVM.CustomerName;
            ViewData["City"] = OCVM.City;
            ViewData["ZipCode"] = OCVM.ZipCode;
            ViewData["Address"] = OCVM.Address;
            ViewData["Phone"] = OCVM.Phone;
            ViewData["Email"] = OCVM.Email;

            if(Order_Pay_Radio)
            {

                var Bill_OCVM = (OrderCustomerViewModel)Session["Bill_Order_Seccion"];
                ViewData["Bill_CustomerName"] = Bill_OCVM.Bill_CustomerName;
                ViewData["Bill_City"] = Bill_OCVM.Bill_City;
                ViewData["Bill_ZipCode"] = Bill_OCVM.Bill_ZipCode;
                ViewData["Bill_Address"] = Bill_OCVM.Bill_Address;
                ViewData["Bill_Phone"] = Bill_OCVM.Bill_Phone;

            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult getOrderPartial()   //導向Partial
        {
            var Img = CartService.getEachProductImages(db);
            ViewBag.Img = Img;

            return PartialView("_OrderPartial");
        }

        //[Authorize]
        [AllowAnonymous]
        public ActionResult AccountPage()   //帳戶主頁面
        {
            return View();
        }
    }
}