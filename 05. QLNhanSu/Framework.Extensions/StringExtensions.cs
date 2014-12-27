﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Framework.Extensions
{
    public static class StringExtensions
    {

        public static string TrimIfOver(this string s, int maxLen)
        {
            return s.IsNotNullOrEmpty() && s.Length > maxLen ? s.Substring(0, maxLen) + "..." : s;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static string JoinEmbeddedLength(this string[] values)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].IsNotNullOrEmpty())
                {
                    builder.Append(values[i].Length).Append("|").Append(values[i]);
                }
                else
                {
                    builder.Append("0").Append("|");
                }
            }
            return builder.ToString();
        }

        public static string[] SplitEmbeddedLength(this string str)
        {
            int num2;
            List<string> list = new List<string>();
            int index = str.IndexOf('|');
            if ((index > 0) && int.TryParse(str.Substring(0, index), out num2))
            {
                while ((index > 0) && (num2 >= 0))
                {
                    list.Add(str.Substring(index + 1, num2));
                    int startIndex = (index + 1) + num2;
                    index = str.IndexOf('|', startIndex);
                    if ((index <= 0) || (index <= startIndex))
                    {
                        break;
                    }
                    if (!int.TryParse(str.Substring(startIndex, index - startIndex), out num2))
                    {
                        num2 = -1;
                    }
                }
            }
            else
            {
                return null;
            }
            return list.ToArray();
        }

        /// <summary>
        /// Deserialize string to object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string s)
        {
            T result = JsonConvert.DeserializeObject<T>(s);
            return result;
        }
    }
}
