using GradingSystemApi.Models.addDto;
using GradingSystemApi.Models.Dto;
using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;

namespace GradingSystemApi.Controllers
{
    // Route for this controller: api/Enrollment
    [Route("api/[controller]")]
    // Marks this as an API controller
    [ApiController]
    // Controller for managing Enrollment entities
    public class EnrollmentController : ControllerBase
    {
        // The database context for accessing data
        private readonly GradingDbContext DbContext;

        // Constructor for dependency injection of the context
        public EnrollmentController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        // GET: api/Enrollment
        // Returns all enrollments, including related student, course, and term details
        [HttpGet]
        public IActionResult AllEnrollment()
        {
            var Enrollment = DbContext.Enrollment
                .ToList();               // Convert to a list
            return Ok(Enrollment);       // Return HTTP 200 with the list
        }

        // GET: api/Enrollment/{EnrollmentID}
        // Returns a specific enrollment by its ID, including related entities
        [HttpGet]
        [Route("{EnrollmentID}")]
        public IActionResult EnrollmentByID(int EnrollmentID)
        {
            var EnrollmentEntity = DbContext.Enrollment.Find(EnrollmentID); // Find by primary key
            if (EnrollmentEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            DbContext.SaveChanges(); // (Unusual for GET; can be removed)
            var EnrollmentWithDetails = DbContext.Enrollment
                .FirstOrDefault(e => e.EnrollmentID == EnrollmentEntity.EnrollmentID);
            return Ok(EnrollmentWithDetails); // Return HTTP 200 with details
        }

        // POST: api/Enrollment
        // Adds a new enrollment, requires valid student, course, and term IDs
        [HttpPost]
        public IActionResult AddEnrollment(EnrollmentDto AddEnrollment)
        {
            // Check if the student exists
            var ExistStudent = DbContext.Student.Any(s => s.StudentID == AddEnrollment.StudentID);
            if (!ExistStudent)
            {
                // Return 400 if student does not exist
                return BadRequest($"Student with code {AddEnrollment.CourseID} does not exist");
            }

            // Check if the course exists
            var ExistCourse = DbContext.Course.Any(s => s.CourseID == AddEnrollment.CourseID);
            if (!ExistCourse)
            {
                // Return 400 if course does not exist
                return BadRequest($"Student with code {AddEnrollment.CourseID} does not exist");
            }

            // Check if the term exists
            var ExistTerm = DbContext.Term.Any(t => t.TermID == AddEnrollment.TermID);
            if (!ExistTerm)
            {
                // Return 400 if term does not exist
                return BadRequest($"Term with code {AddEnrollment.TermID} does not exist");
            }

            // Create new Enrollment entity from DTO
            var EnrollmentEntity = new Enrollment()
            {
                StudentID = AddEnrollment.StudentID,
                CourseID = AddEnrollment.CourseID,
                TermID = AddEnrollment.TermID,
                EnrollmentStatus = AddEnrollment.EnrollmentStatus
            };

            DbContext.Enrollment.Add(EnrollmentEntity); // Add to context
            DbContext.SaveChanges();                    // Save to database

            // Retrieve the created enrollment with related entities
            var CreatedEnrollment = DbContext.Enrollment
                .FirstOrDefault(e => e.EnrollmentID == EnrollmentEntity.EnrollmentID);

            return Ok(CreatedEnrollment); // Return HTTP 200 with created enrollment
        }

        // PUT: api/Enrollment/{EnrollmentID}
        // Updates an existing enrollment
        [HttpPut]
        [Route("{EnrollmentID}")]
        public IActionResult UpdateEnrollment(int EnrollmentID, EnrollmentDto UpdateEnrollment)
        {
            // Find the enrollment entity to update
            var enrollmentEntity = DbContext.Enrollment.Find(EnrollmentID);
            if (enrollmentEntity == null)
            {
                // Return 404 if not found
                return NotFound($"Enrollment with ID {EnrollmentID} not found");
            }
            // Update properties
            enrollmentEntity.StudentID = UpdateEnrollment.StudentID;
            enrollmentEntity.CourseID = UpdateEnrollment.CourseID;
            enrollmentEntity.TermID = UpdateEnrollment.TermID;
            enrollmentEntity.EnrollmentStatus = UpdateEnrollment.EnrollmentStatus;

            DbContext.SaveChanges(); // Save changes

            // Fetch the updated enrollment with related entities
            var updatedEnrollment = DbContext.Enrollment
                .FirstOrDefault(e => e.EnrollmentID == EnrollmentID);

            return Ok(updatedEnrollment); // Return HTTP 200 with updated enrollment
        }

        // DELETE: api/Enrollment/{EnrollmentID}
        // Deletes an enrollment by its ID
        [HttpDelete]
        [Route("{EnrollmentID}")]
        public IActionResult DeleteEnrollment(int EnrollmentID)
        {
            // Find the enrollment entity to delete
            var EnrollmentEntity = DbContext.Enrollment.Find(EnrollmentID);
            if (EnrollmentEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }

            DbContext.Remove(EnrollmentEntity); // Remove from context
            DbContext.SaveChanges();            // Save changes

            // Optionally retrieve the deleted enrollment (will be null)
            var DeletedEnrollment = DbContext.Enrollment
                .FirstOrDefault(e => e.EnrollmentID == EnrollmentID);

            return Ok(DeletedEnrollment); // Return HTTP 200 with deleted enrollment
        }
    }
}
