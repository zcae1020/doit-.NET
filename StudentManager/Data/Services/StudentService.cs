using System.Linq;
using System;
using System.Collections.Generic;
using StudentManager.Data;
using StudentManager.Data.EnumData;
using StudentManager.Data.Models;
using StudentManager.Data.Interfaces;

namespace StudentManager.Data.Services
{
    public class StudentService : IStudentService
    {
        public List<Student> students{get; set;}


        public StudentService(){
            students = new List<Student>();
            students.Add(new Student("0001", "minshigee", 22, GenderId.Male, CountryId.Korea, new DateTime(2019,03,01)));
        }


        public List<Student> GetStudents() => students;

        public Student GetStudentById(string id){
            return students.Where(student => student.studentId == id).FirstOrDefault();
        }

        public ResultCode AddStudent(Student student){

            if(student.studentId.Length != 4){
                return new ResultCode(ResultId.Failed, "studentId가 4자리가 아닙니다. 4자리로 맞춰주세요. ex:) \"1234\"");
            }

            if(student.studentId == Student.studentDefaultId){
                return new ResultCode(ResultId.Failed, "studentId가 초기 설정 Id와 일치합니다.");
            }

            using(null){
                var _student = GetStudentById(student.studentId);
                if( _student != null && _student.studentId != default){
                    return new ResultCode(ResultId.Failed, "동일한 studentId의 데이터가 이미 존재합니다.");
                }
            }

            students.Add(student);
            return new ResultCode(ResultId.Success, $"성공적으로 \"{student.studentId}\"를 추가했습니다.");
        }

        public ResultCode RemoveStudentById(string id){

            Student student = GetStudentById(id);

            if(student == default){
                return new ResultCode(ResultId.Failed, "해당 id의 데이터가 존재하지 않습니다.");
            }

            students.Remove(student);
            return new ResultCode(ResultId.Success, $"성공적으로 {student.studentId}를 제거했습니다.");
        }
        
    }
}