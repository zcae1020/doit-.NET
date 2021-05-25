using System;
using System.Collections.Generic;
using StudentManager.Data.Models;
using StudentManager.Data.EnumData;

namespace StudentManager.Data.Interfaces
{
    public interface ITestScoreService
    {
         public List<TestScore> scores {get; set;}
         public List<TestScore> GetScores();
         public TestScore GetScoreById(string id);
         public List<TestScore> GetScoresByStudentId(string id);
         public ResultCode AddTestScore(TestScore testScore);
         public ResultCode RemoveTestScoreById(string id);
         public ResultCode RemoveTestScoresByStudentId(string id);
    }
}