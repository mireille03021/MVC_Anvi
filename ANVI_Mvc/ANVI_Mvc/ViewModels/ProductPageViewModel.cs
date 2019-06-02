using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANVI_Mvc.ViewModels
{
    public class ProductPageViewModel
    {
        public string CategoryName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string PDID { get; set; }
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public string ImgName { get; set; }
    }
}