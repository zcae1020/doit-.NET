using System;
using System.Collections.Generic;
using DoitStudy.Interface;
using DoitStudy.Testcase;
using Assignment01Class;

namespace DoitStudy.Assignments
{
    public class Assignment01 : IAssignment
    {
        public object main(object data){
            string inputData = ((TestCase01.TestCase)data).inputData; // inputData
            //res에 값을 저장시켜주세요.

            Toy[] res = {}; // 파싱하고 값을 바르게 넣기
            List<Toy> li = new List<Toy>();

            string[] line = inputData.Split('\n');

            foreach(string str in line){
                string[] att = str.Split(' ');
                Toy tmp = new Toy(att[0],att[1],att[2]);
                li.Add(tmp);
            }

            res = li.ToArray();
            

            //return 값은 Toy Class의 Array 형식으로 Toy[] 입니다.
            return res;
        }
    }
}