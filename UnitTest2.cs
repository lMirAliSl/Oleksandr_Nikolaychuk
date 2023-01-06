using NUnit.Framework;
using System.Collections.Generic;

namespace Tests{
    public class Task_2{
        public static string FirstNoneRepeatingLetter(string enter){
            char[] arr = enter.ToCharArray();
            for (int i = 0; i < arr.Length; i++){
                if (!arr[i].Equals(' ') &&
                       enter.IndexOf(arr[i]) == enter.LastIndexOf(enter[i]) &&
                     (enter.LastIndexOf(enter[i].ToString().ToUpper()) == -1 || enter.LastIndexOf(enter[i].ToString().ToLower()) == -1)){
                    return enter[i].ToString();
                }
            }
            return "No letters";
        }

        [Test]
        public void test_1(){
            string incoming = "I do not believe in love";
            string letter = "d";

            incoming = FirstNoneRepeatingLetter((incoming));

            Assert.AreEqual(letter, incoming);
        }
        [Test]
        public void test_2(){
            string incoming = "somebody Can bE anYBody";
            string letter = "s";

            incoming = FirstNoneRepeatingLetter((incoming));

            Assert.AreEqual(letter, incoming);
        }
    }
}