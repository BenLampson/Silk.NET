﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Silk.NET.Maths
{
    internal static class Helper
    {
        internal static readonly string ListSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
        public const MethodImplOptions MaxOpt = MethodImplOptions.AggressiveInlining | (MethodImplOptions) 512;
        public static void ThrowArgumentOutOfRange(string pName) => throw new ArgumentOutOfRangeException(pName);

        public static void AssertInRange(string pName, int pValue, int min, int max)
        {
            if (pValue > max || pValue < min)
            {
                ThrowArgumentOutOfRange(pName);
            }
        }
    }
}
