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
            var res = scores.Where(score => score.scoreId == id).FirstOrDefault();
            return res;
        }

        //파라미터의 studentId를 가진 TestScore들을 resList에 Add 하여 return.
        public List<TestScore> GetScoresByStudentId(string id){
            
            var resList = scores.Where(score => score.studentId == id).ToList();
            return resList;
        }

        //파라미터의 testScore 를 scores에 Add하고 new ResultCode()를 생성하여 return.
        public ResultCode AddTestScore(TestScore __score){
            var score = new TestScore(__score.studentId, __score.subjectId, __score.score, __score.semester);
            if(score.studentId.Length != 4){
                return new ResultCode(ResultId.Failed, "studentId가 4자리가 아닙니다. 4자리로 맞춰주세요. ex:) \"1234\"");
            }

            if(score.studentId == Student.studentDefaultId){
                return new ResultCode(ResultId.Failed, "studentId가 초기 설정 Id와 일치합니다.");
            }

            using(null){
                var _score = GetScoreById(score.scoreId);
                if( _score != null && _score.scoreId != default){
                    return new ResultCode(ResultId.Failed, "동일한 testScoreId의 데이터가 이미 존재합니다.");
                }
            }

            scores.Add(score);
            return new ResultCode(ResultId.Success, $"성공적으로 \"{score.scoreId}\"를 추가했습니다.");
        }

        public ResultCode RemoveTestScoreById(string id){
            var _score = GetScoreById(id);

            if(_score == default){
                return new ResultCode(ResultId.Failed, "해당 id의 데이터가 존재하지 않습니다.");
            }

            scores.Remove(_score);
            return new ResultCode(ResultId.Success, $"성공적으로 {_score.scoreId}를 제거했습니다.");
        }

        public ResultCode RemoveTestScoresByStudentId(string id){
            
            var _scores = GetScoresByStudentId(id);
            var res = new ResultCode(ResultId.Success, $"성공적으로 {id}의 점수를 제거했습니다.");
            var codeDescription = "";

            foreach(var _score in _scores){
                var code = RemoveTestScoreById(_score.scoreId);
                if(code.id == ResultId.Failed){
                    res.id = ResultId.Failed;
                    codeDescription += $"{_score.scoreId}, ";
                }
            }

            if(res.id == ResultId.Failed){
                res.description = $"{codeDescription} 제거에 실패했습니다.";
            }

            return res;
        }

    }
}