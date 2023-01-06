using NUnit.Framework;
using System.Collections.Generic;

namespace Tests{
    public class Task_3{
        public static int Digital_root(int num){
            int res = 0;
            while (num > 0){
                res += num % 10;
                num /= 10;
            }
            if (res > 9) {
                res = Digital_root(res);
            }
            return res;
        }

        [Test]
        public void test_1(){
            int incoming = 16;
            int expected = 7;

            incoming = Digital_root(incoming);

            Assert.AreEqual(expected, incoming);
        }
        [Test]
        public void test_2(){
            int incoming = 493193;
            int expected = 2;

            incoming = Digital_root(incoming);

            Assert.AreEqual(expected, incoming);
        }
    }
}