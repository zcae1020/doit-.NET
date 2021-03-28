using System;
using System.Collections.Generic;
using DoitStudy.Interface;
using DoitStudy.Testcase;

namespace DoitStudy.Assignments
{
    public class Assignment02 : IAssignment
    {
        public object main(object data){
            string[] strArr = ((TestCase02.TestCase)data).strArr; // Ex:) strArr = {"123", "-123", "32"} 
            int res = 0; // Ex:) res = -91 위의 예제 기준

            if(strArr.Length < 2)
                return 0;
            
            
            List<int> tmp = new List<int>();
            foreach(string str in strArr){
                tmp.Add(Convert.ToInt32(str));
            }
            
            int[] arrInt = tmp.ToArray();
            Array.Sort(arrInt);

            res = arrInt[0] + arrInt[1];

            return res;
        }
    }
}