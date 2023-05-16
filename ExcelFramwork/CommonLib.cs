using System;
using System.Collections.Generic;

namespace STIS.Framework.V4
{
	/// <summary>
	/// CommonLib�� ���� ��� �����Դϴ�.
	/// </summary>
	public class CommonLib
	{
		/// <summary>
		/// DBNull or null ���� �ִ��� ���θ� ��Ÿ���� ���� �����ɴϴ�.
		/// </summary>
		/// <param name="val">��ü�Դϴ�.</param>
		/// <returns>value�� ������ DBNull or Null �̸� true�̰�, �׷��� ������ false�Դϴ�.</returns>
		public static bool IsNull(object val)
		{
			return val == null || Convert.IsDBNull(val);
		}

		/// <summary>
		/// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public static object IsNullObject(object val)
		{
            return IsNullObject(val, string.Empty);
		}

        /// <summary>
        /// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�
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
		/// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
		/// </summary>
		/// <param name="val">��ü�Դϴ�.</param>
		/// <returns>value�� ������ DBNull or Null �̸� -1�̰�, �׷��� ������ Int32�Դϴ�.</returns>
		public static int IsNullInt32(object val)
		{
            return IsNullInt32(val, -1);
		}

        /// <summary>
        /// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
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
		/// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
		/// </summary>
		/// <param name="val">��ü�Դϴ�.</param>
		/// <returns>value�� ������ DBNull or Null �̸� -1�̰�, �׷��� ������ Int64�Դϴ�.</returns>
		public static long IsNullInt64(object val)
		{
            return IsNullInt64(val, -1);
		}

        /// <summary>
        /// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
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
		/// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
		/// </summary>
		/// <param name="val">��ü�Դϴ�.</param>
		/// <returns>value�� ������ DBNull or Null �̸� -1�̰�, �׷��� ������ double�Դϴ�.</returns>
		public static double IsNullDouble(object val)
		{
            return IsNullDouble(val, -1);
		}

        /// <summary>
        /// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
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
		/// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
		/// </summary>
		/// <param name="val">��ü�Դϴ�.</param>
		/// <returns>value�� ������ DBNull or Null �̸� -1�̰�, �׷��� ������ decimal�Դϴ�.</returns>
		public static decimal IsNullDecimal(object val)
		{
            return IsNullDecimal(val, 0);
		}

        /// <summary>
        /// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
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
		/// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
		/// </summary>
		/// <param name="val">��ü�Դϴ�.</param>
		/// <returns>value�� ������ DBNull or Null �̸� false�̰�, �׷��� ������ bool�Դϴ�.</returns>
		public static bool IsNullBool(object val)
		{
            return IsNullBool(val, false);
		}

        /// <summary>
        /// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
        /// </summary>
        /// <param name="val">��ü�Դϴ�.</param>
        /// <returns>value�� ������ DBNull or Null �̸� false�̰�, �׷��� ������ bool�Դϴ�.</returns>
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
		/// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
		/// </summary>
		/// <param name="val">��ü�Դϴ�.</param>
		/// <returns>value�� ������ DBNull or Null �̸� string.Empty�̰�, �׷��� ������ bool�Դϴ�.</returns>
		public static string IsNullString(object val)
		{
            return IsNullString(val, string.Empty);
		}

        /// <summary>
        /// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
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
		/// DBNull or null ���� �ִ��� Ȯ���Ͽ� �ش� ������ ��ȯ�Ѵ�.
		/// </summary>
		/// <param name="val">��ü�Դϴ�.</param>
        /// <returns>value�� ������ DBNull or Null �̸� '1900-01-01' �̰�, �׷��� ������ DateTime�Դϴ�.</returns>
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
		/// string.Empty ���� �ִ��� ���θ� ��Ÿ���� ���� �����ɴϴ�.
		/// </summary>
		/// <param name="val">��ü�Դϴ�.</param>
		/// <returns>value�� ������ string.Empty �̸� true�̰�, �׷��� ������ false�Դϴ�.</returns>
		public static bool IsStringEmpty(string val)
		{
			//return val == null || val.Length <= 0;
            return string.IsNullOrEmpty(val);
		}
		
		/// <summary>
		/// string.Empty ���� �ִ��� ���θ� ��Ÿ���� ���� �����ɴϴ�.
		/// </summary>
		/// <param name="val">��ü�Դϴ�.</param>
		/// <returns>value�� ������ string.Empty �̸� true�̰�, �׷��� ������ false�Դϴ�.</returns>
		public static bool IsStringEmpty(object val)
		{
			return IsStringEmpty(IsNullString(val));
		}
	}
}
