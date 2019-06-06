using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANVI_Mvc.Models;

namespace ANVI_Mvc.ViewModels
{
    public class AccountPageViewModel
    {
        public AspNetUser User { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Image> images { get; set; }
    }
}