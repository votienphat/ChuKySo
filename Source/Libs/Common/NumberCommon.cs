using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class NumberCommon
    {
        #region Extension

        /// <summary>
        /// Nếu số bị null thì trả về 0
        /// </summary>
        /// <param name="number"> </param>
        /// <returns></returns>
        public static long Empty(this long? number)
        {
            return number.HasValue ? number.Value : 0;
        }

        /// <summary>
        /// Nếu số bị null thì trả về 0
        /// </summary>
        /// <param name="number"> </param>
        /// <returns></returns>
        public static int Empty(this int? number)
        {
            return number.HasValue ? number.Value : 0;
        }

        /// <summary>
        /// Nếu số bị null thì trả về 0
        /// </summary>
        /// <param name="number"> </param>
        /// <returns></returns>
        public static decimal Empty(this decimal? number)
        {
            return number.HasValue ? number.Value : 0;
        }

        /// <summary>
        /// Nếu số bị null thì trả về 0
        /// </summary>
        /// <param name="number"> </param>
        /// <returns></returns>
        public static double Empty(this double? number)
        {
            return number.HasValue ? number.Value : 0;
        }

        #endregion
        
        /// <summary>
        /// Convert from boolean to int [1 or 0]
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int BooleanToInt(bool? value=null)
        {
            return value == true ? 1 : 0;
        }
    }
}
