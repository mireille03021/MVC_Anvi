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
            int Days = DateTime.Today.Day;
            int Month = DateTime.Today.Month;
            string LineLabels = string.Empty;
            string LineData = string.Empty;
            
            //產生折線圖資料
            var TotalSales =
                from o in db.Orders
                join od in db.OrderDetails on o.OrderID equals od.OrderID
                where o.OrderDate.Month == DateTime.Now.Month
                select new
                {
                    OrderID = o.OrderID,
                    PDID = od.PDID,
                    Price = od.Price,
                    Quantity = od.Quantity,
                    Discount = od.Discount,
                    orderDate = o.OrderDate,
                    CategoryID = od.ProductDetail.Product.CategoryID
                };
            var Amount = TotalSales.Sum(x => x.Price * x.Quantity);

            for (int i = 1; i <= Days; i++) //i 為x軸的日期值
            {
                LineLabels += $"'{Month}/{i}'";
                int dayTotal = TotalSales.Where(x => x.orderDate.Month == Month && x.orderDate.Day == i).ToList().Count;
                LineData += $"{{x:{Month}/{i},y:{dayTotal}}}";
                if (i != Days)
                {
                    LineLabels += ",";
                    LineData += ",";
                }
            }

            //產生圓餅圖資料
            string PieLabels = string.Empty;
            string PieDataProduct = string.Empty;
            string PieDataSales = string.Empty;
            List<Category> categories = db.Categories.OrderBy(x => x.CategoryID).ToList();
            int j = 0;
            foreach (var item in categories)
            {
                int count = db.Products.Where(x => x.CategoryID == item.CategoryID).ToList().Count;
                int SalesCount = TotalSales.Where(x => x.CategoryID == item.CategoryID).ToList().Count;
                PieLabels += $"'{item.CategoryName}'";
                PieDataProduct += $"{count}";
                PieDataSales += $"{SalesCount}";
                if (j != categories.Count)
                {
                    PieLabels += ",";
                    PieDataProduct += ",";
                    PieDataSales += ",";
                }
                j++;
            }

            ViewBag.PieLabels = PieLabels;
            ViewBag.pieDataProduct = PieDataProduct;
            ViewBag.pieDataSales = PieDataSales;
            ViewBag.LineLabels = LineLabels;
            ViewBag.LineData = LineData;
            ViewBag.UserCount = db.AspNetUsers.Count();
            ViewBag.SalesProductCount = db.OrderDetails.Count();
            ViewBag.TotalSales = Amount;
            return View();
        }

        [HttpGet]
        public ActionResult BackSystemRegister()  //後台註冊頁面
        {
            ViewBag.RoleString = new SelectList(db.AspNetRoles, "Name", "Name");
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
            if (BackgroundColor.Count == 0)
            {
                CreatBackgroundColor();
            }
            if (BorderColor.Count == 0)
            {
                CreatBorderColor();
            }
            int count = productDetils.Count;
            string LineLabels = string.Empty;
            string LineData = string.Empty;
            string backgroundColor = string.Empty;
            string borderColor = string.Empty;
            int i = 0;

            foreach (var item in productDetils)
            {
                LineLabels += $"'{item.PDID}'";
                LineData += $"{item.Stock}";
                if (item.Stock < 5)
                {
                    backgroundColor += $"'{BackgroundColor[(int)StockEnough.NotEnough5]}'";
                    borderColor += $"'{BorderColor[(int)StockEnough.NotEnough5]}'";
                }
                else if (item.Stock < 10 && item.Stock > 5)
                {
                    backgroundColor += $"'{BackgroundColor[(int)StockEnough.Enough5NotEnough10]}'";
                    borderColor += $"'{BorderColor[(int)StockEnough.Enough5NotEnough10]}'";
                }
                else
                {
                    backgroundColor += $"'{BackgroundColor[(int)StockEnough.Enough10NotEnough20]}'";
                    borderColor += $"'{BorderColor[(int)StockEnough.Enough10NotEnough20]}'";
                }

                if (i != count - 1)
                {
                    LineLabels += ",";
                    LineData += ",";
                    backgroundColor += ",";
                    borderColor += ",";
                }
                i++;
            }

            ViewBag.Labels = LineLabels;
            ViewBag.Data = LineData;
            ViewBag.BackgroundColor = backgroundColor;
            ViewBag.BorderColor = borderColor;
            return View();
        }

        public ActionResult ThisMonthSalesChart()
        {
            int Days = DateTime.Today.Day;
            int Month = DateTime.Today.Month;
            string LineLabels = string.Empty;
            string LineData = string.Empty;

            //產生折線圖資料
            var TotalSales =
                from o in db.Orders
                join od in db.OrderDetails on o.OrderID equals od.OrderID
                where o.OrderDate.Month == DateTime.Now.Month
                select new
                {
                    OrderID = o.OrderID,
                    PDID = od.PDID,
                    Price = od.Price,
                    Quantity = od.Quantity,
                    Discount = od.Discount,
                    orderDate = o.OrderDate,
                    CategoryID = od.ProductDetail.Product.CategoryID
                };
            var Amount = TotalSales.Sum(x => x.Price * x.Quantity);

            for (int i = 1; i <= Days; i++) //i 為x軸的日期值
            {
                LineLabels += $"'{Month}/{i}'";
                int dayTotal = TotalSales.Where(x => x.orderDate.Month == Month && x.orderDate.Day == i).ToList().Count;
                LineData += $"{{x:{Month}/{i},y:{dayTotal}}}";
                if (i != Days)
                {
                    LineLabels += ",";
                    LineData += ",";
                }
            }

            ViewBag.LineLabels = LineLabels;
            ViewBag.LineData = LineData;
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