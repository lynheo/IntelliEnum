using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;

namespace Lyn.IntelliEnum
{
    public static class IntelliEnum
    {
        public static IDictionary<TEnum, string> GetDescriptionStringMap<TEnum>()
            where TEnum : Enum
        {
            var enumType = typeof(TEnum);
            var dict = new Dictionary<TEnum, string>();

            foreach (var i in Enum.GetValues(enumType).Cast<TEnum>())
            {
                var memberInfo = enumType.GetMember(i.ToString()).FirstOrDefault();
                var attrubute = memberInfo?.GetCustomAttribute<DescriptionAttribute>();

                if (attrubute == null)
                {
                    dict.Add(i, i.ToString());
                }
                else
                {
                    dict.Add(i, attrubute.Description);
                }
            }

            return dict;
        }

        public static List<string> GetDescriptionStrings<TEnum>()
            where TEnum : Enum
        {
            var enumType = typeof(TEnum);
            var list = new List<string>();

            foreach (var i in Enum.GetValues(enumType).Cast<TEnum>())
            {
                var memberInfo = enumType.GetMember(i.ToString()).FirstOrDefault();
                var attrubute = memberInfo?.GetCustomAttribute<DescriptionAttribute>();

                if (attrubute == null)
                {
                    list.Add(i.ToString());
                }
                else
                {
                    list.Add(attrubute.Description);
                }
            }

            return list;
        }

        public static TEnum GetEnumValueFromDescription<TEnum>(string description, TEnum failoverValue)
           where TEnum : Enum
        {
            var enumType = typeof(TEnum);

            foreach (var i in Enum.GetValues(enumType).Cast<TEnum>())
            {
                var memberInfo = enumType.GetMember(i.ToString()).FirstOrDefault();
                var attrubute = memberInfo?.GetCustomAttribute<DescriptionAttribute>();

                if (attrubute == null)
                {
                    if (description == i.ToString()) return i;
                }
                else
                {
                    if (description == attrubute.Description) return i;
                }
            }

            return failoverValue;
        }
    }
}
