using GradingSystemApi.Models.Dto;
using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;

namespace GradingSystemApi.Controllers
{
    // Route for this controller: api/TeacherSubject
    [Route("api/[controller]")]
    // Marks this as an API controller
    [ApiController]
    // Controller for managing TeacherSubject entities
    public class TeacherSubjectController : ControllerBase
    {
        // The database context for accessing data
        private readonly GradingDbContext DbContext;

        // Constructor for dependency injection of the context
        public TeacherSubjectController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        // GET: api/TeacherSubject
        // Returns all teacher-subject relationships, including related teacher and subject details
        [HttpGet]
        public IActionResult GetAllTeacherSubject()
        {
            var TeacherSubject = DbContext.TeacherSubject
                .ToList();                 // Convert to a list
            return Ok(TeacherSubject);     // Return HTTP 200 with the list
        }

        // GET: api/TeacherSubject/{TeacherSubjectID}
        // Returns a specific teacher-subject relationship by its ID, including teacher and subject details
        [HttpGet]
        [Route("{TeacherSubjectID}")]
        public IActionResult GetTeacherSubjectByID(int TeacherSubjectID)
        {
            var teacherSubjectEntity = DbContext.TeacherSubject
                .FirstOrDefault(ts => ts.TeacherSubjectID == TeacherSubjectID); // Find by primary key

            if (teacherSubjectEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return Ok(teacherSubjectEntity); // Return HTTP 200 with the entity
        }

        // POST: api/TeacherSubject
        // Adds a new teacher-subject relationship
        [HttpPost]
        public IActionResult AddTeacherSubject(TeacherSubjectDto addTeacherSubject)
        {
            // Validate that the Teacher exists
            var teacherExists = DbContext.Teacher.Any(t => t.TeacherID == addTeacherSubject.TeacherID);
            if (!teacherExists)
            {
                // Return 400 if teacher does not exist
                return BadRequest($"Teacher with ID {addTeacherSubject.TeacherID} does not exist");
            }

            // Validate that the Subject exists
            var subjectExists = DbContext.Subject.Any(s => s.SubjectCode == addTeacherSubject.SubjectCode);
            if (!subjectExists)
            {
                // Return 400 if subject does not exist
                return BadRequest($"Subject with code {addTeacherSubject.SubjectCode} does not exist");
            }

            // Create new TeacherSubject entity from DTO
            var teacherSubjectEntity = new TeacherSubject()
            {
                TeacherID = addTeacherSubject.TeacherID,
                SubjectCode = addTeacherSubject.SubjectCode
            };

            DbContext.Add(teacherSubjectEntity);      // Add to context
            DbContext.SaveChanges();                  // Save to database

            // Return the created entity with its relations
            var createdEntity = DbContext.TeacherSubject
                .FirstOrDefault(ts => ts.TeacherSubjectID == teacherSubjectEntity.TeacherSubjectID);

            return Ok(createdEntity); // Return HTTP 200 with created entity
        }

        // PUT: api/TeacherSubject/{TeacherSubjectID}
        // Updates an existing teacher-subject relationship
        [HttpPut]
        [Route("{TeacherSubjectID}")]
        public IActionResult UpdateTeacherSubject(int TeacherSubjectID, TeacherSubjectDto teacherSubject)
        {
            if (teacherSubject == null)
            {
                return BadRequest("TeacherSubject cannot be null"); // Return 400 if input is null
            }

            // Find the entity to update
            var teacherSubjectEntity = DbContext.TeacherSubject.Find(TeacherSubjectID);
            if (teacherSubjectEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }

            // Validate that the Teacher exists
            var teacherExists = DbContext.Teacher.Any(t => t.TeacherID == teacherSubject.TeacherID);
            if (!teacherExists)
            {
                return BadRequest($"Teacher with ID {teacherSubject.TeacherID} does not exist");
            }

            // Validate that the Subject exists
            var subjectExists = DbContext.Subject.Any(s => s.SubjectCode == teacherSubject.SubjectCode);
            if (!subjectExists)
            {
                return BadRequest($"Subject with code {teacherSubject.SubjectCode} does not exist");
            }

            // Update properties
            teacherSubjectEntity.TeacherID = teacherSubject.TeacherID;
            teacherSubjectEntity.SubjectCode = teacherSubject.SubjectCode;

            DbContext.SaveChanges(); // Save changes

            // Return the updated entity with its relations
            var updatedEntity = DbContext.TeacherSubject
                .FirstOrDefault(ts => ts.TeacherSubjectID == TeacherSubjectID);

            return Ok(updatedEntity); // Return HTTP 200 with updated entity
        }

        // DELETE: api/TeacherSubject/{TeacherSubjectID}
        // Deletes a teacher-subject relationship by its ID
        [HttpDelete]
        [Route("{TeacherSubjectID}")]
        public IActionResult DeleteTeacherSubject(int TeacherSubjectID)
        {
            // Find the entity to delete
            var teacherSubjectEntity = DbContext.TeacherSubject.Find(TeacherSubjectID);
            if (teacherSubjectEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            DbContext.TeacherSubject.Remove(teacherSubjectEntity); // Remove from context

            // Optionally retrieve the deleted entity (will be null)
            var deletedEntity = DbContext.TeacherSubject
                .FirstOrDefault(c => c.TeacherSubjectID == teacherSubjectEntity.TeacherSubjectID);

            DbContext.SaveChanges(); // Save changes
            return Ok(teacherSubjectEntity); // Return HTTP 200 with deleted entity
        }
    }
}