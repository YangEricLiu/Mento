using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Utility
{
    public static class Generate
    {
        private static Random RandomProvider = new Random();
        private static DateTime BaseDate = new DateTime(1970, 1, 1);

        public static T Random<T>()
        {
            object result = default(T);

            var t = typeof(T);

            if (t == typeof(int) || t == typeof(int?))
            {
                result = RandomProvider.Next();
            }
            if (t == typeof(long) || t == typeof(long?))
            {
                result = (long)RandomProvider.Next();
            }
            if (t == typeof(double) || t == typeof(double?))
            {
                result = RandomProvider.NextDouble();
            }
            if (t == typeof(decimal) || t == typeof(decimal?))
            {
                result = Convert.ToDecimal(RandomProvider.NextDouble());
            }
            if (t == typeof(string))
            {
                result = GenerateRandomString(5);
            }
            if (t == typeof(bool) || t == typeof(bool?))
            {
                result = RandomProvider.Next(0, 2) == 1 ? true : false;
            }
            if (t == typeof(DateTime) || t == typeof(DateTime?))
            {
                result = BaseDate.AddSeconds((double)RandomProvider.Next());
            }
            if (t.IsEnum)
            {
                T[] array = Enum.GetValues(t) as T[];
                result = array[RandomProvider.Next(0, array.Length - 1)];
            }

            return (T)result;
        }

        private static string GenerateRandomString(int stringLength)
        {
            int rep = 0;
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            //Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < stringLength; i++)
            {
                char ch;
                int num = RandomProvider.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }
    }
}
