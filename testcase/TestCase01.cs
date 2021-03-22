using System;
using System.Collections.Generic;
using DoitStudy.Interface;

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
                var data = (string[])results[i];
                var res = cases[i].test(data) ? "O" : "X";
                Console.WriteLine($"Case 0{i+1} : {res}");
            }
        }

        private TestCase[] cases = new TestCase[]{
                new TestCase('k', new string[] {
                    "AABB", "AAkk", "kkAA", "ccck", "ASD", "adva", "iadh", "advadn"
                }),
                new TestCase('A', new string[]{
                    "Aavd", "sgoSGFOA", "DFBaa", "aaavfsdv", "SFGJASDFNoA", "NFGSIbdng"
                }),
                new TestCase('b', new string[]{
                    "AQGR", "GOWNGOIRW", "SGOSFGH", "DWQOI", "PODASD", "BDDIO", "MinShiGee" 
                }),
                new TestCase('C', new string[]{
                    "","","","","","CCAccc","CCcc","GFSJSIC","CCcc"
                }),
                new TestCase('d', new string[]{
                    String.Empty, null, "SDdd", "dddd", "SDIOGD", "ddasd", "dddd"
                })
        };

        public class TestCase{
            public char token { get; private set;}
            public string[] strArr { get; private set;}

            public TestCase(char _token, string[] _strArr){
                token = _token;
                strArr = _strArr;
            }

            internal bool test(string[] resArr){

                List<string> resData = new List<string>();
                foreach(var temp in strArr){
                    if(temp == null || temp.Length <= 0)
                        continue;
                    if(temp.Contains(token))
                        resData.Add(temp);
                }
                resData.Sort();

                /***** 결과 비교 코드 *****/
                if(resArr.Length != (resData.ToArray()).Length)
                    return false;
                for(int i = 0; i < resArr.Length; i++){
                    if(resArr[i].Equals(resData[i]))
                        continue;
                    return false;                   
                }
                return true;
                /****************************/
            }
        }

    }
}