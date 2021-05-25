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
            await _students.Find(st => true).ToListAsync();

        public async Task<Student> GetAsync(string id) =>
            await _students.Find<Student>(student => student.Id == id).FirstOrDefaultAsync();


        public async Task<Student> GetByStudentIdAsync(string id) =>
            await _students.Find(student => student.studentId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Student student){
            await _students.InsertOneAsync(student);
        }

        public async Task UpdateAsync(string id, Student studentIn) =>
            await _students.ReplaceOneAsync(student => student.Id == id, studentIn);

        public async Task RemoveByStudentIdAsync(string id){
            Student student = await GetByStudentIdAsync(id);
            await _students.DeleteOneAsync(st => st.Id == student.Id);
        }
        public async Task RemoveAsync(Student studentIn) =>
            await _students.DeleteOneAsync(st => st.Id == studentIn.Id);

        public async Task Remove(string id) => 
            await _students.DeleteOneAsync(st => st.Id == id);
    }
}