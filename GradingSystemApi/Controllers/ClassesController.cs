using Team_Yeri_enrollment_system.GradingLibrary.Models;
using Team_Yeri_enrollment_system.GradingLibrary.Data;
using GradingSystemApi.Models.addDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly EnrollmentDbContext dbContext;
        public ClassesController(EnrollmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult getAllClasses()
        {
            var classes = dbContext.Classes
                .Include(c => c.Teacher) // Include related Teacher entity
                .Include(c => c.Subject) // Include related Subject entity
                .ToList();
            return Ok(classes);
        }

        [HttpGet]
        [Route("{ClassID}")]
        public IActionResult getClassesByID(int ClassID)
        {
            var classEntity = dbContext.Classes.Find(ClassID);
            if (classEntity is null)
            {
                return NotFound();
            }
            dbContext.SaveChanges();
            var classWithDetails = dbContext.Classes
                .Include(c => c.Teacher) // Include related Teacher entity
                .Include(c => c.Subject) // Include related Subject entity
                .FirstOrDefault(c => c.ClassID == classEntity.ClassID);
            return Ok(classWithDetails);
        }

        [HttpPost]
        public IActionResult addClasses(ClassesDto addClasses)
        {
            if (addClasses == null)
            {
                return BadRequest("Class cannot be null");
            }


            var existTeacher = dbContext.Teachers.Any(t => t.TeacherID == addClasses.TeacherID);
            if (!existTeacher)
            {
                return BadRequest($"Teacher with ID {addClasses.TeacherID} does not exist");
            }

            var existSubject = dbContext.Subjects.Any(s => s.SubjectCode == addClasses.SubjectCode);
            if (!existSubject)
            {
                return BadRequest($"Subject with code {addClasses.SubjectCode} does not exist");
            }

            var classEntity = new Classes()
            {
                TeacherID = addClasses.TeacherID,
                Schedule = addClasses.Schedule,
                SubjectCode = addClasses.SubjectCode
            };
            dbContext.Add(classEntity);
            dbContext.SaveChanges();

            var createdClass = dbContext.Classes
            .Include(c => c.Teacher)
            .Include(c => c.Subject)
            .FirstOrDefault(c => c.ClassID == classEntity.ClassID);

            return Ok(createdClass);

        }

        [HttpPut]
        [Route("{ClassID}")]
        public IActionResult updateCourses(int ClassID, ClassesDto updateClassesDto)
        {
            if (updateClassesDto == null)
            {
                return BadRequest("Class cannot be null");
            }

            var classEntity = dbContext.Classes.Find(ClassID);
            if (classEntity == null)
            {
                return NotFound();
            }

            var teacherExist = dbContext.Teachers.Any(t => t.TeacherID == updateClassesDto.TeacherID);
            if (!teacherExist)
            {
                return BadRequest($"Teacher with ID {updateClassesDto.TeacherID} does not exist");
            }

            var subjectExist = dbContext.Subjects.Any(s => s.SubjectCode == updateClassesDto.SubjectCode);
            if (!subjectExist)
            {
                return BadRequest($"Subject with code {updateClassesDto.SubjectCode} does not exist");
            }

            // Update properties
            classEntity.TeacherID = updateClassesDto.TeacherID;
            classEntity.Schedule = updateClassesDto.Schedule;
            classEntity.SubjectCode = updateClassesDto.SubjectCode;

            dbContext.SaveChanges();

            var updatedClass = dbContext.Classes
                .Include(c => c.Teacher) // Include related Teacher entity
                .Include(c => c.Subject) // Include related Subject entity
                .FirstOrDefault(c => c.ClassID == classEntity.ClassID);

            return Ok(updatedClass);
        }
        [HttpDelete]
        [Route("{ClassID}")]
        public IActionResult deleteCourses(int ClassID )
        {
            var classes = dbContext.Classes.Find(ClassID );
            if (classes == null)
            {
                return NotFound();
            }
            dbContext.Remove(classes);

            dbContext.SaveChanges();

            var deletedClass = dbContext.Classes
                .Include(c => c.Teacher) // Include related Teacher entity
                .Include(c => c.Subject) // Include related Subject entity
                .FirstOrDefault(c => c.ClassID == classes.ClassID);

            return Ok(classes);
        }
    }
}
