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
                new SidebarItem { Id = (int)SideIndex.Product, Name = "產品", SideGroup = (int)SideGroup.product, Icon = "ti-camera", Url = "/BackSystem/ListAllProduct"},
                new SidebarItem { Id = (int)SideIndex.ProductDetail, Name = "產品明細", SideGroup = (int)SideGroup.product, Icon = "ti-camera", Url = "/BackSystem/ListAllProductDetail"},
                new SidebarItem { Id = (int)SideIndex.Category, Name = "類別", SideGroup = (int)SideGroup.product, Icon = "ti-camera", Url = "/BackSystem/ListAllCategory"},
                new SidebarItem { Id = (int)SideIndex.Image, Name = "圖片", SideGroup = (int)SideGroup.product, Icon = "ti-camera", Url = "/BackSystem/ListAllImage"},
                new SidebarItem { Id = (int)SideIndex.Size, Name = "尺寸", SideGroup = (int)SideGroup.product, Icon = "ti-camera", Url = "/BackSystem/ListAllSize"},
                new SidebarItem { Id = (int)SideIndex.Color, Name = "顏色", SideGroup = (int)SideGroup.product, Icon = "ti-camera", Url = "/BackSystem/ListAllColor"},
                new SidebarItem { Id = (int)SideIndex.DesDetail, Name = "DesDetail", SideGroup = (int)SideGroup.product, Icon = "ti-camera", Url = "/BackSystem/ListAllDesDetail"},
                new SidebarItem { Id = (int)SideIndex.DesSubTitle, Name = "DesSubTitle", SideGroup = (int)SideGroup.product, Icon = "ti-camera", Url = "/BackSystem/ListAllDesSubTitle"},
                new SidebarItem { Id = (int)SideIndex.Order, Name = "訂單", SideGroup = (int)SideGroup.order, Icon = "ti-shopping-cart", Url = "/BackSystem/ListAllOrder"},
                new SidebarItem { Id = (int)SideIndex.OrderDetail, Name = "訂單明細", SideGroup = (int)SideGroup.order, Icon = "ti-shopping-cart", Url = "/BackSystem/ListAllOrderDetail"},
                new SidebarItem { Id = (int)SideIndex.Shipper, Name = "物流", SideGroup = (int)SideGroup.order, Icon = "ti-truck", Url = "/BackSystem/ListAllShipper"},
                new SidebarItem { Id = (int)SideIndex.IdentityModels, Name = "帳戶管理", SideGroup = (int)SideGroup.Identity, Icon = "ti-user", Url = "/BackSystem/ListAllIdentityModels"},
                new SidebarItem { Id = (int)SideIndex.BackSystemRegister, Name = "後台帳戶註冊", SideGroup = (int)SideGroup.Identity, Icon = "ti-user", Url = "/BackSystem/BackSystemRegister"}

            };

            return cates;
        }
    }
}