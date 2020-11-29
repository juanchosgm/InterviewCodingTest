using DataMunging.Service;
using System;

namespace DataMunging
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new DataMungingService();
            var categories = service.GetCategories("CFE,Coffee,Y\nFD,Food,Y\nPRS,Personal,N");
            var expenses = service.GetExpenses("Starbucks,3/10/2018,Iced Americano,4.28,CFE\nStarbucks,3/10/2018,Nitro Cold Brew,3.17,CFE\nStarbucks,3/10/2018,Souvineer Mug,8.19,PRS\nStarbucks,3/11/2018,Nitro Cold Brew,3.17,CFE\nHigh Point Market,3/11/2018,Iced Americano,2.75,CFE\nHigh Point Market,3/11/2018,Pastry,2.00,FD\nHigh Point Market,3/11/2018,Gift Card,10.00,PRS");
            foreach (var item in service.GetResult(expenses, categories))
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
