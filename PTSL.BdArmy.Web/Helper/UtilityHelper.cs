using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.BdArmy.Web.Helper
{
    public static class UtilityHelper
    {
        public static class CacheKeys
        {
            public static string ConnectedSchool = "_connected_school_";
            public static string AvailableSchool = "_available_school_";
        }
        public static class CacheValidity
        {
            public static int OneMinute = 1;
            public static int TwoMinute = 2;
            public static int ThreeMinute = 3;
            public static int FiveMinute = 5;
            public static int TenMinute = 10;
            public static int ThirtyMinute = 30;
        }
    }
}
