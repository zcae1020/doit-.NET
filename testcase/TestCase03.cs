using System;
using System.Collections.Generic;

namespace doit_study_homework_template.testcase
{
    public class TestCase03 : ITestCase<int>
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

            Console.WriteLine($"Assignment03 결과.");
            for(int i = 0; i < len; i++){
                var res = cases[i].test(results[i]) ? "O" : "X";
                Console.WriteLine($"Case 0{i+1} : {res} ");
            }
        }

        private TestCase[] cases = new TestCase[]{
                new TestCase(new int[]{9,8,7,6,5,4,3,2,1}),
                new TestCase(new int[]{100,100,100,100,100}),
                new TestCase(new int[]{-1,-2,-3,-4,-5,-6,-7}),
                new TestCase(new int[]{12,13,15,0,12,-1,-9}),
                new TestCase(new int[]{1}),
                new TestCase(new int[]{-123123,123123,123124,-124124}),
                new TestCase(new int[]{-100000000,-99999999, -99999998, -99999997})
        };

        public class TestCase{
            public int[] numArr { get; private set;}

            public TestCase(int[] _numArr){
                numArr = _numArr;
            }

            internal bool test(int _num){
                int key = -2000000000;
                foreach(var tmp in numArr){
                    if(tmp > key)
                        key = tmp;
                }
                return key == _num;
            }
        }

    }
}