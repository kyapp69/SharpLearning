﻿using System.Globalization;

namespace SharpLearning.Containers
{
    /// <summary>
    /// 
    /// </summary>
    public static class FloatingPointConversion
    {
        /// <summary>
        /// 
        /// </summary>
        public const string DefaultFormat = "R";
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly NumberFormatInfo nfi = new NumberFormatInfo();

        /// <summary>
        /// Default format for outputting double values to string.
        /// </summary> 
        public static string ToString(double value)
        {
            return value.ToString(DefaultFormat, nfi);
        }

        /// <summary>
        /// Default format for converting string values to double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToF64(string value)
        {
            return double.Parse(value, nfi);
        }
    }
}
