using Microsoft.AspNetCore.Mvc;
using StudentManager.Data.Services;
using StudentManager.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManager.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAsync() =>
            await _studentService.GetStudentsAsync();

        [HttpGet("{id:length(24)}", Name = "GetStudent")]
        public async Task<ActionResult<Student>> GetAsync(string id)
        {
            var student = await _studentService.GetAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpGet("studentId={id:length(4)}")]
        public async Task<ActionResult<Student>> GetByIdAsync(string id)
        {
            var student = await _studentService.GetByStudentIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateAsync(Student_Dto studentDto)
        {
            var student = new Student(studentDto);
            await _studentService.CreateAsync(student);

            return CreatedAtRoute("GetStudent", new { id = student.Id.ToString() }, student);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateAsync(string id, Student_Dto studentDtoIn)
        {
            var student = await _studentService.GetAsync(id);
            var studentIn = new Student(studentDtoIn);
            studentIn.Id = id;

            if (student == null)
            {
                return NotFound();
            }

            await _studentService.UpdateAsync(id, studentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var student = await _studentService.GetAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            await _studentService.Remove(student.Id);

            return NoContent();
        }
    }
}