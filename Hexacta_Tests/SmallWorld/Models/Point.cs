using System;
using System.Diagnostics.CodeAnalysis;

namespace SmallWorld.Models
{
    public struct Point : IEquatable<Point>
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public bool Equals([AllowNull] Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
