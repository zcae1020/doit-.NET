using System;
using System.Collections.Generic;
using StudentManager.Data.Models;
using StudentManager.Data.EnumData;

namespace StudentManager.Data.Interfaces
{
    public interface IStudentService
    {
        public List<Student> students{get; set;}
        public List<Student> GetStudents();
        public Student GetStudentById(string id);
        public ResultCode AddStudent(Student student);
        public ResultCode RemoveStudentById(string id);
    }
}