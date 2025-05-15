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
        private readonly GradingDbContext DbContext;

        public EnrollmentController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult AllEnrollment()
        {
            var Enrollment = DbContext.Enrollment
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
            var EnrollmentEntity = DbContext.Enrollment.Find(EnrollmentID);
            if(EnrollmentEntity == null)
            {
                return NotFound();
            }
            DbContext.SaveChanges();
            var EnrollmentWithDetails = DbContext.Enrollment
                .Include(s => s.Student)
                .Include(c => c.CourseID)
                .Include(t => t.Term)
                .FirstOrDefault(e => e.EnrollmentID == EnrollmentEntity.EnrollmentID);
            return Ok(EnrollmentWithDetails);
        }


        [HttpPost]
        public IActionResult AddEnrollment(EnrollmentDto AddEnrollment)
        {
            var ExistStudent = DbContext.Student.Any(s => s.StudentID == AddEnrollment.StudentID);
            if (!ExistStudent)
            {
                return BadRequest($"Student with code {AddEnrollment.CourseID} does not exist");
            }

            var ExistCourse = DbContext.Course.Any(s => s.CourseID == AddEnrollment.CourseID);
            if (!ExistCourse)
            {
                return BadRequest($"Student with code {AddEnrollment.CourseID} does not exist");
            }

            var ExistTerm = DbContext.Term.Any(t => t.TermID == AddEnrollment.TermID);
            if(!ExistTerm)
            {
                return BadRequest($"Term with code {AddEnrollment.TermID} does not exist");
            }

            var EnrollmentEntity = new Enrollment()
            {
                StudentID = AddEnrollment.StudentID,
                CourseID = AddEnrollment.CourseID,
                TermID = AddEnrollment.TermID,
                EnrollmentStatus = AddEnrollment.EnrollmentStatus
            };

            DbContext.Enrollment.Add(EnrollmentEntity);
            DbContext.SaveChanges();

            var CreatedEnrollment = DbContext.Enrollment
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

            var enrollmentEntity = DbContext.Enrollment.Find(EnrollmentID);
            if (enrollmentEntity == null)
            {
                return NotFound($"Enrollment with ID {EnrollmentID} not found");
            }
            enrollmentEntity.StudentID = UpdateEnrollment.StudentID;
            enrollmentEntity.CourseID = UpdateEnrollment.CourseID;
            enrollmentEntity.TermID = UpdateEnrollment.TermID;
            enrollmentEntity.EnrollmentStatus = UpdateEnrollment.EnrollmentStatus;

            DbContext.SaveChanges();

            // Fetch the updated enrollment with related entities
            var updatedEnrollment = DbContext.Enrollment
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
            var EnrollmentEntity = DbContext.Enrollment.Find(EnrollmentID);
            if(EnrollmentEntity == null)
            {
                return NotFound();
            }

            DbContext.Remove(EnrollmentEntity);

            DbContext.SaveChanges();

            var DeletedEnrollment = DbContext.Enrollment
                .Include(s => s.Student)
                .Include(c => c.CourseID)
                .Include(t => t.Term)
                .FirstOrDefault(e => e.EnrollmentID == EnrollmentID);

            return Ok(DeletedEnrollment);
        }
    }
}
