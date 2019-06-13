using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANVI_Mvc.Models;
using ANVI_Mvc.Services;
using ANVI_Mvc.ViewModels;
using WebGrease.Css.Extensions;

namespace ANVI_Mvc.Controllers
{
    public class CartController : Controller
    {
        private AnviModel db;
        private CartModel currentCart;

        public CartController()
        {
            db = new AnviModel();
            currentCart = CartService.GetCurrentCart();
        }

        [HttpPost]
        public ActionResult AddToCart(string pdid)
        {
            currentCart.AddCartItem(pdid);
            return RedirectToAction("ShoppingCart", "Cart");
        }

        public ActionResult ShoppingCart()  //購物車頁面
        {
            return View();
        }

        public ActionResult GetCartItem()
        {
            var images = CartService.getEachProductImages(db);
            CartViewModel CVM = new CartViewModel() {Cart = currentCart, Images = images};
            return PartialView("_CartItemPartial",CVM);
        }

        [HttpPost]
        public ActionResult AddQuantity(string pdid)  //PDID指定物品用
        {
            currentCart.AddQuantity(pdid);
            return RedirectToAction("ShoppingCart", "Cart");
        }

        [HttpPost]
        public ActionResult ReduceQuantity(string pdid)  //指定物品用
        {
            currentCart.ReduceQuantity(pdid);
            return RedirectToAction("ShoppingCart", "Cart");
        }

        [HttpPost]
        public ActionResult DeleteCartItem(string pdid)
        {
            currentCart.DeleCartItem(pdid);
            return RedirectToAction("ShoppingCart", "Cart");
        }

        [HttpPost]
        public ActionResult SubmitOrder(string Remark)
        {
            var stocks = CartService.getEachProductStocks();
            for (int i = 0; i < currentCart.Count; i++)
            {
                if (stocks[i] < currentCart.cartItems[i].Quantity)
                {
                    var images = CartService.getEachProductImages(db);
                    ViewBag.Stocks = stocks;
                    ViewBag.Images = images;
                    ViewBag.CheckStocks = false;
                    return View("ShoppingCart");
                }
            }
            Session["Remark"] = Remark;
            Session["CartToHere"] = true;
            return RedirectToAction("Order_Customer", "Home");
        }
    }
}