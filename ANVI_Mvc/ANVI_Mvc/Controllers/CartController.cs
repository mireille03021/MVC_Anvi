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
        public ActionResult GetCart()
        {
            return View("ShoppingCart");
        }

        public ActionResult AddToCart(string id)
        {
            currentCart.AddCartItem(id);
            return RedirectToAction("ShoppingCart", "Cart");
        }
        public ActionResult ShoppingCart()  //購物車頁面
        {
            if (CartService.GetCurrentCart() != null)
            {
                var stocks = CartService.getEachProductStocks(db);
                var images = CartService.getEachProductImages(db);
                ViewBag.Stocks = stocks;
                ViewBag.Images = images;
                ViewBag.CheckStocks = true;
            }
            return View();
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
        public ActionResult SubmitOrder()
        {
            var stocks = CartService.getEachProductStocks(db);
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
            return RedirectToAction("Order_Customer", "Home");
        }

        public ActionResult DeleteCartItem(string pdid)
        {

            return View("ShoppingCart");
        }
    }
}