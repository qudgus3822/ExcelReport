using System;
using System.Collections.Generic;

namespace STIS.Framework.V4
{
	/// <summary>
	/// CommonLib에 대한 요약 설명입니다.
	/// </summary>
	public class CommonLib
	{
		/// <summary>
		/// DBNull or null 값이 있는지 여부를 나타내는 값을 가져옵니다.
		/// </summary>
		/// <param name="val">개체입니다.</param>
		/// <returns>value의 형식이 DBNull or Null 이면 true이고, 그렇지 않으면 false입니다.</returns>
		public static bool IsNull(object val)
		{
			return val == null || Convert.IsDBNull(val);
		}

		/// <summary>
		/// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public static object IsNullObject(object val)
		{
            return IsNullObject(val, string.Empty);
		}

        /// <summary>
        /// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다
        /// </summary>
        /// <param name="val"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static object IsNullObject(object val, object defaultValue)
        {
            if (!IsNull(val))
                return val;
            return defaultValue;
        }
 
		/// <summary>
		/// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
		/// </summary>
		/// <param name="val">개체입니다.</param>
		/// <returns>value의 형식이 DBNull or Null 이면 -1이고, 그렇지 않으면 Int32입니다.</returns>
		public static int IsNullInt32(object val)
		{
            return IsNullInt32(val, -1);
		}

        /// <summary>
        /// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int IsNullInt32(object val, int defaultValue)
        {
            if (!IsStringEmpty(val))
                return Convert.ToInt32(val);
            return defaultValue;
        }

		/// <summary>
		/// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
		/// </summary>
		/// <param name="val">개체입니다.</param>
		/// <returns>value의 형식이 DBNull or Null 이면 -1이고, 그렇지 않으면 Int64입니다.</returns>
		public static long IsNullInt64(object val)
		{
            return IsNullInt64(val, -1);
		}

        /// <summary>
        /// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long IsNullInt64(object val, long defaultValue)
        {
            if (!IsStringEmpty(val))
                return Convert.ToInt64(val);
            return defaultValue;
        }

		/// <summary>
		/// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
		/// </summary>
		/// <param name="val">개체입니다.</param>
		/// <returns>value의 형식이 DBNull or Null 이면 -1이고, 그렇지 않으면 double입니다.</returns>
		public static double IsNullDouble(object val)
		{
            return IsNullDouble(val, -1);
		}

        /// <summary>
        /// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double IsNullDouble(object val, double defaultValue)
        {
            if (!IsStringEmpty(val))
                return Convert.ToDouble(val);
            return defaultValue;
        }
		
		/// <summary>
		/// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
		/// </summary>
		/// <param name="val">개체입니다.</param>
		/// <returns>value의 형식이 DBNull or Null 이면 -1이고, 그렇지 않으면 decimal입니다.</returns>
		public static decimal IsNullDecimal(object val)
		{
            return IsNullDecimal(val, 0);
		}

        /// <summary>
        /// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal IsNullDecimal(object val, decimal defaultValue)
        {
            if (!IsStringEmpty(val))
                return Convert.ToDecimal(val);
            return defaultValue;
        }

		/// <summary>
		/// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
		/// </summary>
		/// <param name="val">개체입니다.</param>
		/// <returns>value의 형식이 DBNull or Null 이면 false이고, 그렇지 않으면 bool입니다.</returns>
		public static bool IsNullBool(object val)
		{
            return IsNullBool(val, false);
		}

        /// <summary>
        /// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
        /// </summary>
        /// <param name="val">개체입니다.</param>
        /// <returns>value의 형식이 DBNull or Null 이면 false이고, 그렇지 않으면 bool입니다.</returns>
        public static bool IsNullBool(object val, bool defaultValue)
        {
            if (!IsStringEmpty(val))
            {
                if (val.ToString().Equals("Y", StringComparison.OrdinalIgnoreCase)) return true;
                if (val.ToString().Equals("N", StringComparison.OrdinalIgnoreCase)) return false;

                return Convert.ToBoolean(val);
            }

            return defaultValue;
        }

		/// <summary>
		/// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
		/// </summary>
		/// <param name="val">개체입니다.</param>
		/// <returns>value의 형식이 DBNull or Null 이면 string.Empty이고, 그렇지 않으면 bool입니다.</returns>
		public static string IsNullString(object val)
		{
            return IsNullString(val, string.Empty);
		}

        /// <summary>
        /// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string IsNullString(object val, object defaultValue)
        {
            return IsNullString(val, defaultValue, "{0}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <param name="defaultValue"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string IsNullString(object val, object defaultValue, string format)
        {
            if (!IsNull(val))
                return string.Format(format, val);
            return string.Format(format, defaultValue);
        }
        

		/// <summary>
		/// DBNull or null 값이 있는지 확인하여 해당 형으로 변환한다.
		/// </summary>
		/// <param name="val">개체입니다.</param>
        /// <returns>value의 형식이 DBNull or Null 이면 '1900-01-01' 이고, 그렇지 않으면 DateTime입니다.</returns>
		public static DateTime IsNullDateTime(object val)
		{
            return IsNullDateTime(val, Convert.ToDateTime("1900-01-01"));
		}

        public static DateTime IsNullDateTime(object val, DateTime defaultValue)
        {
            if (!IsStringEmpty(val))
                return Convert.ToDateTime(val);
            return defaultValue;
        }

		/// <summary>
		/// string.Empty 값이 있는지 여부를 나타내는 값을 가져옵니다.
		/// </summary>
		/// <param name="val">개체입니다.</param>
		/// <returns>value의 형식이 string.Empty 이면 true이고, 그렇지 않으면 false입니다.</returns>
		public static bool IsStringEmpty(string val)
		{
			//return val == null || val.Length <= 0;
            return string.IsNullOrEmpty(val);
		}
		
		/// <summary>
		/// string.Empty 값이 있는지 여부를 나타내는 값을 가져옵니다.
		/// </summary>
		/// <param name="val">개체입니다.</param>
		/// <returns>value의 형식이 string.Empty 이면 true이고, 그렇지 않으면 false입니다.</returns>
		public static bool IsStringEmpty(object val)
		{
			return IsStringEmpty(IsNullString(val));
		}
	}
}
