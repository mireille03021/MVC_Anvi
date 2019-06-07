using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANVI_Mvc.ViewModels;

namespace ANVI_Mvc.Helpers
{
    public class Site
    {
        public List<SidebarItem> GetCategoriesData()
        {
            List<SidebarItem> cates = new List<SidebarItem>()
            {
                new SidebarItem { Id = 1, Name = "首頁", Url = "/BackSystem/Index"},
                new SidebarItem { Id = 2, Name = "產品", Url = "/BackSystem/ListAllProduct"},
                new SidebarItem { Id = 3, Name = "產品明細", Url = "/BackSystem/ListAllProductDetail"},
                new SidebarItem { Id = 4, Name = "類別", Url = "/BackSystem/ListAllCategory"},
                new SidebarItem { Id = 5, Name = "圖片", Url = "/BackSystem/ListAllImage"},
                new SidebarItem { Id = 6, Name = "尺寸", Url = "/BackSystem/ListAllSize"},
                new SidebarItem { Id = 7, Name = "顏色", Url = "/BackSystem/ListAllColor"},
                new SidebarItem { Id = 8, Name = "DesDetail", Url = "/BackSystem/ListAllDesDetail"},
                new SidebarItem { Id = 9, Name = "DesSubTitle", Url = "/BackSystem/ListAllDesSubTitle"},
                new SidebarItem { Id = 10, Name = "訂單", Url = "/BackSystem/ListAllOrder"},
                new SidebarItem { Id = 11, Name = "訂單明細", Url = "/BackSystem/ListAllOrderDetail"},
                new SidebarItem { Id = 12, Name = "物流", Url = "/BackSystem/ListAllShipper"},
                new SidebarItem { Id = 13, Name = "帳戶管理", Url = "/BackSystem/ListAllIdentityModels"}
            };

            return cates;
        }
    }
}