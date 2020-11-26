using SmallWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld.Service
{
    public class SmallWorldService
    {
        private readonly IList<Point> points;

        public SmallWorldService(IList<Point> points)
        {
            this.points = points;
        }

        public void ShowResult()
        {
            for (int i = 0; i < points.Count; i++)
            {
                var currentPoint = points.ElementAt(i);
                var pointsToEvaluate = points.Where(p => !p.Equals(currentPoint));
                var distanceAgainstAllPoints = pointsToEvaluate.Select((pte, index) => new
                {
                    Index = points.IndexOf(pte) + 1,
                    Distance = GetDistance(currentPoint, pte),
                    Point = pte
                }).OrderBy(d => d.Distance).Take(3);
                Console.WriteLine($"{i + 1} {string.Join(",", distanceAgainstAllPoints.Select(daap => daap.Index))}");
            }
        }

        private double GetDistance(Point point1, Point point2)
        {
            var distanceX = point1.X - point2.X;
            var distanceY = point1.Y - point2.Y;
            var distanceMultiplied = (distanceX * distanceX) + (distanceY * distanceY);
            var operationResult = Math.Round(Math.Sqrt(distanceMultiplied), 3, MidpointRounding.AwayFromZero);
            return operationResult;
        }
    }
}
