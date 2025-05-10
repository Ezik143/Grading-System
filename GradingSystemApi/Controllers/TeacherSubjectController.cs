using GradingSystemApi.Models.Entities;
using GradingSystemApi.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;

namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSubjectController : ControllerBase
    {
        private readonly EnrollmentDbContext DbContext;

        public TeacherSubjectController(EnrollmentDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult GetAllTeacherSubject()
        {
            var teacherSubjects = DbContext.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Subject)
                .ToList();
            return Ok(teacherSubjects);
        }

        [HttpGet]
        [Route("{TeacherSubjectID}")]
        public IActionResult GetTeacherSubjectByID(int TeacherSubjectID)
        {
            var teacherSubjectEntity = DbContext.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Subject)
                .FirstOrDefault(ts => ts.TeacherSubjectID == TeacherSubjectID);

            if (teacherSubjectEntity == null)
            {
                return NotFound();
            }
            return Ok(teacherSubjectEntity);
        }

        [HttpPost]
        public IActionResult AddTeacherSubject(TeacherSubjectDto addTeacherSubject)
        {
            if (addTeacherSubject == null)
            {
                return BadRequest("TeacherSubject Cannot be null");
            }

            // Validate that the Teacher exists
            var teacherExists = DbContext.Teachers.Any(t => t.TeacherID == addTeacherSubject.TeacherID);
            if (!teacherExists)
            {
                return BadRequest($"Teacher with ID {addTeacherSubject.TeacherID} does not exist");
            }

            // Validate that the Subject exists
            var subjectExists = DbContext.Subjects.Any(s => s.SubjectCode == addTeacherSubject.SubjectCode);
            if (!subjectExists)
            {
                return BadRequest($"Subject with code {addTeacherSubject.SubjectCode} does not exist");
            }

            var teacherSubjectEntity = new TeacherSubject()
            {
                TeacherID = addTeacherSubject.TeacherID,
                SubjectCode = addTeacherSubject.SubjectCode
            };

            DbContext.Add(teacherSubjectEntity);
            DbContext.SaveChanges();

            // Return the created entity with its relations
            var createdEntity = DbContext.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Subject)
                .FirstOrDefault(ts => ts.TeacherSubjectID == teacherSubjectEntity.TeacherSubjectID);

            return Ok(createdEntity);
        }

        [HttpPut]
        [Route("{TeacherSubjectID}")]
        public IActionResult UpdateTeacherSubject(int TeacherSubjectID, TeacherSubjectDto teacherSubject)
        {
            if (teacherSubject == null)
            {
                return BadRequest("TeacherSubject cannot be null");
            }

            var teacherSubjectEntity = DbContext.TeacherSubjects.Find(TeacherSubjectID);
            if (teacherSubjectEntity == null)
            {
                return NotFound();
            }

            // Validate that the Teacher exists
            var teacherExists = DbContext.Teachers.Any(t => t.TeacherID == teacherSubject.TeacherID);
            if (!teacherExists)
            {
                return BadRequest($"Teacher with ID {teacherSubject.TeacherID} does not exist");
            }

            // Validate that the Subject exists
            var subjectExists = DbContext.Subjects.Any(s => s.SubjectCode == teacherSubject.SubjectCode);
            if (!subjectExists)
            {
                return BadRequest($"Subject with code {teacherSubject.SubjectCode} does not exist");
            }

            teacherSubjectEntity.TeacherID = teacherSubject.TeacherID;
            teacherSubjectEntity.SubjectCode = teacherSubject.SubjectCode;

            DbContext.SaveChanges();

            // Return the updated entity with its relations
            var updatedEntity = DbContext.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Subject)
                .FirstOrDefault(ts => ts.TeacherSubjectID == TeacherSubjectID);

            return Ok(updatedEntity);
        }

        [HttpDelete]
        [Route("{TeacherSubjectID}")]
        public IActionResult DeleteTeacherSubject(int TeacherSubjectID)
        {
            var teacherSubjectEntity = DbContext.TeacherSubjects.Find(TeacherSubjectID);
            if (teacherSubjectEntity == null)
            {
                return NotFound();
            }
            DbContext.TeacherSubjects.Remove(teacherSubjectEntity);

            var deletedEntity = DbContext.TeacherSubjects
                .Include(t => t.Teacher)
                .Include(s => s.Subject)
                .FirstOrDefault(c => c.TeacherSubjectID == teacherSubjectEntity.TeacherSubjectID);

            DbContext.SaveChanges();
            return Ok(teacherSubjectEntity);
        }
    }
}