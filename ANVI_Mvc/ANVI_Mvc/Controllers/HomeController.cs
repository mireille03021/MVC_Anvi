using System;
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
        public ActionResult ProductsPage() //商品頁面
        {
            ViewBag.Title = "PRODUCTS";
            ViewBag.ActionName = "GetProducts";
            ViewBag.Controller = "Home";
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetProducts()
        {
            ProductsService service = new ProductsService(db);
            ViewData.Model = service.getPageOfProducts()/*.Where(x => x.CategoryName == "Necklaces").ToList()*/;
            return PartialView("_ProductsPartial");
        }
        //---------------------單一商品頁面-----------------------
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ProductDetailPage(int id)  //單一商品頁面 Get
        {
            ProductViewModelService service = new ProductViewModelService(db, id);
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
        public ActionResult ChangeColor(int id, string DropDownList_Color)  //單一商品頁面Post
        {
            ProductViewModelService service = new ProductViewModelService(db, id);
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
        public ActionResult BuyItNow(string pdid)  //偷偷練一下Dapper，讓我寫Search前可以上手 by逢xD
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
            //var OCVM = (OrderCustomerViewModel)Session["Order_Session"];
            //ViewData["Email"] = OCVM.Email;
            //ViewData["Address"] = OCVM.Address;
            //ViewData.Model = OCVM;

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
        //[Authorize]
        public ActionResult AccountPage()   //主頁面
        {
            return View();
        }
    }
}