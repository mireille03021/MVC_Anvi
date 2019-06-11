using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ANVI_Mvc.Models
{
    public class ViewWord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string WordName { get; set; }

        [Required]
        public string WordContent { get; set; }
    }
}