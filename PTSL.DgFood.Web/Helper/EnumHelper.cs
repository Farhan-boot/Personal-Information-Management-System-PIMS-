using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PTSL.DgFood.Web
{
    public static class EnumHelper
    {
        public static string GetEnumDisplayName(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Name;
            else
                return value.ToString();
        }

        //public static string GetEnumDisplayName(this Enum enumValue)
        //{ 
        //    var name = enumValue.GetType()
        //      .GetMember(enumValue.ToString())
        //      .First()
        //      .GetCustomAttribute<DisplayAttribute>()
        //      ?.GetName();
        //    return name;
        //}

        public static IEnumerable<DropdownVM> GetEnumDropdowns<T>() where T : Enum
        {
            var list = Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(x => new DropdownVM
                {
                    Id =  (int)(object)x,
                    Name = x.GetEnumDisplayName(),
                });

            return list;
        }
    }
}

//for call any of controller
//int value = 3;
//var Status = Helper.GetEnumDisplayName((NatureOfPromotion)3);