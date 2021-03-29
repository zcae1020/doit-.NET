using System.Linq;
using System;
using System.Collections.Generic;
using DoitStudy.Interface;
using DoitStudy.Utils;
using DoitStudy.Assignments;
using DoitStudy.Testcase;

namespace DoitStudy
{
    class Program
    {
        static void Main(string[] args)
        {

            IAssignmentRunning[] assignments = {
                new AssignmentRunning(new Assignment01(), new TestCase01()), 
            };

            assignments[0].isRunning = true; //1번 Assignment  // 결과를 보고싶은 과제의 false를 true로 수정하세요

            foreach(var temp in assignments){
                if(temp.isRunning)
                    temp.RunCode();
            }
        }

    }
}
