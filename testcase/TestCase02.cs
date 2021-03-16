using System;
using System.Collections.Generic;

namespace doit_study_homework_template.testcase
{
    public class TestCase02 : ITestCase<string>
    {
        public object[] input(){
            return cases;
        }

        public void output(string[] results){
            int len = cases.Length;

            if(len != results.Length){
                Console.WriteLine($"results 배열의 길이를 확인해주세요.");
                return;
            }
            Console.WriteLine($"Assignment02 결과.");
            for(int i = 0; i < len; i++){
                var res = cases[i].test(results[i]) ? "O" : "X";
                Console.WriteLine($"Case 0{i+1} : {res} ");
            }
        }

        private TestCase[] cases = new TestCase[]{
                new TestCase("heLLo woRld!"),
                new TestCase("asdasd ASDASD dsabvxc BFD.aSd-asD"),
                new TestCase("123 -= 9af DAS ncajs"),
                new TestCase("asdasd DASDAS {PMZ zxcaq"),
                new TestCase("mvlkmssdonif"),
                new TestCase("AA"),
                new TestCase(" ")
        };

        public class TestCase{
            public string str { get; private set;}

            public TestCase(string _str){
                str = _str;
            }

            internal bool test(string _str){
                return str.ToUpper() == _str;
            }
        }

    }
}