using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PTSL.BdArmy.Web
{
    public static class EnumHelper
    {
        public static string GetEnumDisplayName1(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Name;
            else
                return value.ToString();
        }

        public static string GetEnumDisplayName(this Enum enumValue)
        { 
            var name = enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()
              .GetCustomAttribute<DisplayAttribute>()
              ?.GetName();
            return name;
        }
    }
}

//for call any of controller
//int value = 3;
//var Status = Helper.GetEnumDisplayName((NatureOfPromotion)3);