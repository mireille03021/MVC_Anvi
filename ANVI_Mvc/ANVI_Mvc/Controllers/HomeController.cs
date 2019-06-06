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
using Microsoft.AspNet.Identity;
using ANVI_Mvc.Helpers;
using System.Data.Entity;

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
            //var Userid = User.Identity.GetUserId();
            //var user = db.AspNetUsers.FirstOrDefault(x => x.Id == Userid);
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
        public ActionResult GetProducts(int page, List<Product> AllProducts)
        {
            //每八個一頁
            var ProductNumber = 8;
            //取得目前頁所需要顯示的物品
            var pList = AllProducts.Skip((page - 1) * ProductNumber).Take(page * ProductNumber).ToList();

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
                                 "p.UnitPrice, " +
                                 "s.SizeContext, " +
                                 "c.ColorID, " +
                                 "c.ColorName, " +
                                 "pd.PDID " +
                                 "from Products p " +
                                 "inner join ProductDetails pd on p.ProductID = pd.ProductID " +
                                 "inner join Sizes s on pd.SizeID = s.SizeID " +
                                 "inner join Colors c on pd.ColorID = c.ColorID " +
                                 "inner join Categories cat on p.CategoryID = cat.CategoryID " +
                                 "where pd.PDID = " + "'" + pdid + "'";
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
                Session["BuyItNow"] = new BuyOneViewModel() { CartItem = product, Image = image };
                //這是傳給HttpGet喔！
                return RedirectToAction("Order_Customer", "Home"/*, new {product = product, image = image}*/);
            }
        }
        //-----------------------------------------------------------------
        //----------------------------下單-----------------------------
        [HttpGet]
        [Authorize]
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

            if (Order_Pay_Radio)
            {
                Session["Bill_Order_Seccion"] = Bill_OCVM;
                ViewData["Bill_CustomerName"] = Bill_OCVM.Bill_CustomerName;
                ViewData["Bill_City"] = Bill_OCVM.Bill_City;
                ViewData["Bill_ZipCode"] = Bill_OCVM.Bill_ZipCode;
                ViewData["Bill_Address"] = Bill_OCVM.Bill_Address;
                ViewData["Bill_Phone"] = Bill_OCVM.Bill_Phone;
            }

            //SQL

            var REPO_O = new Repositories.AnviRepository<Order>(db);
            var REPO_OD = new Repositories.AnviRepository<OrderDetail>(db);
            var O = new Order();

            // 存到Order資料庫
            O.RecipientName = OCVM.CustomerName;
            O.RecipientCity = OCVM.City;
            O.RecipientZipCod = OCVM.ZipCode;
            O.RecipientAddressee = OCVM.Address;
            O.RecipientPhone = OCVM.Phone;

            O.UserID = "IDU0007";
            O.Payment = "銀行轉帳";
            O.Remaeks = "嗨嗨1小時內寄來";
            O.OrderDate = DateTime.Now;
            O.ShipDate = DateTime.Now.AddHours(1);

            REPO_O.Create(O);
            db.SaveChanges();
            var OrderList = db.Orders.ToList();
            var OrderID = OrderList.Last().OrderID;

            if ((bool)Session["CartToHere"])
            {
                var currentCart = CartService.GetCurrentCart();
                foreach (var item in currentCart)
                {
                    var OD = new OrderDetail();
                    OD.PDID = item.PDID;
                    OD.OrderID = OrderID;
                    OD.Price = item.UnitPrice;
                    OD.Quantity = item.Quantity;
                    db.OrderDetails.Add(OD);
                }
            }
            else // BuyItNow
            {
                var OD = new OrderDetail();
                var BuyItNow = (BuyOneViewModel)Session["BuyItNow"];
                OD.PDID = BuyItNow.CartItem.PDID;
                OD.OrderID = OrderID;
                OD.Price = BuyItNow.CartItem.UnitPrice;
                OD.Quantity = BuyItNow.CartItem.Quantity;
                REPO_OD.Create(OD);
            }
            db.SaveChanges();

            ViewData.Model = CartService.GetCurrentCart();
            ViewBag.Img = CartService.getEachProductImages(db);
            //購買完成，清除購物車
            CartService.ClearCart();
            return View("Order_Check");
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Order_Check()  //下單-確認頁面!沒有HEADER跟FOOTER
        {
            var OCVM = (OrderCustomerViewModel)Session["Order_Session"];
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

            if (Order_Pay_Radio)
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
        public ActionResult getOrderPartial(CartModel currentCart, string[] images)   //導向Partial
        {
            var Img = CartService.getEachProductImages(db);
            ViewBag.Img = Img;
            if (currentCart.Count != 0)
            {
                ViewBag.Img = images;
                ViewData.Model = currentCart;
            }
            return PartialView("_OrderPartial");
        }

        [HttpGet]
        [Authorize]
        //[AllowAnonymous]
        public ActionResult AccountPage()   //帳戶主頁面
        {
            AccountPageViewModel model = new AccountPageViewModel();
            var userID = User.Identity.GetUserId();
            model.User = db.AspNetUsers.FirstOrDefault(x => x.Id == userID);
            if(db.Orders.Any(x => x.UserID == userID))
            {
                List<Order> orders = db.Orders.Where(x => x.UserID == userID).OrderByDescending(x => x.OrderID).ToList();
                model.Orders = orders;
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                List<Image> images = new List<Image>();
                int endIndext = 0;
                string PDIDtoFindImg = string.Empty;
                foreach (var item in orders)
                {
                    var thisOrderDetails = db.OrderDetails.Where(x => x.OrderID == item.OrderID).ToList();
                    foreach (var sonitem in thisOrderDetails)
                    {
                        orderDetails.Add(sonitem);
                        endIndext = sonitem.PDID.IndexOf("-");
                        PDIDtoFindImg = sonitem.PDID.Substring(0, endIndext) + "-1";
                        if(!images.Any(x => x.PDID == PDIDtoFindImg))
                        {
                            images.Add(db.Images.First(x => x.PDID == PDIDtoFindImg));
                        }
                    }
                }
                model.OrderDetails = orderDetails;
                model.images = images;
            }
            ViewBag.City = new SelectList(ConstantData.citys, model.User.City);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        //[AllowAnonymous]
        public ActionResult AccountPage([Bind(Include = "Id, Name, Email, PhoneNumber, City, Address, ZipCode")] AccountPageViewModel model)   //帳戶主頁面
        {
            if (ModelState.IsValid)
            {
                db.Entry(model.User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AccountPage");
            }
            ViewBag.City = new SelectList(ConstantData.citys, model.User.City);
            return View(model);
        }
    }
}