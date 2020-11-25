using System;
using System.Collections.Generic;
using System.Text;

namespace DataMunging.Models
{
    public class Expense
    {
        public string Location { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Product { get; set; }
        public decimal Value { get; set; }
        public string Code { get; set; }
    }
}
