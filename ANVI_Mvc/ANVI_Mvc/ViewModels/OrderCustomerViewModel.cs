﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ANVI_Mvc.Models;

namespace ANVI_Mvc.ViewModels
{
    public class OrderCustomerViewModel
    {
        [Display(Name = "姓名")]
        [Required]
        public string CustomerName { get; set; }

        [Display(Name = "手機號碼")]
        [Required]
        public string Phone { get; set; }
        //public string Country { get; set; }
        public string City { get; set; }

        [Display(Name = "電子信箱")]
        [EmailAddressAttribute]
        [Required]
        public string Email { get; set; }

        [Display(Name = "地址")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "郵遞區號")]
        public string ZipCode { get; set; }
        // public string BankAccount { get; set; }
        //public string CreditCard { get; set; }

        //以下是資料庫沒有的欄位
        public string Bill_CustomerName { get; set; }
        public string Bill_Address { get; set; }
        public string Bill_City { get; set; }
        public string Bill_ZipCode { get; set; }
        public string Bill_Phone { get; set; }
    }
}