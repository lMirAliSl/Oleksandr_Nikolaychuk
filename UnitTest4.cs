using NUnit.Framework;
using System.Collections.Generic;

namespace Tests{
    public class Task_4{
        public static int counter_pairs(int[] arr, int target){
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++){
                for (int j = i + 1; j < arr.Length; j++){
                    if (arr[i] + arr[j] == target){
                        count++;
                    }
                }
            }
            return count;
        }

        [Test]
        public void test_1(){
            int[] inputList = { 1, 3, 6, 2, 2, 0, 4, 5 };
            int target = 5;
            int aim = 4;

            int pairs = counter_pairs(inputList, target);

            Assert.AreEqual(aim, pairs);
        }
        [Test]
        public void test_2(){

            int[] inputList = { 3, 4, 6, 2, 2, 1, 4, 3 };
            int target = 5;
            int aim = 6;

            int pairs = counter_pairs(inputList, target);

            Assert.AreEqual(aim, pairs);
        }
    }
}
