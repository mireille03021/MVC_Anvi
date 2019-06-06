using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANVI_Mvc.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
    }
}