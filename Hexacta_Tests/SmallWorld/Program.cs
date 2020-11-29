using SmallWorld.Models;
using SmallWorld.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallWorld
{
    class Program
    {
        static IList<Point> Points
        {
            get
            {
                return new List<Point>
                {
                    new Point(0d,0d),
                    new Point(10.1d, -10.1d),
                    new Point(-12.2, 12.2),
                    new Point(38.3, 38.3),
                    new Point(79.99, 179.99)
                };
            }
        }

        static void Main(string[] args)
        {
            var service = new SmallWorldService(Points);
            foreach (var item in service.GetResult())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
