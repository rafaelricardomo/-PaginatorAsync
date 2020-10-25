using System;
using System.Collections.Generic;
using System.Text;

namespace PaginatorAsync.Helpers
{
    public static class PageGroupHelper
    {
        private const int TotalPageDefault = 1;
        public static Dictionary<int, List<int>> GetGroupPages(int total, int quantityItemsInPage, int totalGroupPages)
        {
            var pageGroup = new Dictionary<int, List<int>>();

            if (total == 0)
                return pageGroup;

            double pages = TotalPageDefault;
            if (total >= quantityItemsInPage)
                pages = (total / quantityItemsInPage);
            else
                totalGroupPages = TotalPageDefault;

            var totalPages = Math.Round(pages);

            var pageList = new List<int>();
            int pageCount = 1;
            int pageGroupCount = 1;

            for (var i = 1; i <= totalPages; i++)
            {
                if (pageList == null)
                    pageList = new List<int>();
                pageList.Add(i);

                if (pageCount == totalGroupPages)
                {
                    pageGroup[pageGroupCount] = pageList;
                    pageGroupCount++;
                    pageList = null;
                    pageCount = 1;
                    continue;
                }

                pageCount++;

            }

            return pageGroup;
        }
    }
}
