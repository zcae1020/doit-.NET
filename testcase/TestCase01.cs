using System;
using System.Collections.Generic;
using DoitStudy.Interface;
using Assignment01Class;

namespace DoitStudy.Testcase
{
    public class TestCase01 : ITestCase
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

            Console.WriteLine($"Assignment01 결과.");
            for(int i = 0; i < len; i++){
                var data = (Toy[])results[i];
                var res = cases[i].test(data) ? "O" : "X";
                Console.WriteLine($"Case 0{i+1} : {res}");
            }
        }

        private TestCase[] cases = new TestCase[]{
                new TestCase(
                    "Boy 2018 15000\n" +
                    "Girl 2018 16000\n" +
                    "Dog 2019 6000\n" +
                    "Cat 2020 12900"
                ),
                new TestCase(
                    "AAA 2013 12000\n" +
                    "BBBC 2011 11000\n" +
                    "DDDD 2012 65000\n" +
                    "EEEE 2025 12900"
                )
        };

        public class TestCase{
            public string inputData { get; private set;}

            public TestCase(string _inputData){
                inputData = _inputData;
            }

            internal bool test(Toy[] resArr){
                
                string res = "";
                foreach(var toy in resArr){
                    res += $"{toy.name} {toy.year} {toy.price}\n";
                    if(toy.point != (toy.year % 100) * (toy.price / 1000))
                        return false;
                }
                /***** 결과 비교 코드 *****/
                return res == inputData + '\n';
                /****************************/
            }
        }

    }
}