using PaginatorAsync.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaginatorAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // random items
            var items = GetGenerateItems(6000);

            // Items per page
            const int quantityItemsPerPage = 100;

            // Total of pages for wait to finish and start nexts pages
            const int totalPageGroups = 5;

            Console.WriteLine("start print.");

            // execute task for page groups
            await TaskHelper.ExecutePages(
                items,
                quantityItemsPerPage,
                totalPageGroups,
                async (int currentPage, IEnumerable<int> itemsPage) =>
                {
                    
                    await  PrintItems(currentPage, itemsPage);
                    

                });

            Console.WriteLine("end print.");
        }


        static async Task PrintItems(int currentPage, IEnumerable<int> itemsPage)
        {      
            Console.WriteLine($"START PAGE = {currentPage}");

            await Task.Delay(1000);

            foreach (var item in  itemsPage)
                Console.WriteLine($" My item is {item}");



            Console.WriteLine($"FINISH PAGE = {currentPage}");

            //Thread.Sleep(1000);
        }


        static List<int> GetGenerateItems(int totalItems)
        {
            Random rnd = new Random();
            var items = new List<int>();

            for (var i = 0; i <= totalItems; i++)
                items.Add(rnd.Next());

            return items;
        }
    }
}
