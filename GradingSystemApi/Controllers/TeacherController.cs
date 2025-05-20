using GradingSystemApi.Models.addDto;
using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;

namespace GradingSystemApi.Controllers
{
    // Route for this controller: api/Teacher
    [Route("api/[controller]")]
    // Marks this as an API controller
    [ApiController]
    // Controller for managing Teacher entities
    public class TeacherController : ControllerBase
    {
        // The database context for accessing data
        private readonly GradingDbContext DbContext;

        // Constructor for dependency injection of the context
        public TeacherController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        // GET: api/Teacher
        // Returns all teachers
        [HttpGet]
        public IActionResult GetAllTeacher()
        {
            var Teacher = DbContext.Teacher
                .ToList();           // Get all teachers as a list
            return Ok(Teacher);      // Return HTTP 200 with the list
        }

        // GET: api/Teacher/{TeacherID}
        // Returns a specific teacher by their ID
        [HttpGet]
        [Route("{TeacherID}")]
        public IActionResult GetTeacherByID(int TeacherID)
        {
            var TeacherEntity = DbContext.Teacher.Find(TeacherID); // Find by primary key
            if (TeacherEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return Ok(TeacherEntity); // Return HTTP 200 with the teacher
        }

        // POST: api/Teacher
        // Adds a new teacher
        [HttpPost]
        public IActionResult AddTeacher(TeacherDto addTeacher)
        {
            if (addTeacher == null)
            {
                return BadRequest("Teacher cannot be null"); // Return 400 if input is null
            }
            // Create new Teacher entity from DTO
            var teacherEntity = new Teacher()
            {
                FirstName = addTeacher.FirstName,
                Lastname = addTeacher.Lastname,
                Email = addTeacher.Email,
                PhoneNumber = addTeacher.PhoneNumber,
                Department = addTeacher.Department
            };
            DbContext.Add(teacherEntity);      // Add to context
            DbContext.SaveChanges();           // Save to database
            return Ok(teacherEntity);          // Return HTTP 200 with created teacher
        }

        // PUT: api/Teacher/{TeacherID}
        // Updates an existing teacher
        [HttpPut]
        [Route("{TeacherID}")]
        public IActionResult UpdateTeacher(int TeacherID, TeacherDto teacher)
        {
            var TeacherEntity = DbContext.Teacher.Find(TeacherID); // Find by ID
            if (TeacherEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            // Update properties
            TeacherEntity.FirstName = teacher.FirstName;
            TeacherEntity.Lastname = teacher.Lastname;
            TeacherEntity.Email = teacher.Email;
            TeacherEntity.PhoneNumber = teacher.PhoneNumber;
            TeacherEntity.Department = teacher.Department;

            DbContext.SaveChanges(); // Save changes
            return Ok(TeacherEntity); // Return HTTP 200 with updated teacher
        }

        // DELETE: api/Teacher/{TeacherID}
        // Deletes a teacher by their ID
        [HttpDelete]
        [Route("{TeacherID}")]
        public IActionResult DeleteTeacher(int TeacherID)
        {
            var TeacherEntity = DbContext.Teacher.Find(TeacherID); // Find by ID
            if (TeacherEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            DbContext.Teacher.Remove(TeacherEntity); // Remove from context
            DbContext.SaveChanges();                // Save changes
            return Ok(TeacherEntity);               // Return HTTP 200 with deleted teacher
        }
    }
}
