using PaginatorAsync.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatorAsync.Extensions
{
    public static class PageConfigExtensions
    {
        public static int GetPageDefault(this int? page)
        {
            var pageValue = page.GetValueOrDefault();
            return pageValue > 0 ? pageValue : PageConst.PageDefault;
        }


        public static int GetPageSizeDefault(this int? pageSize)
        {
            var pageSizeValue = pageSize.GetValueOrDefault();
            return pageSizeValue > 0 ? pageSizeValue : PageConst.PageSizeDefault;
        }
    }
}
