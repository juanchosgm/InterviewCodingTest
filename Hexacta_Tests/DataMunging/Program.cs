using DataMunging.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataMunging
{
    class Program
    {
        static void Main(string[] args)
        {
            var categories = GetCategories("CFE,Coffee,Y\nFD,Food,Y\nPRS,Personal,N");
            var products = GetExpenses("Starbucks,3/10/2018,Iced Americano,4.28,CFE\nStarbucks,3/10/2018,Nitro Cold Brew,3.17,CFE\nStarbucks,3/10/2018,Souvineer Mug,8.19,PRS\nStarbucks,3/11/2018,Nitro Cold Brew,3.17,CFE\nHigh Point Market,3/11/2018,Iced Americano,2.75,CFE\nHigh Point Market,3/11/2018,Pastry,2.00,FD\nHigh Point Market,3/11/2018,Gift Card,10.00,PRS");   
            var groupingResult = products.GroupBy(p => new { p.PurchaseDate, p.Location })
                .OrderBy(p => p.Key.PurchaseDate).ThenBy(p => p.Key.Location);
            foreach (var item in groupingResult)
            {
                Console.WriteLine($"{item.Key.PurchaseDate}: {item.Key.Location} - ${item.Sum(i => i.Value)}");
            }
            Console.ReadLine();
        }

        private static IEnumerable<IEnumerable<string>> SplitInput(string input)
        {
            var result = input.Split("\n").Select(i => i.Split(","));
            return result;
        }

        static IEnumerable<Category> GetCategories(string input)
        {
            var categories = SplitInput(input);
            var result = categories.Select(c => new Category
            {
                Code = c.ElementAtOrDefault(0),
                Name = c.ElementAtOrDefault(1),
                IsActive = c.ElementAtOrDefault(2)
            });
            return result;
        }

        static IEnumerable<Expense> GetExpenses(string input)
        {
            var expenses = SplitInput(input);
            var result = expenses.Select(c => new Expense
            {
                Location = c.ElementAtOrDefault(0),
                PurchaseDate = DateTime.Parse(c.ElementAtOrDefault(1)),
                Product = c.ElementAtOrDefault(2),
                Value = decimal.Parse(c.ElementAtOrDefault(3)),
                Code = c.ElementAtOrDefault(4)
            });
            return result;
        }
    }
}
