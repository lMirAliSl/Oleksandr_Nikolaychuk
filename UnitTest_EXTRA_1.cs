using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Tests{
    public class Extra_task_1{
        public static int bigger_number(int num){
            int[] num_arr = new int[num.ToString().Length];
            int extra_num = 0;
            while (num > 0){
                num_arr[extra_num] = num % 10;
                num /= 10;
                extra_num++;
            }
            extra_num = 0;
            bool check = true;
            while (extra_num < num_arr.Length - 1){
                if (num_arr[extra_num] > num_arr[extra_num + 1]){
                    check = false;
                    int temp = num_arr[extra_num];
                    num_arr[extra_num] = num_arr[extra_num + 1];
                    num_arr[extra_num + 1] = temp;
                    while (extra_num > 0){
                        if (num_arr[extra_num] > num_arr[extra_num - 1]){
                            temp = num_arr[extra_num];
                            num_arr[extra_num] = num_arr[extra_num - 1];
                            num_arr[extra_num - 1] = temp;
                        }
                        extra_num--;
                    }
                    break;
                }
                else extra_num++;
            }
            if (check){
                return -1;
            }
            num = 0;
            for (int i = 0; i < num_arr.Length; i++){
                num = num + num_arr[i] * (int)(Math.Pow(10, i));
            }
            return num;
        }

        [Test]
        public void test_1(){
            int incoming = 9;
            int expected = -1;

            incoming = bigger_number(incoming);

            Assert.AreEqual(expected, incoming);
        }

        [Test]
        public void test_2(){
            int incoming = 623;
            int expected = 632;

            incoming = bigger_number(incoming);

            Assert.AreEqual(expected, incoming);
        }
    }
}