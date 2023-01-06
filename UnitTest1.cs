using NuGet.Frameworks;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests{
    public class Task{
        public static List<object> GetIntegersFromList(List<object> list){
            for (int i = 0; i < list.Count; i++){
                if (int.TryParse(list[i].ToString(), out var x)){
                    if (!list[i].Equals(x)){
                        list.RemoveAt(i);
                        i--;
                    }
                }
                else{
                    list.RemoveAt(i);
                    i--;
                }
            }
            return list;
        }

        [Test]
        public void test_1(){
            List<object> listIn = new List<object> { 1, 2, 'a', '1', 2 };
            List<object> listout = new List<object> { 1, 2, 2 };

            listIn = GetIntegersFromList(listIn);

            Assert.AreEqual(listout, listIn);
        }
        [Test]
        public void test_2(){
            List<object> listIn = new List<object>() { "hghjf", 123123, "asdaad" };
            List<object> listout = new List<object>() { 123123 };

            listIn = GetIntegersFromList(listIn);

            Assert.AreEqual(listout, listIn);
        }
    }
}