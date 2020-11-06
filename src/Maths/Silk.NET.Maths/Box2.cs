// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using static Silk.NET.Maths.Scalar;

namespace Silk.NET.Maths
{
    public readonly struct Box2<T> : IEquatable<Box2<T>>, IFormattable where T : unmanaged, IFormattable
    {
        public Vector2<T> Min { get; }
        public Vector2<T> Max { get; }

        public Box2(Vector2<T> min, Vector2<T> max)
        {
            (Min, Max) = (min, max);
            
#if !NETSTANDARD2_0
            if (!IsNormal(min.X))
                ThrowArgumentOutOfRangeException("min.X", "All values have to be normal");
            if (!IsNormal(min.Y))
                ThrowArgumentOutOfRangeException("min.Y", "All values have to be normal");
            if (!IsNormal(max.X))
                ThrowArgumentOutOfRangeException("max.X", "All values have to be normal");
            if (!IsNormal(max.Y))
                ThrowArgumentOutOfRangeException("max.Y", "All values have to be normal");
#endif
            
            if (Smaller(Max.X, Min.X) || Smaller(Max.Y, Min.Y))
            {
                ThrowArgumentOutOfRangeException(nameof(Max), "Max has to be larger then Min");
            }
        }

#if !NETSTANDARD2_0
        [DoesNotReturn]
#endif
        private static void ThrowArgumentOutOfRangeException(string name, string message)
        {
            throw new ArgumentOutOfRangeException(name, message);
        }

        public Box2(T minX, T minY, T maxX, T maxY) : this(new Vector2<T>(minX, minY), new Vector2<T>(maxX, maxY)) { }

        public Vector2<T> Size => Max - Min;

        public Vector2<T> HalfSize => Size / Scalar<T>.Two;

        public Vector2<T> Center => Min + HalfSize;

        public Box2<T> WithMin(Vector2<T> min) => new Box2<T>(min, Max);

        public Box2<T> WithMax(Vector2<T> max) => new Box2<T>(Min, max);

        public bool Contains(Vector2<T> point, bool boundaryInclusive = false)
            => boundaryInclusive
                ? LargerEquals(point.X, Min.X) && LargerEquals(point.Y, Min.Y) && SmallerEquals(point.X, Max.X) &&
                  SmallerEquals(point.Y, Max.Y)
                : Larger(point.X, Min.X) && Larger(point.Y, Min.Y) && Smaller(point.X, Max.X) && Smaller
                    (point.Y, Max.Y);

        public bool Contains(Box2<T> other, bool boundaryInclusive = false)
            => boundaryInclusive
                ? LargerEquals(other.Min.X, Min.X) && LargerEquals(other.Min.Y, Min.Y) && SmallerEquals
                    (other.Max.X, Max.X) && SmallerEquals(other.Max.Y, Max.Y)
                : Larger(other.Min.X, Min.X) && Larger(other.Min.Y, Min.Y) && Smaller(other.Max.X, Max.X) && Smaller
                    (other.Max.Y, Max.Y);

        public T DistanceToNearestEdge(Vector2<T> point)
            => Vector2<T>.ComponentMax(Vector2<T>.Zero, Vector2<T>.ComponentMax(Min - point, point - Max)).Length;

        public Box2<T> Translate(Vector2<T> distance) => new Box2<T>(Min + distance, Max + distance);

        public Box2<T> Scale(Vector2<T> scale, Vector2<T> anchor)
            => new Box2<T>(anchor + (Min - anchor) * scale, anchor + (Max - anchor) * scale);

        public Box2<T> Inflate(Vector2<T> point)
            => new Box2<T>(Vector2<T>.ComponentMin(point, Min), Vector2<T>.ComponentMin(point, Max));

        public static bool operator ==(Box2<T> left, Box2<T> right) => left.Min == right.Min && left.Max == right.Max;

        public static bool operator !=(Box2<T> left, Box2<T> right) => !(left == right);

        public bool Equals(Box2<T> other) => this == other;

        public override bool Equals(object? obj) => obj is Box2<T> box && Equals(box);

        public override int GetHashCode() => HashCode.Combine(Min, Max);

        public override string ToString() => ToString("G");

        public string ToString(string? format) => ToString(format, CultureInfo.CurrentCulture);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var sb = new StringBuilder();
            sb.Append(Min.ToString(format, formatProvider));
            sb.Append(" -> ");
            sb.Append(Max.ToString(format, formatProvider));
            return sb.ToString();
        }
    }
}