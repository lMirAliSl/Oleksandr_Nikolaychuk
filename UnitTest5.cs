using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests{
    public class Task_5{
        public static string SortByNames(string list){
            string[] temp = list.Split(new char[] { ';', ':' });
            string[] arr_names = new string[temp.Length / 2];
            for (int i = 0; i < temp.Length / 2; i++){
                arr_names[i] = "(" + temp[i * 2 + 1].ToUpper() + ", " + temp[i * 2].ToUpper() + ")";
            }
            Array.Sort(arr_names);
            string result = "";
            for (int i = 0; i < arr_names.Length; i++){
                result += arr_names[i];
            }
            return result;
        }

        [Test]
        public void test_1(){
            string incoming = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            string expected = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";

            incoming = SortByNames(incoming);

            Assert.AreEqual(expected, incoming);
        }
        [Test]
        public void test_2(){
            string incoming = "Nate:Shevchenko;Ben:Shevchenko;Fake:Shevchenko;Andriy:Pinckman;Ziyan:Pinckman;Britney:Pinckman";
            string expected = "(PINCKMAN, ANDRIY)(PINCKMAN, BRITNEY)(PINCKMAN, ZIYAN)(SHEVCHENKO, BEN)(SHEVCHENKO, FAKE)(SHEVCHENKO, NATE)";

            incoming = SortByNames(incoming);

            Assert.AreEqual(expected, incoming);
        }
    }
}
