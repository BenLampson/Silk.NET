﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

#if NETSTANDARD2_0
using MathF = System.Math;
#endif
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using M = System.Runtime.CompilerServices.MethodImplAttribute;

namespace Silk.NET.Maths
{
    internal static class Scalar<T> where T : unmanaged, IFormattable
    {
        private const MethodImplOptions MIP = MethodImplOptions.AggressiveInlining | (MethodImplOptions) 0x0200;

        public static T One
        {
            [M(MIP)]
            get
            {
                ThrowForUnsupportedBaseType();
                if (typeof(T) == typeof(byte))
                {
                    return (T)(object)(byte)1;
                }

                if (typeof(T) == typeof(sbyte))
                {
                    return (T)(object)(sbyte)1;
                }

                if (typeof(T) == typeof(ushort))
                {
                    return (T)(object)(ushort)1;
                }

                if (typeof(T) == typeof(short))
                {
                    return (T)(object)(short)1;
                }

                if (typeof(T) == typeof(uint))
                {
                    return (T)(object)(uint)1;
                }

                if (typeof(T) == typeof(int))
                {
                    return (T)(object)1;
                }

                return _One2();
            }
        }

        public static T Two
        {
            [M(MIP)]
            get
            {
                ThrowForUnsupportedBaseType();
                if (typeof(T) == typeof(byte))
                {
                    return (T)(object)(byte)2;
                }

                if (typeof(T) == typeof(sbyte))
                {
                    return (T)(object)(sbyte)2;
                }

                if (typeof(T) == typeof(ushort))
                {
                    return (T)(object)(ushort)2;
                }

                if (typeof(T) == typeof(short))
                {
                    return (T)(object)(short)2;
                }

                if (typeof(T) == typeof(uint))
                {
                    return (T)(object)(uint)2;
                }

                if (typeof(T) == typeof(int))
                {
                    return (T)(object)2;
                }

                return _Two2();
            }
        }

        public static T PI
        {
            [M(MIP)]
            get
            {
                ThrowForNonFloatingPointType();
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)Math.PI;
            }
#endif

                if (typeof(T) == typeof(float))
                {
                    return (T)(object)(float)Math.PI;
                }

                if (typeof(T) == typeof(double))
                {
                    return (T)(object)Math.PI;
                }


                Debug.Fail("Unreachable Code");
                return default;
            }
        }

        public static T Tau
        {
            [M(MIP)]
            get
            {
                ThrowForNonFloatingPointType();

#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)TAU;
            }
#endif

                if (typeof(T) == typeof(float))
                {
                    return (T)(object)(float)TAU;
                }

                if (typeof(T) == typeof(double))
                {
                    return (T)(object)TAU;
                }

                Debug.Fail("Unreachable Code");
                return default;
            }
        }

        public static T HalfPi
        {
            [M(MIP)]
            get
            {
                ThrowForNonFloatingPointType();

#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)HALF_PI;
            }
#endif

                if (typeof(T) == typeof(float))
                {
                    return (T)(object)(float)HALF_PI;
                }

                if (typeof(T) == typeof(double))
                {
                    return (T)(object)HALF_PI;
                }

                Debug.Fail("Unreachable Code");
                return default;
            }
        }

        public static T PositiveInfinity
        {
            [M(MIP)]
            get
            {
                ThrowForNonFloatingPointType();

#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)Half.PositiveInfinity;
            }
#endif

                if (typeof(T) == typeof(float))
                {
                    return (T)(object)float.PositiveInfinity;
                }

                if (typeof(T) == typeof(double))
                {
                    return (T)(object)double.PositiveInfinity;
                }


                Debug.Fail("Unreachable Code");
                return default; // can't be reached
            }
        }

        public static T NegativeInfinity
        {
            [M(MIP)]
            get
            {
                ThrowForNonFloatingPointType();

#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)Half.NegativeInfinity;
            }
#endif
                if (typeof(T) == typeof(float))
                {
                    return (T)(object)float.NegativeInfinity;
                }

                if (typeof(T) == typeof(double))
                {
                    return (T)(object)double.NegativeInfinity;
                }


                Debug.Fail("Unreachable Code");
                return default; // can't be reached
            }
        }

        public static T Epsilon
        {
            [M(MIP)] get => default; // Scalar.Epsilon();
        }
        
        public static T MaxValue
        {
            [M(MIP)] get => default; // Scalar.MaxValue();
        }
        
        public static T MinValue
        {
            [M(MIP)] get => default; // Scalar.MinValue();
        }

        public static T NaN
        {
            [M(MIP)] get => default; // Scalar.NaN();
        }

        [M(MIP)]
        public static bool IsFinite(T value) => default; // Scalar.IsFinite(value);
        
        [M(MIP)]
        public static bool IsInfinity(T value) => default; // Scalar.IsInfinity(value);
        
        [M(MIP)]
        public static bool IsNaN(T value) => default; // Scalar.IsNaN(value);
        
        [M(MIP)]
        public static bool IsNormal(T value) => default; // Scalar.IsNormal(value);

        [M(MIP)]
        public static bool IsNegativeInfinity(T value) => default; // Scalar.IsNegativeInfinity(value);
        
        [M(MIP)]
        public static bool IsPositiveInfinity(T value) => default; // Scalar.IsPositiveInfinity(value);

        [M(MIP)]
        public static bool IsSubnormal(T value) => default; // Scalar.IsSubnormal(value);

        private const double HALF_PI = Math.PI / 2;
        private const double TAU = Math.PI * 2;
        /* Note: The following patterns are used throughout the code here and are described here
        *
        * PATTERN:
        *    if (typeof(T) == typeof(int)) { ... }
        *    else if (typeof(T) == typeof(float)) { ... }
        *    ...
        * EXPLANATION:
        *    At runtime, each instantiation of Scalar.Method will be type-specific, and each of these typeof blocks will be eliminated,
        *    as typeof(T) is a JIT constant for each instantiation. This design was chosen to eliminate any overhead from
        *    delegates and other patterns.
        * 
        * PATTERN:
        *    ...
        *    return _Method2(...);
        * EXPLANATION:
        *    In some cases JIT will refuse to inline methods that have a lot of generic blocks,
        *    because there are a lot of locals and the IL is rather large
        *    See https://github.com/dotnet/runtime/issues/38106
        *
        * !!MAKE SURE TO CHECK JIT ASM WHEN MODIFYING THIS FILE!!
        * JIT ASM CAN ALSO BE CHECKED FROM PR BY TRIGGERING A PIPELINE WITH A COMMENT "@jit-asm"
        */

        [M(MIP)]
        private static T _One2()
        {
            if (typeof(T) == typeof(ulong))
            {
                return (T)(object)(ulong)1;
            }

            if (typeof(T) == typeof(long))
            {
                return (T)(object)(long)1;
            }

#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)1;
            }
#endif

            if (typeof(T) == typeof(float))
            {
                return (T)(object)(float)1;
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)(double)1;
            }


            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        private static T _Two2()
        {
            if (typeof(T) == typeof(ulong))
            {
                return (T)(object)(ulong)2;
            }

            if (typeof(T) == typeof(long))
            {
                return (T)(object)(long)2;
            }

#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)2;
            }
#endif

            if (typeof(T) == typeof(float))
            {
                return (T)(object)(float)2;
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)(double)2;
            }


            Debug.Fail("Unreachable Code");
            return default;
        }

        internal static void ThrowInvalidType()
            => throw new NotSupportedException("This operation isn't supported for the current type.");

        [M(MIP)]
        internal static void ThrowForUnsupportedBaseType()
        {
            if (typeof(T) != typeof(byte) && typeof(T) != typeof(sbyte) && typeof(T) != typeof(ushort) &&
                typeof(T) != typeof(short) && typeof(T) != typeof(uint) && typeof(T) != typeof(int) &&
                typeof(T) != typeof(ulong) && typeof(T) != typeof(long) && 
#if HALF
                typeof(T) != typeof(Half) &&
#endif
                typeof(T) != typeof(float) && typeof(T) != typeof(double))
            {
                ThrowInvalidType();
            }
        }

        [M(MIP)]
        internal static void ThrowForNonFloatingPointType()
        {
            if (
#if HALF
                typeof(T) != typeof(Half) &&
#endif                
                typeof(T) != typeof(float) && typeof(T) != typeof(double))
            {
                ThrowInvalidType();
            }
        }

#if !NETSTANDARD2_0
        [DoesNotReturn]
#endif
        internal static void ThrowNotSupportedByUnderlying()
            => throw new NotSupportedException($"{typeof(T).FullName} not supported by the underlying type");

#if !NETSTANDARD2_0
        [DoesNotReturn]
#endif
        internal static void ThrowIndexOutOfRange() => throw new IndexOutOfRangeException();

#if !NETSTANDARD2_0
        [DoesNotReturn]
#endif
        internal static void ThrowVectorTTooSmall() => throw new NotSupportedException("Vector too small to fit");

        [M(MIP)]
        public static T SquareRoot(T value)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (T)(object)(byte)MathF.Sqrt((byte)(object)value);
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (T)(object)(sbyte)MathF.Sqrt((sbyte)(object)value);
            }

            if (typeof(T) == typeof(ushort))
            {
                return (T)(object)(ushort)MathF.Sqrt((ushort)(object)value);
            }

            if (typeof(T) == typeof(short))
            {
                return (T)(object)(short)MathF.Sqrt((short)(object)value);
            }

            if (typeof(T) == typeof(uint))
            {
                return (T)(object)(uint)MathF.Sqrt((uint)(object)value);
            }

            if (typeof(T) == typeof(int))
            {
                return (T)(object)(int)MathF.Sqrt((int)(object)value);
            }

            return _SquareRoot2(value);
        }

        [M(MIP)]
        private static T _SquareRoot2(T value)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (T)(object)(ulong)Math.Sqrt((ulong)(object)value);
            }

            if (typeof(T) == typeof(long))
            {
                return (T)(object)(long)Math.Sqrt((long)(object)value);
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)MathF.Sqrt((float)(Half)(object)value);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)MathF.Sqrt((float)(object)value);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Sqrt((double)(object)value);
            }


            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Add(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (T)(object)(byte)((byte)(object)left + (byte)(object)right);
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (T)(object)(sbyte)((sbyte)(object)left + (sbyte)(object)right);
            }

            if (typeof(T) == typeof(ushort))
            {
                return (T)(object)(ushort)((ushort)(object)left + (ushort)(object)right);
            }

            if (typeof(T) == typeof(short))
            {
                return (T)(object)(short)((short)(object)left + (short)(object)right);
            }

            if (typeof(T) == typeof(uint))
            {
                return (T)(object)((uint)(object)left + (uint)(object)right);
            }

            if (typeof(T) == typeof(int))
            {
                return (T)(object)((int)(object)left + (int)(object)right);
            }

            return _Add2(left, right);
        }

        [M(MIP)]
        private static T _Add2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (T)(object)((ulong)(object)left + (ulong)(object)right);
            }

            if (typeof(T) == typeof(long))
            {
                return (T)(object)((long)(object)left + (long)(object)right);
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)((float)(Half)(object)left + (float)(Half)(object)right);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)((float)(object)left + (float)(object)right);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)((double)(object)left + (double)(object)right);
            }

            Debug.Fail("Unreachable Code");
            return default;
        }
        
        [M(MIP)]
        public static T Mod(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (T)(object)(byte)((byte)(object)left % (byte)(object)right);
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (T)(object)(sbyte)((sbyte)(object)left % (sbyte)(object)right);
            }

            if (typeof(T) == typeof(ushort))
            {
                return (T)(object)(ushort)((ushort)(object)left % (ushort)(object)right);
            }

            if (typeof(T) == typeof(short))
            {
                return (T)(object)(short)((short)(object)left % (short)(object)right);
            }

            if (typeof(T) == typeof(uint))
            {
                return (T)(object)((uint)(object)left % (uint)(object)right);
            }

            if (typeof(T) == typeof(int))
            {
                return (T)(object)((int)(object)left % (int)(object)right);
            }

            return _Mod2(left, right);
        }

        [M(MIP)]
        private static T _Mod2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (T)(object)((ulong)(object)left % (ulong)(object)right);
            }

            if (typeof(T) == typeof(long))
            {
                return (T)(object)((long)(object)left % (long)(object)right);
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)((float)(Half)(object)left % (float)(Half)(object)right);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)((float)(object)left % (float)(object)right);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)((double)(object)left % (double)(object)right);
            }

            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Subtract(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (T)(object)(byte)((byte)(object)left - (byte)(object)right);
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (T)(object)(sbyte)((sbyte)(object)left - (sbyte)(object)right);
            }

            if (typeof(T) == typeof(ushort))
            {
                return (T)(object)(ushort)((ushort)(object)left - (ushort)(object)right);
            }

            if (typeof(T) == typeof(short))
            {
                return (T)(object)(short)((short)(object)left - (short)(object)right);
            }

            if (typeof(T) == typeof(uint))
            {
                return (T)(object)((uint)(object)left - (uint)(object)right);
            }

            if (typeof(T) == typeof(int))
            {
                return (T)(object)((int)(object)left - (int)(object)right);
            }

            return _Subtract2(left, right);
        }

        [M(MIP)]
        private static T _Subtract2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (T)(object)((ulong)(object)left - (ulong)(object)right);
            }

            if (typeof(T) == typeof(long))
            {
                return (T)(object)((long)(object)left - (long)(object)right);
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)((float)(Half)(object)left - (float)(Half)(object)right);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)((float)(object)left - (float)(object)right);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)((double)(object)left - (double)(object)right);
            }

            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Multiply(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (T)(object)(byte)((byte)(object)left * (byte)(object)right);
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (T)(object)(sbyte)((sbyte)(object)left * (sbyte)(object)right);
            }

            if (typeof(T) == typeof(ushort))
            {
                return (T)(object)(ushort)((ushort)(object)left * (ushort)(object)right);
            }

            if (typeof(T) == typeof(short))
            {
                return (T)(object)(short)((short)(object)left * (short)(object)right);
            }

            if (typeof(T) == typeof(uint))
            {
                return (T)(object)((uint)(object)left * (uint)(object)right);
            }

            if (typeof(T) == typeof(int))
            {
                return (T)(object)((int)(object)left * (int)(object)right);
            }

            return _Multiply2(left, right);
        }

        [M(MIP)]
        private static T _Multiply2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (T)(object)((ulong)(object)left * (ulong)(object)right);
            }

            if (typeof(T) == typeof(long))
            {
                return (T)(object)((long)(object)left * (long)(object)right);
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)((float)(Half)(object)left * (float)(Half)(object)right);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)((float)(object)left * (float)(object)right);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)((double)(object)left * (double)(object)right);
            }

            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Divide(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (T)(object)(byte)((byte)(object)left / (byte)(object)right);
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (T)(object)(sbyte)((sbyte)(object)left / (sbyte)(object)right);
            }

            if (typeof(T) == typeof(ushort))
            {
                return (T)(object)(ushort)((ushort)(object)left / (ushort)(object)right);
            }

            if (typeof(T) == typeof(short))
            {
                return (T)(object)(short)((short)(object)left / (short)(object)right);
            }

            if (typeof(T) == typeof(uint))
            {
                return (T)(object)((uint)(object)left / (uint)(object)right);
            }

            if (typeof(T) == typeof(int))
            {
                return (T)(object)((int)(object)left / (int)(object)right);
            }

            return _Divide2(left, right);
        }

        [M(MIP)]
        private static T _Divide2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (T)(object)((ulong)(object)left / (ulong)(object)right);
            }

            if (typeof(T) == typeof(long))
            {
                return (T)(object)((long)(object)left / (long)(object)right);
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)((float)(Half)(object)left / (float)(Half)(object)right);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)((float)(object)left / (float)(object)right);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)((double)(object)left / (double)(object)right);
            }

            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Min(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (T)(object)Math.Min((byte)(object)left, (byte)(object)right);
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (T)(object)Math.Min((sbyte)(object)left, (sbyte)(object)right);
            }

            if (typeof(T) == typeof(ushort))
            {
                return (T)(object)Math.Min((ushort)(object)left, (ushort)(object)right);
            }

            if (typeof(T) == typeof(short))
            {
                return (T)(object)Math.Min((short)(object)left, (short)(object)right);
            }

            if (typeof(T) == typeof(uint))
            {
                return (T)(object)Math.Min((uint)(object)left, (uint)(object)right);
            }

            if (typeof(T) == typeof(int))
            {
                return (T)(object)Math.Min((int)(object)left, (int)(object)right);
            }

            return _Min2(left, right);
        }

        [M(MIP)]
        private static T _Min2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (T)(object)Math.Min((ulong)(object)left, (ulong)(object)right);
            }

            if (typeof(T) == typeof(long))
            {
                return (T)(object)Math.Min((long)(object)left, (long)(object)right);
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)Math.Min((float)(Half)(object)left, (float)(Half)(object)right);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)Math.Min((float)(object)left, (float)(object)right);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Min((double)(object)left, (double)(object)right);
            }

            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Max(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (T)(object)Math.Max((byte)(object)left, (byte)(object)right);
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (T)(object)Math.Max((sbyte)(object)left, (sbyte)(object)right);
            }

            if (typeof(T) == typeof(ushort))
            {
                return (T)(object)Math.Max((ushort)(object)left, (ushort)(object)right);
            }

            if (typeof(T) == typeof(short))
            {
                return (T)(object)Math.Max((short)(object)left, (short)(object)right);
            }

            if (typeof(T) == typeof(uint))
            {
                return (T)(object)Math.Max((uint)(object)left, (uint)(object)right);
            }

            if (typeof(T) == typeof(int))
            {
                return (T)(object)Math.Max((int)(object)left, (int)(object)right);
            }

            return _Max2(left, right);
        }

        [M(MIP)]
        private static T _Max2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (T)(object)Math.Max((ulong)(object)left, (ulong)(object)right);
            }

            if (typeof(T) == typeof(long))
            {
                return (T)(object)Math.Max((long)(object)left, (long)(object)right);
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)Math.Max((float)(Half)(object)left, (float)(Half)(object)right);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)Math.Max((float)(object)left, (float)(object)right);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Max((double)(object)left, (double)(object)right);
            }

            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static bool Larger(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (byte)(object)left > (byte)(object)right;
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (sbyte)(object)left > (sbyte)(object)right;
            }

            if (typeof(T) == typeof(ushort))
            {
                return (ushort)(object)left > (ushort)(object)right;
            }

            if (typeof(T) == typeof(short))
            {
                return (short)(object)left > (short)(object)right;
            }

            if (typeof(T) == typeof(uint))
            {
                return (uint)(object)left > (uint)(object)right;
            }

            if (typeof(T) == typeof(int))
            {
                return (int)(object)left > (int)(object)right;
            }

            return _Larger2(left, right);
        }

        [M(MIP)]
        private static bool _Larger2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (ulong)(object)left > (ulong)(object)right;
            }

            if (typeof(T) == typeof(long))
            {
                return (long)(object)left > (long)(object)right;
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (Half)(object)left > (Half)(object)right;
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (float)(object)left > (float)(object)right;
            }

            if (typeof(T) == typeof(double))
            {
                return (double)(object)left > (double)(object)right;
            }


            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static bool Smaller(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (byte)(object)left < (byte)(object)right;
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (sbyte)(object)left < (sbyte)(object)right;
            }

            if (typeof(T) == typeof(ushort))
            {
                return (ushort)(object)left < (ushort)(object)right;
            }

            if (typeof(T) == typeof(short))
            {
                return (short)(object)left < (short)(object)right;
            }

            if (typeof(T) == typeof(uint))
            {
                return (uint)(object)left < (uint)(object)right;
            }

            if (typeof(T) == typeof(int))
            {
                return (int)(object)left < (int)(object)right;
            }

            return _Smaller2(left, right);
        }

        [M(MIP)]
        private static bool _Smaller2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (ulong)(object)left < (ulong)(object)right;
            }

            if (typeof(T) == typeof(long))
            {
                return (long)(object)left < (long)(object)right;
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (Half)(object)left < (Half)(object)right;
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (float)(object)left < (float)(object)right;
            }

            if (typeof(T) == typeof(double))
            {
                return (double)(object)left < (double)(object)right;
            }


            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static bool LargerEquals(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (byte)(object)left >= (byte)(object)right;
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (sbyte)(object)left >= (sbyte)(object)right;
            }

            if (typeof(T) == typeof(ushort))
            {
                return (ushort)(object)left >= (ushort)(object)right;
            }

            if (typeof(T) == typeof(short))
            {
                return (short)(object)left >= (short)(object)right;
            }

            if (typeof(T) == typeof(uint))
            {
                return (uint)(object)left >= (uint)(object)right;
            }

            if (typeof(T) == typeof(int))
            {
                return (int)(object)left >= (int)(object)right;
            }

            return _LargerEquals2(left, right);
        }

        [M(MIP)]
        private static bool _LargerEquals2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (ulong)(object)left >= (ulong)(object)right;
            }

            if (typeof(T) == typeof(long))
            {
                return (long)(object)left >= (long)(object)right;
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (Half)(object)left >= (Half)(object)right;
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (float)(object)left >= (float)(object)right;
            }

            if (typeof(T) == typeof(double))
            {
                return (double)(object)left >= (double)(object)right;
            }


            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static bool SmallerEquals(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (byte)(object)left <= (byte)(object)right;
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (sbyte)(object)left <= (sbyte)(object)right;
            }

            if (typeof(T) == typeof(ushort))
            {
                return (ushort)(object)left <= (ushort)(object)right;
            }

            if (typeof(T) == typeof(short))
            {
                return (short)(object)left <= (short)(object)right;
            }

            if (typeof(T) == typeof(uint))
            {
                return (uint)(object)left <= (uint)(object)right;
            }

            if (typeof(T) == typeof(int))
            {
                return (int)(object)left <= (int)(object)right;
            }

            return _SmallerEquals2(left, right);
        }

        [M(MIP)]
        private static bool _SmallerEquals2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (ulong)(object)left <= (ulong)(object)right;
            }

            if (typeof(T) == typeof(long))
            {
                return (long)(object)left <= (long)(object)right;
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (Half)(object)left <= (Half)(object)right;
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (float)(object)left <= (float)(object)right;
            }

            if (typeof(T) == typeof(double))
            {
                return (double)(object)left <= (double)(object)right;
            }


            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Clamp(T value, T min, T max) => Min(Max(value, min), max);

        [M(MIP)]
        public static T Negate(T value)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return (T)(object)(sbyte)-(sbyte)(object)value;
            }

            if (typeof(T) == typeof(short))
            {
                return (T)(object)(short)-(short)(object)value;
            }

            if (typeof(T) == typeof(int))
            {
                return (T)(object)-(int)(object)value;
            }

            if (typeof(T) == typeof(long))
            {
                return (T)(object)-(long)(object)value;
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)(-(float)(Half)(object)value);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)-(float)(object)value;
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)-(double)(object)value;
            }

            ThrowInvalidType();
            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static bool Equal(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (byte)(object)left == (byte)(object)right;
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (sbyte)(object)left == (sbyte)(object)right;
            }

            if (typeof(T) == typeof(ushort))
            {
                return (ushort)(object)left == (ushort)(object)right;
            }

            if (typeof(T) == typeof(short))
            {
                return (short)(object)left == (short)(object)right;
            }

            if (typeof(T) == typeof(uint))
            {
                return (uint)(object)left == (uint)(object)right;
            }

            if (typeof(T) == typeof(int))
            {
                return (int)(object)left == (int)(object)right;
            }

            return _Equal2(left, right);
        }

        [M(MIP)]
        private static bool _Equal2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (ulong)(object)left == (ulong)(object)right;
            }

            if (typeof(T) == typeof(long))
            {
                return (long)(object)left == (long)(object)right;
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (Half)(object)left == (Half)(object)right;
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (float)(object)left == (float)(object)right;
            }

            if (typeof(T) == typeof(double))
            {
                return (double)(object)left == (double)(object)right;
            }


            Debug.Fail("Unreachable Code");
            return default;
        }
        
        [M(MIP)]
        public static bool NotEqual(T left, T right)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte))
            {
                return (byte)(object)left != (byte)(object)right;
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (sbyte)(object)left != (sbyte)(object)right;
            }

            if (typeof(T) == typeof(ushort))
            {
                return (ushort)(object)left != (ushort)(object)right;
            }

            if (typeof(T) == typeof(short))
            {
                return (short)(object)left != (short)(object)right;
            }

            if (typeof(T) == typeof(uint))
            {
                return (uint)(object)left != (uint)(object)right;
            }

            if (typeof(T) == typeof(int))
            {
                return (int)(object)left != (int)(object)right;
            }

            return _NotEqual2(left, right);
        }

        [M(MIP)]
        private static bool _NotEqual2(T left, T right)
        {
            if (typeof(T) == typeof(ulong))
            {
                return (ulong)(object)left != (ulong)(object)right;
            }

            if (typeof(T) == typeof(long))
            {
                return (long)(object)left != (long)(object)right;
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (Half)(object)left != (Half)(object)right;
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (float)(object)left != (float)(object)right;
            }

            if (typeof(T) == typeof(double))
            {
                return (double)(object)left != (double)(object)right;
            }


            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T UnaryPlus(T value) => value;

        [M(MIP)]
        public static T Acos(T value)
        {
            ThrowForNonFloatingPointType();
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)MathF.Acos((float)(Half)(object)value);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)MathF.Acos((float)(object)value);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Acos((double)(object)value);
            }

            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Abs(T value)
        {
            ThrowForUnsupportedBaseType();
            if (typeof(T) == typeof(byte) || typeof(T) == typeof(ulong) || typeof(T) == typeof(ushort) || typeof(T) == typeof(uint))
            {
                return value;
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (T)(object)(sbyte)MathF.Abs((sbyte)(object)value);
            }

            if (typeof(T) == typeof(short))
            {
                return (T)(object)(short)MathF.Abs((short)(object)value);
            }

            if (typeof(T) == typeof(int))
            {
                return (T)(object)(int)MathF.Abs((int)(object)value);
            }

            return _Abs2(value);
        }

        [M(MIP)]
        private static T _Abs2(T value)
        {
            if (typeof(T) == typeof(long))
            {
                return (T)(object)Math.Abs((long)(object)value);
            }
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)MathF.Abs((float)(Half)(object)value);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)MathF.Abs((float)(object)value);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Abs((double)(object)value);
            }


            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Sin(T value)
        {
            ThrowForNonFloatingPointType();
            if (typeof(T) == typeof(float))
            {
                return (T)(object)MathF.Sin((float)(object)value);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Sin((double)(object)value);
            }

            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Sinh(T value)
        {
            ThrowForNonFloatingPointType();
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)MathF.Sinh((float)(Half)(object)value);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)MathF.Sinh((float)(object)value);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Sinh((double)(object)value);
            }


            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Tan(T value)
        {
            ThrowForNonFloatingPointType();
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)MathF.Tan((float)(Half)(object)value);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)MathF.Tan((float)(object)value);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Tan((double)(object)value);
            }


            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Asin(T value)
        {
            ThrowForNonFloatingPointType();
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)MathF.Asin((float)(Half)(object)value);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)MathF.Asin((float)(object)value);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Asin((double)(object)value);
            }


            Debug.Fail("Unreachable Code");
            return default;
        }


        [M(MIP)]
        public static T Atan(T value)
        {
            ThrowForNonFloatingPointType();
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)MathF.Atan((float)(Half)(object)value);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)MathF.Atan((float)(object)value);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Atan((double)(object)value);
            }


            Debug.Fail("Unreachable Code");
            return default;
        }

        [M(MIP)]
        public static T Atan2(T left, T right)
        {
            ThrowForNonFloatingPointType();
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)MathF.Atan2((float)(Half)(object)left, (float)(Half)(object)right);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)MathF.Atan2((float)(object)left, (float)(object)right);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Atan2((double)(object)left, (double)(object)right);
            }

            Debug.Fail("Unreachable Code");
            return default;
        }


        [M(MIP)]
        public static T Cos(T value)
        {
            ThrowForNonFloatingPointType();

            // return Sin(Add(HalfPi(), value)); isn't quite as accurate
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)MathF.Cos((float)(Half)(object)value);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)MathF.Cos((float)(object)value);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Cos((double)(object)value);
            }

            Debug.Fail("Unreachable Code");
            return default;
        }


        [M(MIP)]
        public static T Cosh(T value)
        {
            ThrowForNonFloatingPointType();
#if HALF
            if (typeof(T) == typeof(Half))
            {
                return (T)(object)(Half)MathF.Cosh((float)(Half)(object)value);
            }
#endif
            if (typeof(T) == typeof(float))
            {
                return (T)(object)MathF.Cosh((float)(object)value);
            }

            if (typeof(T) == typeof(double))
            {
                return (T)(object)Math.Cosh((double)(object)value);
            }

            Debug.Fail("Unreachable Code");
            return default;
        }
    }
}