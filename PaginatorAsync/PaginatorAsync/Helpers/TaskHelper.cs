using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginatorAsync.Helpers
{
    public static class TaskHelper
    {
        public static async Task ExecutePages(IEnumerable<int> listForPaging, int quantityItemsPerPage, int totalPageGroups, Func<int,IEnumerable<int>, Task> func)
        {
            var pageGroups = PageGroupHelper.GetGroupPages(listForPaging.Count(), quantityItemsPerPage, totalPageGroups);

            foreach (var item in pageGroups)
            {
                var pages = item.Value;
                var tasks = pages.Select(async page => 
                {
                    await ExecuteTaskPage(page, listForPaging, quantityItemsPerPage, func);
                });
                await Task.WhenAll(tasks);

            }
        }

        private static async Task ExecuteTaskPage(int page, IEnumerable<int> list, int quantityItemsPerPage, Func<int,IEnumerable<int>, Task> func)
        {
            int count = (page * quantityItemsPerPage);

            var itemsPage = list.Skip(count).Take(quantityItemsPerPage);

            await func(page,itemsPage);


        }
    }
}
