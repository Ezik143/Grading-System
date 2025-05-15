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
        private readonly GradingDbContext DbContext;

        public CourseSubjectController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult GetAllCourseSubject()
        {
            var CourseSubject = DbContext.CourseSubject
                .Include(cs => cs.Course)  // This requires you to add navigation property
                .Include(cs => cs.Subject) // This requires you to add navigation property
                .ToList();
            return Ok(CourseSubject);
        }

        [HttpGet]
        [Route("{courseSubjectId}")]
        public IActionResult GetCourseSubjectById(int courseSubjectId)
        {

            var courseSubject = DbContext.CourseSubject
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
        public IActionResult AddCourseSubject(CourseSubjectDto AddCourseSubject)
        {
            var ExistCourse = DbContext.CourseSubject.Any(c => c.CourseID == AddCourseSubject.CourseID);
            if (!ExistCourse)
            {
                return BadRequest($"Course with code {AddCourseSubject.CourseID} does not exist");
            }

            var subjectExists = DbContext.Subject.Any(s => s.SubjectCode == AddCourseSubject.SubjectCode);
            if (!subjectExists)
            {
                return BadRequest($"Subject with code {AddCourseSubject.SubjectCode} does not exist");
            }

            var courseSubjectEntity = new CourseSubject
            {
                CourseID = AddCourseSubject.CourseID,
                SubjectCode = AddCourseSubject.SubjectCode
            };

            DbContext.CourseSubject.Add(courseSubjectEntity);
            DbContext.SaveChanges();

            // Return the created entity with its relations
            var createdEntity = DbContext.CourseSubject
                .Include(cs => cs.Course)  // This requires you to add navigation property
                .Include(cs => cs.Subject) // This requires you to add navigation property
                .FirstOrDefault(cs => cs.CourseSubjectID == courseSubjectEntity.CourseSubjectID);

            return Ok(createdEntity);
        }

        [HttpPut]
        [Route("{courseSubjectId}")]
        public IActionResult UpdateCourseSubject(int courseSubjectId, CourseSubjectDto UpdateCourseSubject)
        {
            var courseSubjectEntity = DbContext.CourseSubject.Find(courseSubjectId);
            if (courseSubjectEntity == null)
            {
                return NotFound();
            }

            var ExistCourse = DbContext.CourseSubject.Any(c => c.CourseID == UpdateCourseSubject.CourseID);
            if (!ExistCourse)
            {
                return BadRequest($"Course with code {UpdateCourseSubject.CourseID} does not exist");
            }

            var subjectExists = DbContext.Subject.Any(s => s.SubjectCode == UpdateCourseSubject.SubjectCode);
            if (!subjectExists)
            {
                return BadRequest($"Subject with code {UpdateCourseSubject.SubjectCode} does not exist");
            }

            courseSubjectEntity.CourseID = UpdateCourseSubject.CourseID;
            courseSubjectEntity.SubjectCode = UpdateCourseSubject.SubjectCode;

            DbContext.SaveChanges();

            // Return the updated entity with its relations
            var updatedEntity = DbContext.CourseSubject
                .Include(cs => cs.Course)  // This requires you to add navigation property
                .Include(cs => cs.Subject) // This requires you to add navigation property
                .FirstOrDefault(cs => cs.CourseSubjectID == courseSubjectId);

            return Ok(updatedEntity);
        }

        [HttpDelete]
        [Route("{CourseSubjectId}")]
        public IActionResult DeleteCourseSubject(int CourseSubjectId)
        {
            var courseSubjectEntity = DbContext.CourseSubject.Find(CourseSubjectId);
            if (courseSubjectEntity == null)
            {
                return NotFound();
            }

            DbContext.CourseSubject.Remove(courseSubjectEntity);
            DbContext.SaveChanges();

            var deletedEntity = DbContext.CourseSubject
                .Include(cs => cs.Course)
                .Include(s => s.Subject)
                .FirstOrDefault(c => c.CourseSubjectID == courseSubjectEntity.CourseSubjectID);

            return Ok(courseSubjectEntity);
        }
    }
}