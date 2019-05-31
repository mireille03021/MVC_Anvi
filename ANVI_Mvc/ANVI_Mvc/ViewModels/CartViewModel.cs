using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANVI_Mvc.Models;

namespace ANVI_Mvc.ViewModels
{
    public class CartViewModel
    {
        public CartModel Cart { get; set; }
        public string[] Images { get; set; }
    }
}