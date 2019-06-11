using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANVI_Mvc.ViewModels;
using static ANVI_Mvc.Helpers.ConstantData;

namespace ANVI_Mvc.Helpers
{
    public class Site
    {
        public List<SidebarItem> GetCategoriesData()
        {
            List<SidebarItem> cates = new List<SidebarItem>()
            {
                new SidebarItem { Id = (int)SideIndex.Index, Name = "首頁", Url = "/BackSystem/Index"},
                new SidebarItem { Id = (int)SideIndex.Product, Name = "產品", Url = "/BackSystem/ListAllProduct"},
                new SidebarItem { Id = (int)SideIndex.ProductDetail, Name = "產品明細", Url = "/BackSystem/ListAllProductDetail"},
                new SidebarItem { Id = (int)SideIndex.Category, Name = "類別", Url = "/BackSystem/ListAllCategory"},
                new SidebarItem { Id = (int)SideIndex.Image, Name = "圖片", Url = "/BackSystem/ListAllImage"},
                new SidebarItem { Id = (int)SideIndex.Size, Name = "尺寸", Url = "/BackSystem/ListAllSize"},
                new SidebarItem { Id = (int)SideIndex.Color, Name = "顏色", Url = "/BackSystem/ListAllColor"},
                new SidebarItem { Id = (int)SideIndex.DesDetail, Name = "DesDetail", Url = "/BackSystem/ListAllDesDetail"},
                new SidebarItem { Id = (int)SideIndex.DesSubTitle, Name = "DesSubTitle", Url = "/BackSystem/ListAllDesSubTitle"},
                new SidebarItem { Id = (int)SideIndex.Order, Name = "訂單", Url = "/BackSystem/ListAllOrder"},
                new SidebarItem { Id = (int)SideIndex.OrderDetail, Name = "訂單明細", Url = "/BackSystem/ListAllOrderDetail"},
                new SidebarItem { Id = (int)SideIndex.Shipper, Name = "物流", Url = "/BackSystem/ListAllShipper"},
                new SidebarItem { Id = (int)SideIndex.IdentityModels, Name = "帳戶管理", Url = "/BackSystem/ListAllIdentityModels"},
                new SidebarItem { Id = (int)SideIndex.BackSystemRegister, Name = "後台帳戶註冊", Url = "/BackSystem/BackSystemRegister"}

            };

            return cates;
        }
    }
}