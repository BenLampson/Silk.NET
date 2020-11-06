// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Globalization;
using static Silk.NET.Maths.ShortScalarHelper;
using static Silk.NET.Maths.Scalar;

namespace Silk.NET.Maths
{
    [Serializable]
    public readonly struct Matrix3x4<T> : IEquatable<Matrix3x4<T>>, IFormattable where T : unmanaged, IFormattable
    {
        public static Matrix3x4<T> Zero => default;
        public Vector4<T> Row0 { get; }
        public Vector4<T> Row1 { get; }
        public Vector4<T> Row2 { get; }

        public T M11 => Row0.X;
        public T M12 => Row0.Y;
        public T M13 => Row0.Z;
        public T M14 => Row0.W;

        public T M21 => Row1.X;
        public T M22 => Row1.Y;
        public T M23 => Row1.Z;
        public T M24 => Row1.W;

        public T M31 => Row2.X;
        public T M32 => Row2.Y;
        public T M33 => Row2.Z;
        public T M34 => Row2.W;

        public Matrix3x4(Vector4<T> row0, Vector4<T> row1, Vector4<T> row2) => throw new NotImplementedException();

        public Matrix3x4(T m11, T m12, T m13, T m14, T m21, T m22, T m23, T m24, T m31, T m32, T m33, T m34)
            => throw new NotImplementedException();

        public Vector3<T> Column0 => throw new NotImplementedException();

        public Vector3<T> Column1 => throw new NotImplementedException();

        public Vector3<T> Column2 => throw new NotImplementedException();

        public Vector3<T> Column3 => throw new NotImplementedException();

        public Vector3<T> Diagonal
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public T Trace => throw new NotImplementedException();

        public T this[int rowIndex, int columnIndex]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Invert() => throw new NotImplementedException();

        public static void CreateFromAxisAngle(Vector3<T> axis, T angle, out Matrix3x4<T> result)
            => throw new NotImplementedException();

        public static Matrix3x4<T> CreateFromAxisAngle(Vector3<T> axis, T angle) => throw new NotImplementedException();

        public static void CreateFromQuaternion(ref Quaternion<T> q, out Matrix3x4<T> result)
            => throw new NotImplementedException();

        public static Matrix3x4<T> CreateFromQuaternion(Quaternion<T> q) => throw new NotImplementedException();

        public static void CreateRotationX(T angle, out Matrix3x4<T> result) => throw new NotImplementedException();

        public static Matrix3x4<T> CreateRotationX(T angle) => throw new NotImplementedException();

        public static void CreateRotationY(T angle, out Matrix3x4<T> result) => throw new NotImplementedException();

        public static Matrix3x4<T> CreateRotationY(T angle) => throw new NotImplementedException();

        public static void CreateRotationZ(T angle, out Matrix3x4<T> result) => throw new NotImplementedException();

        public static Matrix3x4<T> CreateRotationZ(T angle) => throw new NotImplementedException();

        public static void CreateTranslation(T x, T y, T z, out Matrix3x4<T> result)
            => throw new NotImplementedException();

        public static void CreateTranslation(ref Vector3<T> vector, out Matrix3x4<T> result)
            => throw new NotImplementedException();

        public static Matrix3x4<T> CreateTranslation(T x, T y, T z) => throw new NotImplementedException();

        public static Matrix3x4<T> CreateTranslation(Vector3<T> vector) => throw new NotImplementedException();

        public static Matrix3x4<T> CreateScale(T scale) => throw new NotImplementedException();

        public static Matrix3x4<T> CreateScale(Vector3<T> scale) => throw new NotImplementedException();

        public static Matrix3x4<T> CreateScale(T x, T y, T z) => throw new NotImplementedException();

        public static Matrix3x3<T> Multiply(Matrix3x4<T> left, Matrix4x3<T> right)
            => throw new NotImplementedException();

        public static void Multiply(ref Matrix3x4<T> left, ref Matrix4x3<T> right, out Matrix3x3<T> result)
            => throw new NotImplementedException();

        public static Matrix3x4<T> Multiply(Matrix3x4<T> left, Matrix3x4<T> right)
            => throw new NotImplementedException();

        public static void Multiply(ref Matrix3x4<T> left, ref Matrix3x4<T> right, out Matrix3x4<T> result)
            => throw new NotImplementedException();

        public static Matrix3x4<T> Multiply(Matrix3x4<T> left, T right) => throw new NotImplementedException();

        public static void Multiply(ref Matrix3x4<T> left, T right, out Matrix3x4<T> result)
            => throw new NotImplementedException();

        public static Matrix3x4<T> Add(Matrix3x4<T> left, Matrix3x4<T> right) => throw new NotImplementedException();

        public static void Add(ref Matrix3x4<T> left, ref Matrix3x4<T> right, out Matrix3x4<T> result)
            => throw new NotImplementedException();

        public static Matrix3x4<T> Subtract(Matrix3x4<T> left, Matrix3x4<T> right)
            => throw new NotImplementedException();

        public static void Subtract(ref Matrix3x4<T> left, ref Matrix3x4<T> right, out Matrix3x4<T> result)
            => throw new NotImplementedException();

        public static Matrix3x4<T> Invert(Matrix3x4<T> mat) => throw new NotImplementedException();

        public static void Invert(ref Matrix3x4<T> mat, out Matrix3x4<T> result) => throw new NotImplementedException();

        public static Matrix4x3<T> Transpose(Matrix3x4<T> mat) => throw new NotImplementedException();

        public static void Transpose(ref Matrix3x4<T> mat, out Matrix4x3<T> result)
            => throw new NotImplementedException();

        public static Matrix3x3<T> operator *(Matrix3x4<T> left, Matrix4x3<T> right)
            => throw new NotImplementedException();

        public static Matrix3x4<T> operator *(Matrix3x4<T> left, Matrix3x4<T> right)
            => throw new NotImplementedException();

        public static Matrix3x4<T> operator *(Matrix3x4<T> left, T right) => throw new NotImplementedException();

        public static Matrix3x4<T> operator +(Matrix3x4<T> left, Matrix3x4<T> right)
            => throw new NotImplementedException();

        public static Matrix3x4<T> operator -(Matrix3x4<T> left, Matrix3x4<T> right)
            => throw new NotImplementedException();

        public static bool operator ==(Matrix3x4<T> left, Matrix3x4<T> right) => throw new NotImplementedException();

        public static bool operator !=(Matrix3x4<T> left, Matrix3x4<T> right) => throw new NotImplementedException();


        public override string ToString() => ToString("G");

        public string ToString(string? format) => ToString(format, CultureInfo.CurrentCulture);

        public string ToString(string? format, IFormatProvider? formatProvider) => throw new NotImplementedException();

        public override int GetHashCode() => throw new NotImplementedException();

        public override bool Equals(object? obj) => throw new NotImplementedException();

        public bool Equals(Matrix3x4<T> other) => throw new NotImplementedException();
    }
}