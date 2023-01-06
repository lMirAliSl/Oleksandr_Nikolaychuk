using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace Tests{
    public class Extra_task_2{
        public static string address(uint num){
            int temp = 0;
            uint[] arr = new uint[32];
            while (temp < 32){
                arr[temp] = (num % 2);
                num /= 2;
                temp++;
            }
            temp = 0;
            string result = "";
            while (temp < 4){
                uint dec = 0;
                int pow = 0;
                for (int j = temp * 8; j < temp * 8 + 8; j++){
                    dec += arr[j] * (uint)Math.Pow(2, pow);
                    pow++;
                }
                result = result.Insert(0, dec.ToString());
                if (temp != 3){
                    result = result.Insert(0, ".");
                }
                temp++;
            }
            return result;
        }

        [Test]
        public void ExtraTask2Test1(){
            uint incoming = 2149583361;
            string expected = "128.32.10.1";

            string result = address(incoming);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void ExtraTask2Test2(){
            uint incoming = 0;
            string expected = "0.0.0.0";

            string result = address(incoming);

            Assert.AreEqual(expected, result);
        }
    }
}