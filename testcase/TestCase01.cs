using System;
using System.Collections.Generic;

namespace doit_study_homework_template.testcase
{
    public class TestCase01 : ITestCase<int>
    {
        public object[] input(){
            return cases;
        }

        public void output(int[] results){
            int len = cases.Length;

            if(len != results.Length){
                Console.WriteLine($"results 배열의 길이를 확인해주세요.");
                return;
            }

            Console.WriteLine($"Assignment01 결과.");
            for(int i = 0; i < len; i++){
                var res = cases[i].test(results[i]) ? "O" : "X";
                Console.WriteLine($"Case 0{i+1} : {res}");
            }
        }

        private TestCase[] cases = new TestCase[]{
                new TestCase(1,2),
                new TestCase(100,200),
                new TestCase(-100,300),
                new TestCase(400,400),
                new TestCase(-1,0),
                new TestCase(-199,-200)
        };

        public class TestCase{
            public int num01 { get; private set;}
            public int num02 { get; private set;}

            public TestCase(int _num01, int _num02){
                num01 = _num01;
                num02 = _num02;
            }

            internal bool test(int _case){
                return ((num01 > num02) ? num01 : num02) == _case;
            }
        }

    }
}