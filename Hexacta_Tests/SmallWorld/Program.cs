using SmallWorld.Models;
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
            for (int i = 0; i < Points.Count; i++)
            {
                var currentPoint = Points.ElementAt(i);
                var pointsToEvaluate = Points.Where(p => !p.Equals(currentPoint));
                var distanceAgainstAllPoints = pointsToEvaluate.Select((pte, index) => new
                {
                    Index = Points.IndexOf(pte) + 1,
                    Distance = GetDistance(currentPoint, pte),
                    Point = pte
                }).OrderBy(d => d.Distance).Take(3);
                Console.WriteLine($"{i + 1} {string.Join(",", distanceAgainstAllPoints.Select(daap => daap.Index))}");
            }
            Console.ReadLine();
        }

        static double GetDistance(Point point1, Point point2)
        {
            var distanceX = point1.X - point2.X;
            var distanceY = point1.Y - point2.Y;
            var distanceMultiplied = (distanceX * distanceX) + (distanceY * distanceY);
            var operationResult = Math.Round(Math.Sqrt(distanceMultiplied), 3, MidpointRounding.AwayFromZero);
            return operationResult;
        }
    }
}
