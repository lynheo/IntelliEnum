using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using EnumsNET;

namespace Lyn.IntelliEnum
{
    public static class IntelliEnum
    {
        public static IDictionary<TEnum, string> GetDescriptionStringMap<TEnum>()
            where TEnum : struct, Enum
        {
            var dict = new Dictionary<TEnum, string>();

            foreach (var i in Enums.GetValues<TEnum>())
            {
                var attrubute = i.GetAttributes()?.Get<DescriptionAttribute>();

                if (attrubute == null)
                {
                    dict.Add(i, i.AsString());
                }
                else
                {
                    dict.Add(i, attrubute.Description);
                }
            }

            return dict;
        }

        public static List<string> GetDescriptionStrings<TEnum>()
            where TEnum : struct, Enum
        {
            var list = new List<string>();

            foreach (var i in Enums.GetValues<TEnum>())
            {
                var attrubute = i.GetAttributes()?.Get<DescriptionAttribute>();
                if (attrubute == null)
                {
                    list.Add(i.AsString());
                }
                else
                {
                    list.Add(attrubute.Description);
                }
            }

            return list;
        }

        public static TEnum GetEnumValueFromDescription<TEnum>(string description, TEnum failoverValue, bool ignoreCase = false)
           where TEnum : struct, Enum
        {
            try
            {
                return Enums.Parse<TEnum>(description, ignoreCase, EnumFormat.Description);
            }
            catch (ArgumentException)
            {
                return failoverValue;
            }
        }

        public static string GetDescription<TEnum>(TEnum value)
            where TEnum : struct, Enum
        {
            var result = Enums.AsString(value, EnumFormat.Description);
            if (result == null)
            {
                return Enums.AsString(value, EnumFormat.Name)!;
            }
            else
            {
                return Enums.AsString(value, EnumFormat.Description)!;
            }
        }
    }
}
