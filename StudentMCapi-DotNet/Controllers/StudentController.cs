using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMCapi_DotNet.Entity;
using StudentMCapi_DotNet.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
namespace StudentMCapi_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataContext context;

        public StudentController(DataContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            try
            {
                var students = await context.Students.ToListAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {

                throw ex;
            }
       
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> GetStudent(int id)
        {
            var student = await context.Students.FindAsync(id); // Find the Student with that specific ID
            if (student == null)
            {
                return NotFound();

            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent(Student student)
        {
            try
            {
               
                context.Students.Add(student);
                await context.SaveChangesAsync();
                return Ok(await context.Students.ToListAsync());
            }
            catch (Exception EX)
            {

                throw EX;
            }
        
        }
        [HttpDelete]
        public async Task<ActionResult<List<Student>>> DeleteStudent(Student student)
        {
            var dbStudent =  await context.Students.FindAsync(student.Id);

            if (dbStudent == null)
            {
                return NotFound();
            }
            else
            {
                context.Students.Remove(dbStudent);
                await context.SaveChangesAsync();
                return Ok(await context.Students.ToListAsync());
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateStudent(Student UpdatedStudent)
        {
            var dbStudent = await context.Students.FindAsync(UpdatedStudent.Id);

            if (dbStudent == null)
            {
                return NotFound();
            }
            else
            {
                dbStudent.Name = UpdatedStudent.Name;
                dbStudent.Major = UpdatedStudent.Major;
                dbStudent.gpa = UpdatedStudent.gpa;
                return Ok(await context.Students.ToListAsync());

            }
        }
    }
}