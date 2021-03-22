using System.Collections.Generic;
using DoitStudy.Interface;

namespace DoitStudy.Utils
{
    public class AssignmentRunning : IAssignmentRunning
    {
        /* Dont Touch */
        public bool isRunning { get;  set; }
        private IAssignment assignment = null;
        private ITestCase testcase = null;

        public AssignmentRunning(IAssignment _assignment, ITestCase _testcase){
            assignment = _assignment;
            testcase = _testcase;
        }

        /********************/
        public void RunCode(){
            var inputs = testcase.input();
            List<object> outputs = new List<object>();

            foreach(var temp in inputs){
                outputs.Add(assignment.main(temp));
            }

            testcase.output(outputs.ToArray());
        }
    }
}