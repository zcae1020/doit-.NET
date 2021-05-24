using System.Linq;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using StudentManager.Data.EnumData;
using StudentManager.Data.Models;
using System.Threading.Tasks;

namespace StudentManager.Data.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _students = database.GetCollection<Student>(settings.StudentsCollectionName);
        }

        public async Task<List<Student>> GetStudentsAsync() =>
            //_student를 Return
            await _students.Find(st => true).ToListAsync();

        public async Task<Student> GetAsync(string id) =>
            //DB Id가 파라미터 id와 동일한 student Return.
            await _students.Find<Student>(student => student.Id == id).FirstOrDefaultAsync();

        public async Task<Student> GetByStudentIdAsync(string id) =>
            //StudentId가 파라미터 id와 동일한 student Return.
            await _students.Find(student => student.studentId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Student student){
            //파라미터 student를 DB에 추가.
            await _students.InsertOneAsync(student);
        }

        public async Task UpdateAsync(string id, Student studentIn) =>
            //DB Id가 파라미터 id와 동일한 Student를 studentIn으로 업데이트.
            await _students.ReplaceOneAsync(student => student.Id == id, studentIn);

        public async Task RemoveByStudentIdAsync(string id){
            //StudentId가 파라미터 id와 동일한 Student를 제거.
            Student student = await GetByStudentIdAsync(id);
            await _students.DeleteOneAsync(s => s.Id == student.Id);
        }
        public async Task RemoveAsync(Student studentIn) =>
            //파라미터의 studentIn와 동일한 내용의 Student 제거.
            await _students.DeleteOneAsync(s => s.Id == studentIn.Id);

        public async Task Remove(string id) =>
            //DB Id가 파라미터의 id와 동일한 Student 제거.
            await _students.DeleteOneAsync(s => s.Id == id);
    }
}