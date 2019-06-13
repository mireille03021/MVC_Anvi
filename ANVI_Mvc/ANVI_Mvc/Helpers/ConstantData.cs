using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ANVI_Mvc.Helpers
{
    public static class ConstantData
    {
        public const int PageRows = 10;

        public static List<string> Citys = new List<string>()
        {
            "台北市", "新北市", "基隆市", "桃園市", "新竹市",
            "新竹縣", "苗栗縣", "台中市", "彰化縣", "南投縣",
            "雲林縣", "嘉義市", "嘉義縣", "台南市", "高雄市",
            "屏東縣", "宜蘭縣", "花蓮縣", "台東縣", "澎湖縣",
            "金門縣", "連江縣"
        };

        public enum SideGroup
        {
            product = 1,
            order = 2,
            Identity = 3,
            productChart = 4,
            OrderChart = 5
        }

        public enum SideIndex
        {
            Index = 1,
            Product = 2,
            ProductDetail = 3,
            Category = 4,
            Image = 5,
            Size = 6,
            Color = 7,
            DesDetail = 8,
            DesSubTitle = 9,
            Order = 10,
            OrderDetail = 11,
            Shipper = 12,
            IdentityModels = 13,
            BackSystemRegister = 14,
            AllStockChart = 15,
            AllKindChart = 16
        }

        public enum StockEnough
        {
            NotEnough5 = 1,
            Enough5NotEnough10 = 2,
            Enough10NotEnough20 = 3
        }

        public static Dictionary<int, string> BackgroundColor = new Dictionary<int, string>();

        public static void CreatBackgroundColor()
        {
            BackgroundColor.Add(1, "rgba(255, 99, 132, 0.2)");
            BackgroundColor.Add(2, "rgba(255, 206, 86, 0.2)");
            BackgroundColor.Add(3, "rgba(75, 192, 192, 0.2)");
        }

        public static Dictionary<int, string> BorderColor = new Dictionary<int, string>();

        public static void CreatBorderColor()
        {
            BorderColor.Add(1, "rgba(255,99,132,1)");
            BorderColor.Add(2, "rgba(255, 206, 86, 1)");
            BorderColor.Add(3, "rgba(75, 192, 192, 1)");
        }
    }
}