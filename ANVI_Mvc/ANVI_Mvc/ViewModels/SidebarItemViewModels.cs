using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANVI_Mvc.ViewModels
{
    public class SidebarItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SideGroup { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}