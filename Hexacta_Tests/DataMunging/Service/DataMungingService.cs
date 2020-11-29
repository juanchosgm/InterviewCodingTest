using DataMunging.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataMunging.Service
{
    public class DataMungingService
    {
        public IEnumerable<Category> GetCategories(string input)
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

        public IEnumerable<Expense> GetExpenses(string input)
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

        public IEnumerable<string> GetResult(IEnumerable<Expense> expenses, IEnumerable<Category> categories)
        {
            categories = categories.Where(c => c.IsActive == "Y");
            var groupingResult = expenses
                .Join(categories, e => e.Code, c => c.Code, (e, c) => e)
                .GroupBy(e => new { e.PurchaseDate, e.Location })
                .OrderBy(p => p.Key.PurchaseDate).ThenBy(p => p.Key.Location);
            var result = groupingResult.Select(gr => $"{gr.Key.PurchaseDate}: {gr.Key.Location} - ${gr.Sum(i => i.Value)}");
            return result;
        }

        private IEnumerable<IEnumerable<string>> SplitInput(string input)
        {
            var result = input.Split("\n").Select(i => i.Split(","));
            return result;
        }   
    }
}
