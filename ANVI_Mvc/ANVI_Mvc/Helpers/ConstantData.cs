using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANVI_Mvc.Helpers
{
    public class ConstantData
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
            BackSystemRegister = 14
        }
    }
}