using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Test
{
    public static class ExtensionFuncs
    {
        public static bool IsGreaterThen(this int i, int value)
        {
            return i > value;
        }

        public static string ToFormattedPrice(this decimal amount)
        {
            return amount.ToString("#,##0.00");
        }

        public static string ToFormattedDate(this DateTime dateTime)
        {
            return dateTime.ToLongDateString();
        }

        public static string GetFirstThreeCharacters(this string str)
        {
            if (str.Length < 3)
            {
                return str;
            }
            else
            {
                return str.Substring(0, 3);
            }
        }
    }

    public static class ExtensionBool
    {
        public static bool IsGreaterThen(int i, int value)
        {
            return i > value;
        }
  
    }

    public class ExtensionTest
    {
        [Test]
        public void Test_Extension_greaterthen()
        {
            int age = 10;
            bool result = age.IsGreaterThen(20);
            bool result2 = ExtensionBool.IsGreaterThen(20, age);
            Assert.Equals(true, result);
        }

        [Test]
        public void Test_Extension_string()
        {
            string name = "Etem";
            string result = name.GetFirstThreeCharacters();
            Assert.Equals(result, "Ete");
        }

        [Test]
        public void Test_Extension_date()
        {
            DateTime dateTime = DateTime.Now;
            string result = dateTime.ToFormattedDate();
            Assert.Equals(result, "DD.MM.YYYY");
        }
    }
}
