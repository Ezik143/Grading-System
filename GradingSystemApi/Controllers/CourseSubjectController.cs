using GradingSystemApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;
using Team_Yeri_enrollment_system.GradingLibrary.Models;

namespace GradingSystemApi.Controllers
{
    // Route for this controller: api/CourseSubject
    [Route("api/[controller]")]
    // Marks this as an API controller
    [ApiController]
    // Controller for managing CourseSubject entities
    public class CourseSubjectController : ControllerBase
    {
        // The database context for accessing data
        private readonly GradingDbContext DbContext;

        // Constructor for dependency injection of the context
        public CourseSubjectController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        // GET: api/CourseSubject
        // Returns all course-subject relationships, including related course and subject details
        [HttpGet]
        public IActionResult GetAllCourseSubject()
        {
            var CourseSubject = DbContext.CourseSubject
                .ToList();                 // Convert to a list
            return Ok(CourseSubject);      // Return HTTP 200 with the list
        }

        // GET: api/CourseSubject/{courseSubjectId}
        // Returns a specific course-subject relationship by its ID, including course and subject details
        [HttpGet]
        [Route("{courseSubjectId}")]
        public IActionResult GetCourseSubjectById(int courseSubjectId)
        {
            var courseSubject = DbContext.CourseSubject
                .Find(courseSubjectId); // Find by primary key

            if (courseSubject == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return Ok(courseSubject); // Return HTTP 200 with the entity
        }

        // POST: api/CourseSubject
        // Adds a new course-subject relationship
        [HttpPost]
        public IActionResult AddCourseSubject(CourseSubjectDto AddCourseSubject)
        {
            // Check if the course exists
            var ExistCourse = DbContext.CourseSubject.Any(c => c.CourseID == AddCourseSubject.CourseID);
            if (!ExistCourse)
            {
                // Return 400 if course does not exist
                return BadRequest($"Course with code {AddCourseSubject.CourseID} does not exist");
            }

            // Check if the subject exists
            var subjectExists = DbContext.Subject.Any(s => s.SubjectCode == AddCourseSubject.SubjectCode);
            if (!subjectExists)
            {
                // Return 400 if subject does not exist
                return BadRequest($"Subject with code {AddCourseSubject.SubjectCode} does not exist");
            }

            // Create new CourseSubject entity from DTO
            var courseSubjectEntity = new CourseSubject
            {
                CourseID = AddCourseSubject.CourseID,
                SubjectCode = AddCourseSubject.SubjectCode
            };

            DbContext.CourseSubject.Add(courseSubjectEntity); // Add to context
            DbContext.SaveChanges();                          // Save to database

            // Retrieve the created entity with its relations
            var createdEntity = DbContext.CourseSubject
                .FirstOrDefault(cs => cs.CourseSubjectID == courseSubjectEntity.CourseSubjectID);

            return Ok(createdEntity); // Return HTTP 200 with created entity
        }

        // PUT: api/CourseSubject/{courseSubjectId}
        // Updates an existing course-subject relationship
        [HttpPut]
        [Route("{courseSubjectId}")]
        public IActionResult UpdateCourseSubject(int courseSubjectId, CourseSubjectDto UpdateCourseSubject)
        {
            // Find the entity to update
            var courseSubjectEntity = DbContext.CourseSubject.Find(courseSubjectId);
            if (courseSubjectEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }

            // Check if the course exists
            var ExistCourse = DbContext.CourseSubject.Any(c => c.CourseID == UpdateCourseSubject.CourseID);
            if (!ExistCourse)
            {
                // Return 400 if course does not exist
                return BadRequest($"Course with code {UpdateCourseSubject.CourseID} does not exist");
            }

            // Check if the subject exists
            var subjectExists = DbContext.Subject.Any(s => s.SubjectCode == UpdateCourseSubject.SubjectCode);
            if (!subjectExists)
            {
                // Return 400 if subject does not exist
                return BadRequest($"Subject with code {UpdateCourseSubject.SubjectCode} does not exist");
            }

            // Update properties
            courseSubjectEntity.CourseID = UpdateCourseSubject.CourseID;
            courseSubjectEntity.SubjectCode = UpdateCourseSubject.SubjectCode;

            DbContext.SaveChanges(); // Save changes

            // Retrieve the updated entity with its relations
            var updatedEntity = DbContext.CourseSubject
                .FirstOrDefault(cs => cs.CourseSubjectID == courseSubjectId);

            return Ok(updatedEntity); // Return HTTP 200 with updated entity
        }

        // DELETE: api/CourseSubject/{CourseSubjectId}
        // Deletes a course-subject relationship by its ID
        [HttpDelete]
        [Route("{CourseSubjectId}")]
        public IActionResult DeleteCourseSubject(int CourseSubjectId)
        {
            // Find the entity to delete
            var courseSubjectEntity = DbContext.CourseSubject.Find(CourseSubjectId);
            if (courseSubjectEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }

            DbContext.CourseSubject.Remove(courseSubjectEntity); // Remove from context
            DbContext.SaveChanges();                             // Save changes

            // Optionally retrieve the deleted entity (will be null)
            var deletedEntity = DbContext.CourseSubject
                .FirstOrDefault(c => c.CourseSubjectID == courseSubjectEntity.CourseSubjectID);

            return Ok(courseSubjectEntity); // Return HTTP 200 with deleted entity
        }
    }
}