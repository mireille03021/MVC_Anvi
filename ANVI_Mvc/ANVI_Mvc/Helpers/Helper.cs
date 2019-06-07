using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ANVI_Mvc.Helpers
{
    public class Helper
    {
        public int Cul_Pages(int totalRows)
        {
            int Pages = 0;
            if (totalRows % ConstantData.PageRows == 0)
            {
                Pages = totalRows / ConstantData.PageRows;
            }
            else
            {
                Pages = (totalRows / ConstantData.PageRows) + 1;
            }

            return Pages;
        }
    }
}