using GradingSystemApi.Models.Dto;
using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;

namespace GradingSystemApi.Controllers
{
    // Route for this controller: api/Student
    [Route("api/[controller]")]
    // Marks this as an API controller
    [ApiController]
    // Controller for managing Student entities
    public class StudentController(GradingDbContext DbContext) : ControllerBase
    {
        // The database context for accessing data
        private readonly GradingDbContext DbContext = DbContext;

        // GET: api/Student
        // Returns all students
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var Student = DbContext.Student
                .ToList();           // Get all students as a list

            return Ok(Student);      // Return HTTP 200 with the list
        }

        // GET: api/Student/{StudentID}
        // Returns a specific student by their ID
        [HttpGet]
        [Route("{StudentID}")]
        public IActionResult GetStudentByID(int StudentID)
        {
            var Student = DbContext.Student.Find(StudentID); // Find by primary key
            if (Student == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return Ok(Student); // Return HTTP 200 with the student
        }

        // POST: api/Student
        // Adds a new student
        [HttpPost]
        public IActionResult AddStudent(StudentDto AddStudent)
        {
            // Create new Student entity from DTO
            var StudentEntity = new Student()
            {
                FirstName = AddStudent.FirstName,
                MiddleName = AddStudent.MiddleName,
                LastName = AddStudent.LastName,
                BirthDate = AddStudent.BirthDate,
                Sex = AddStudent.Sex,
                Email = AddStudent.Email,
                PhoneNumber = AddStudent.PhoneNumber
            };

            DbContext.Add(StudentEntity);      // Add to context
            DbContext.SaveChanges();           // Save to database

            return Ok(StudentEntity);          // Return HTTP 200 with created student
        }

        // PUT: api/Student/{StudentID}
        // Updates an existing student
        [HttpPut]
        [Route("{StudentID}")]
        public IActionResult UpdateStudent(int StudentID, StudentDto UpdateStudent)
        {
            if (UpdateStudent == null)
            {
                return BadRequest("Student cannot be null"); // Return 400 if input is null
            }
            var StudentEntity = DbContext.Student.Find(StudentID); // Find by ID
            if (StudentEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }

            // Update properties
            StudentEntity.FirstName = UpdateStudent.FirstName;
            StudentEntity.MiddleName = UpdateStudent.MiddleName;
            StudentEntity.LastName = UpdateStudent.LastName;
            StudentEntity.BirthDate = UpdateStudent.BirthDate;
            StudentEntity.Sex = UpdateStudent.Sex;
            StudentEntity.Email = UpdateStudent.Email;
            StudentEntity.PhoneNumber = UpdateStudent.PhoneNumber;

            DbContext.SaveChanges(); // Save changes
            return Ok(StudentEntity); // Return HTTP 200 with updated student
        }

        // DELETE: api/Student/{StudentID}
        // Deletes a student by their ID
        [HttpDelete]
        [Route("{StudentID}")]
        public IActionResult DeleteStudent(int StudentID)
        {
            var StudentEntity = DbContext.Student.Find(StudentID); // Find by ID
            if (StudentEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            DbContext.Student.Remove(StudentEntity); // Remove from context
            DbContext.SaveChanges();                // Save changes
            return Ok(StudentEntity);               // Return HTTP 200 with deleted student
        }
    }
}
