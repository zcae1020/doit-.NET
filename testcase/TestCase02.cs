using System;
using System.Collections.Generic;
using DoitStudy.Interface;

namespace DoitStudy.Testcase
{
    public class TestCase02 : ITestCase
    {
        public object[] input(){
            return cases;
        }

        public void output(object[] results){
            int len = cases.Length;
            
            if(len != results.Length){
                Console.WriteLine($"results 배열의 길이를 확인해주세요.");
                return;
            }

            Console.WriteLine($"Assignment02 결과.");
            for(int i = 0; i < len; i++){
                var num = (int)results[i];
                var res = cases[i].test(num) ? "O" : "X";
                Console.WriteLine($"Case 0{i+1} : {res}");
            }
        }

        private TestCase[] cases = new TestCase[]{
                new TestCase(new string[]{
                    "123", "456", "111", "1", "2", "33"
                }),
                new TestCase(new string[]{
                    "-1", "1", "0", "-2", "-2", "3", "-4", "-5"
                }),
                new TestCase(new string[]{
                    "0", "0", "0", "0", "0", "0"
                }),
                new TestCase(new string[]{
                    "1", "1413", "1234", "653", "4252"
                }),
                new TestCase(new string[]{
                    "-400", "-1351", "541941", "-84415", "15145"
                }),
                new TestCase(new string[]{
                    "431", "-431", "432", "-432", "521", "-521"
                })
        };

        public class TestCase{
            public string[] strArr { get; private set;}
            
            public TestCase(string[] _strArr){
                strArr = _strArr;
            }

            internal bool test(int res){

                if(strArr.Length < 2)
                    return res == 0;

                List<int> integers = new List<int>();
                foreach(var temp in strArr)
                    integers.Add( Convert.ToInt32(temp) );
                integers.Sort();
                var _res = integers[0] + integers[1];

                return _res == res;
            }
        }

    }
}