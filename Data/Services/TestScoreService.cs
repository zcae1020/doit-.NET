using System.Linq;
using System;
using System.Collections.Generic;
using StudentManager.Data;
using StudentManager.Data.EnumData;
using StudentManager.Data.Models;
using StudentManager.Data.Interfaces;

namespace StudentManager.Data.Services
{
    public class TestScoreService : ITestScoreService
    {
        public List<TestScore> scores {get; set;}

        public TestScoreService(){
            scores = new List<TestScore>();
            scores.Add(new TestScore("0001",SubjectId.Korean_Language,82,1801));
            scores.Add(new TestScore("0001",SubjectId.Programming,98,1801));
        }

        public List<TestScore> GetScores(){
            return scores;
        }

        //파라미터의 id와 동일한 scoreId를 갖는 TestScore를 scores에서 찾아 return. 
        public TestScore GetScoreById(string id){
            //Code...
            return default;
        }

        //파라미터의 studentId를 가진 TestScore들을 resList에 Add 하여 return.
        public List<TestScore> GetScoresByStudentId(string id){
            
            var resList = new List<TestScore>();
            
            //Code...
            return default;
        }

        //파라미터의 testScore 를 scores에 Add하고 new ResultCode()를 생성하여 return.
        public ResultCode AddTestScore(TestScore testScore){
            //Code...
            return default;
        }

        public ResultCode RemoveTestScoreById(string id){
            //Code...
            return default;
        }

        public ResultCode RemoveTestScoresByStudentId(string id){
            //Code...
            return default;
        }

    }
}