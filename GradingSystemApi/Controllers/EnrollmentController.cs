using GradingSystemApi.Models.addDto;
using GradingSystemApi.Models.Dto;
using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;

namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly EnrollmentDbContext dbContext;

        public EnrollmentController(EnrollmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult AllEnrollment()
        {
            var Enrollment = dbContext.Enrollments
                .Include(s => s.Student)
                .Include(c => c.Course)
                .Include(t => t.Term)
                .ToList();
            return Ok(Enrollment);
        }

        [HttpGet]
        [Route("{EnrollmentID}")]
        public IActionResult EnrollmentByID(int EnrollmentID)
        {
            var EnrollmentEntity = dbContext.Enrollments.Find(EnrollmentID);
            if(EnrollmentEntity == null)
            {
                return NotFound();
            }
            dbContext.SaveChanges();
            var EnrollmentWithDetails = dbContext.Enrollments
                .Include(s => s.Student)
                .Include(c => c.CourseID)
                .Include(t => t.Term)
                .FirstOrDefault(e => e.EnrollmentID == EnrollmentEntity.EnrollmentID);
            return Ok(EnrollmentWithDetails);
        }


        [HttpPost]
        public IActionResult AddEnrollment(EnrollmentDto AddEnrollment)
        {
            if(AddEnrollment == null)
            {
                return BadRequest("Enrollment cannot be null");
            }

            var ExistStudent = dbContext.Enrollments.Any(s => s.StudentID == AddEnrollment.StudentID);
            if (!ExistStudent)
            {
                return BadRequest($"Enrollment with code {AddEnrollment.StudentID} does not exist");
            }

            var ExistCourse = dbContext.Enrollments.Any(c => c.CourseID == AddEnrollment.CourseID);
            if (!ExistCourse)
            {
                return BadRequest($"Enrollment with code {AddEnrollment.CourseID} does not exist");
            }

            var ExistTerm = dbContext.Enrollments.Any(t => t.TermID == AddEnrollment.TermID);
            if (!ExistTerm)
            {
                return BadRequest($"Enrollment with code {AddEnrollment.TermID} does not exist");
            }

            var EnrollmentEntity = new Enrollment()
            {
                StudentID = AddEnrollment.StudentID,
                CourseID = AddEnrollment.CourseID,
                TermID = AddEnrollment.TermID,
                EnrollmentStatus = AddEnrollment.EnrollmentStatus
            };

            dbContext.Enrollments.Add(EnrollmentEntity);
            dbContext.SaveChanges();

            var CreatedEnrollment = dbContext.Enrollments
                .Include(s => s.Student)
                .Include(c => c.Course)
                .Include(t => t.Term)
                .FirstOrDefault(e => e.EnrollmentID == EnrollmentEntity.EnrollmentID);

            return Ok(CreatedEnrollment);
        }

        [HttpPut]
        [Route("{EnrollmentID}")]
        public IActionResult UpdateEnrollment(int EnrollmentID, EnrollmentDto UpdateEnrollment)
        {
            if (UpdateEnrollment == null)
            {
                return BadRequest("Update enrollment data is required");
            }

            var enrollmentEntity = dbContext.Enrollments.Find(EnrollmentID);
            if (enrollmentEntity == null)
            {
                return NotFound($"Enrollment with ID {EnrollmentID} not found");
            }

            // Check if referenced entities exist
            var studentExists = dbContext.Students.Any(s => s.StudentID == UpdateEnrollment.StudentID);
            if (!studentExists)
            {
                return BadRequest($"Student with ID {UpdateEnrollment.StudentID} does not exist");
            }

            var courseExists = dbContext.Courses.Any(c => c.CourseID == UpdateEnrollment.CourseID);
            if (!courseExists)
            {
                return BadRequest($"Course with ID {UpdateEnrollment.CourseID} does not exist");
            }

            var termExists = dbContext.Terms.Any(t => t.TermID == UpdateEnrollment.TermID);
            if (!termExists)
            {
                return BadRequest($"Term with ID {UpdateEnrollment.TermID} does not exist");
            }

            // Update enrollment properties
            enrollmentEntity.StudentID = UpdateEnrollment.StudentID;
            enrollmentEntity.CourseID = UpdateEnrollment.CourseID;
            enrollmentEntity.TermID = UpdateEnrollment.TermID;
            enrollmentEntity.EnrollmentStatus = UpdateEnrollment.EnrollmentStatus;

            dbContext.SaveChanges();

            // Fetch the updated enrollment with related entities
            var updatedEnrollment = dbContext.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Include(e => e.Term)
                .FirstOrDefault(e => e.EnrollmentID == EnrollmentID);

            return Ok(updatedEnrollment);
        }


        [HttpDelete]
        [Route("{EnrollmentID}")]
        public IActionResult DeleteEnrollment(int EnrollmentID)
        {
            var EnrollmentEntity = dbContext.Enrollments.Find(EnrollmentID);
            if(EnrollmentEntity == null)
            {
                return NotFound();
            }

            dbContext.Remove(EnrollmentEntity);

            dbContext.SaveChanges();

            var DeletedEnrollment = dbContext.Enrollments
                .Include(s => s.Student)
                .Include(c => c.CourseID)
                .Include(t => t.Term)
                .FirstOrDefault(e => e.EnrollmentID == EnrollmentID);

            return Ok(DeletedEnrollment);
        }
    }
}
