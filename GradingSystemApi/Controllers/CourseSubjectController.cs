using GradingSystemApi.Models.Dto;
using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;
using Team_Yeri_enrollment_system.GradingLibrary.Models;

namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSubjectController : ControllerBase
    {
        private readonly EnrollmentDbContext dbContext;

        public CourseSubjectController(EnrollmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllCourseSubjects()
        {
            var courseSubjects = dbContext.CourseSubjects
                .Include(cs => cs.Course)  // This requires you to add navigation property
                .Include(cs => cs.Subject) // This requires you to add navigation property
                .ToList();
            return Ok(courseSubjects);
        }

        [HttpGet]
        [Route("{courseSubjectId}")]
        public IActionResult GetCourseSubjectById(int courseSubjectId)
        {
            var courseSubject = dbContext.CourseSubjects
                .Include(cs => cs.Course)  // This requires you to add navigation property
                .Include(cs => cs.Subject) // This requires you to add navigation property
                .FirstOrDefault(cs => cs.CourseSubjectID == courseSubjectId);

            if (courseSubject == null)
            {
                return NotFound();
            }

            return Ok(courseSubject);
        }

        [HttpPost]
        public IActionResult AddCourseSubject(CourseSubjectDto courseSubjectDto)
        {
            if (courseSubjectDto == null)
            {
                return BadRequest("CourseSubject cannot be null");
            }

            // Validate that the Course exists
            var courseExists = dbContext.Courses.Any(c => c.CourseID == courseSubjectDto.CourseID);
            if (!courseExists)
            {
                return BadRequest($"Course with ID {courseSubjectDto.CourseID} does not exist");
            }

            // Validate that the Subject exists
            var subjectExists = dbContext.Subjects.Any(s => s.SubjectCode == courseSubjectDto.SubjectCode);
            if (!subjectExists)
            {
                return BadRequest($"Subject with code {courseSubjectDto.SubjectCode} does not exist");
            }

            var courseSubjectEntity = new CourseSubject
            {
                CourseID = courseSubjectDto.CourseID,
                SubjectCode = courseSubjectDto.SubjectCode
            };

            dbContext.CourseSubjects.Add(courseSubjectEntity);
            dbContext.SaveChanges();

            // Return the created entity with its relations
            var createdEntity = dbContext.CourseSubjects
                .Include(cs => cs.Course)  // This requires you to add navigation property
                .Include(cs => cs.Subject) // This requires you to add navigation property
                .FirstOrDefault(cs => cs.CourseSubjectID == courseSubjectEntity.CourseSubjectID);

            return Ok(createdEntity);
        }

        [HttpPut]
        [Route("{courseSubjectId}")]
        public IActionResult UpdateCourseSubject(int courseSubjectId, CourseSubjectDto courseSubjectDto)
        {
            if (courseSubjectDto == null)
            {
                return BadRequest("CourseSubject cannot be null");
            }

            var courseSubjectEntity = dbContext.CourseSubjects.Find(courseSubjectId);
            if (courseSubjectEntity == null)
            {
                return NotFound();
            }

            // Validate that the Course exists
            var courseExists = dbContext.Courses.Any(c => c.CourseID == courseSubjectDto.CourseID);
            if (!courseExists)
            {
                return BadRequest($"Course with ID {courseSubjectDto.CourseID} does not exist");
            }

            // Validate that the Subject exists
            var subjectExists = dbContext.Subjects.Any(s => s.SubjectCode == courseSubjectDto.SubjectCode);
            if (!subjectExists)
            {
                return BadRequest($"Subject with code {courseSubjectDto.SubjectCode} does not exist");
            }

            courseSubjectEntity.CourseID = courseSubjectDto.CourseID;
            courseSubjectEntity.SubjectCode = courseSubjectDto.SubjectCode;

            dbContext.SaveChanges();

            // Return the updated entity with its relations
            var updatedEntity = dbContext.CourseSubjects
                .Include(cs => cs.Course)  // This requires you to add navigation property
                .Include(cs => cs.Subject) // This requires you to add navigation property
                .FirstOrDefault(cs => cs.CourseSubjectID == courseSubjectId);

            return Ok(updatedEntity);
        }

        [HttpDelete]
        [Route("{CourseSubjectId}")]
        public IActionResult DeleteCourseSubject(int CourseSubjectId)
        {
            var courseSubjectEntity = dbContext.CourseSubjects.Find(CourseSubjectId);
            if (courseSubjectEntity == null)
            {
                return NotFound();
            }

            dbContext.CourseSubjects.Remove(courseSubjectEntity);
            dbContext.SaveChanges();

            var deletedEntity = dbContext.CourseSubjects
                .Include(cs => cs.Course)
                .Include(s => s.Subject)
                .FirstOrDefault(c => c.CourseSubjectID == courseSubjectEntity.CourseSubjectID);

            return Ok(courseSubjectEntity);
        }
    }
}