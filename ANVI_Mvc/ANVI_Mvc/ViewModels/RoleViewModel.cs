using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ANVI_Mvc.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "角色名稱")]
        public string Name { get; set; }

        [Display(Name = "角色描述")]
        public string Description { get; set; }
    }
}