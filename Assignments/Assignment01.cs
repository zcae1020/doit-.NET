using System;
using System.Collections.Generic;
using DoitStudy.Interface;
using DoitStudy.Testcase;

namespace DoitStudy.Assignments
{
    public class Assignment01 : IAssignment
    {
        public object main(object data)
        {
            char token = ((TestCase01.TestCase)data).token; // token
            string[] strArr = ((TestCase01.TestCase)data).strArr; // string이 저장된 array
            //res에 값을 저장시켜주세요.
            string[] res = { }; // strArr에 저장된 데이터 중에서 token을 포함한 값을 추출하여 저장한 뒤, 사전 순으로 정렬하기.

            List<string> tmp = new List<string>();

            foreach(string str in strArr){
                if(str == null || str == string.Empty)
                    continue;
                foreach(char a in str){
                    if(token == a){
                        tmp.Add(str);
                        break;
                    }
                }
            }

            res = tmp.ToArray();
            Array.Sort(res, StringComparer.InvariantCulture);


            //return 값은 string Array 형식으로 string[] 입니다.
            return res;
        }
    }
}