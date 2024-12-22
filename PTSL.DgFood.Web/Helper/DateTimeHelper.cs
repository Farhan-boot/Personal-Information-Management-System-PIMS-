using System;

namespace PTSL.DgFood.Web.Helper
{
	public static class DateTimeHelper
	{
		public static string ToNullableUIDateString(this DateTime? dateTime)
		{
			if (dateTime is DateTime) return ((DateTime)dateTime).ToString("yyyy-MM-dd");
			return string.Empty;
		}

		public static string ToUIDateString(this DateTime dateTime)
		{
			return dateTime.ToString("yyyy-MM-dd");
		}
	}
}