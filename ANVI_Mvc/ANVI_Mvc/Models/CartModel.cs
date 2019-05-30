﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANVI_Mvc.ViewModels;

namespace ANVI_Mvc.Models
{
    public class CartModel : IEnumerable<CartItemViewModel>
    {
        //建構值，初始化
        public List<CartItemViewModel> cartItems { get; set; }

        public CartModel()
        {
            this.cartItems = new List<CartItemViewModel>();
        }

        public int Count => this.cartItems.Count;

        //取得商品總價
        public decimal TotalAmount
        {
            get
            {
                decimal totalAmount = 0;
                foreach (var item in cartItems)
                {
                    totalAmount += item.Amount;
                }

                return totalAmount;
            }
        }

        public bool AddCartItem(string PDID)
        {
            //搜尋加入購物車的產品
            var findItem = this.cartItems
                                .Where(item => item.PDID == PDID)
                                .Select(item => item).FirstOrDefault();

            //判斷是否有相同產品存在購物車中
            using (AnviModel db = new AnviModel())
            {
                if (findItem == default(ViewModels.CartItemViewModel))
                {

                    var cartItem = (from p in db.Products
                                    join pd in db.ProductDetails on p.ProductID equals pd.ProductID
                                    join s in db.Sizes on pd.SizeID equals s.SizeID
                                    join c in db.Colors on pd.ColorID equals c.ColorID
                                    join cat in db.Categories on p.CategoryID equals cat.CategoryID
                                    where pd.PDID == PDID
                                    select new CartItemViewModel()
                                    {
                                        CategoryName = cat.CategoryName,
                                        ProductID = p.ProductID,
                                        ProductName = p.ProductName,
                                        UnitPrice = p.UnitPrice,
                                        PDID = pd.PDID,
                                        //Stock = pd.Stock,
                                        ColorID = c.ColorID,
                                        ColorName = c.ColorName,
                                        //SizeID = s.SizeID,
                                        //SizeTitle = s.SizeTitle,
                                        SizeContext = s.SizeContext
                                    }).FirstOrDefault();
                    if (cartItem != default(ViewModels.CartItemViewModel))
                    {
                        this.AddCartItem(cartItem);
                    }
                }
                else
                {
                    var stock = db.ProductDetails.First(x => x.PDID == findItem.PDID).Stock;
                    if (findItem.Quantity < stock)  //防止有人狂點購物車來新增物品，但實際庫存不足
                    {
                        findItem.Quantity += 1;
                    }
                }
            }
            return true;
        }
        //新增一筆CartItem
        private bool AddCartItem(CartItemViewModel cartItem)
        {
            var item = new CartItemViewModel()
            {
                ProductID = cartItem.ProductID,
                PDID = cartItem.PDID,
                ProductName = cartItem.ProductName,
                UnitPrice = cartItem.UnitPrice,
                Quantity = 1,
                CategoryName = cartItem.CategoryName,
                ColorID = cartItem.ColorID,
                ColorName = cartItem.ColorName,
                SizeContext = cartItem.SizeContext
            };

            cartItems.Add(item);
            return true;
        }

        public void AddQuantity(string PDID)
        {
            cartItems.First(x => x.PDID == PDID).Quantity += 1;
        }
        public void ReduceQuantity(string PDID)
        {
            cartItems.First(x => x.PDID == PDID).Quantity -= 1;
        }

        public IEnumerator<CartItemViewModel> GetEnumerator()
        {
            IEnumerable<CartItemViewModel> nothing = cartItems;
            return nothing.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}