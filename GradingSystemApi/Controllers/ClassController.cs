using Team_Yeri_enrollment_system.GradingLibrary.Models;
using Team_Yeri_enrollment_system.GradingLibrary.Data;
using GradingSystemApi.Models.addDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController (EnrollmentDbContext DbContext): ControllerBase
    {
        private readonly EnrollmentDbContext DbContext = DbContext;
      
        [HttpGet]
        public IActionResult GetAllClass()
        {
            var Class = DbContext.Class
                .Include(c => c.Teacher) // Include related Teacher entity
                .Include(c => c.Subject) // Include related Subject entity
                .ToList();
            return Ok(Class);
        }

        [HttpGet]
        [Route("{ClassID}")]
        public IActionResult GetClassByID(int ClassID)
        {
            var classEntity = DbContext.Class.Find(ClassID);
            if (classEntity is null)
            {
                return NotFound();
            }
            DbContext.SaveChanges();
            var ClassWithDetails = DbContext.Class
                .Include(c => c.Teacher) // Include related Teacher entity
                .Include(c => c.Subject) // Include related Subject entity
                .FirstOrDefault(c => c.ClassID == classEntity.ClassID);
            return Ok(ClassWithDetails);
        }

        [HttpPost]
        public IActionResult AddClass(ClassDto AddClass)
        {
            var ExistTeacher = DbContext.Teacher.Any(t => t.TeacherID == AddClass.TeacherID);
            if (!ExistTeacher)
            {
                return BadRequest($"Teacher with ID {AddClass.TeacherID} does not exist");
            }

            var ExistSubject = DbContext.Subject.Any(s => s.SubjectCode == AddClass.SubjectCode);
            if (!ExistSubject)
            {
                return BadRequest($"Subject with code {AddClass.SubjectCode} does not exist");
            }

            var ClassEntity = new Class()
            {
                TeacherID = AddClass.TeacherID,
                Schedule = AddClass.Schedule,
                SubjectCode = AddClass.SubjectCode
            };
            DbContext.Add(ClassEntity);
            DbContext.SaveChanges();

            var CreatedClass = DbContext.Class
            .Include(c => c.Teacher)
            .Include(c => c.Subject)
            .FirstOrDefault(c => c.ClassID == ClassEntity.ClassID);

            return Ok(CreatedClass);

        }

        [HttpPut]
        [Route("{ClassID}")]
        public IActionResult UpdateCourses(int ClassID, ClassDto UpdateClassDto)
        {
            var ClassEntity = DbContext.Class.Find(ClassID);
            if (ClassEntity == null)
            {
                return NotFound();
            }

            // Update properties
            ClassEntity.TeacherID = UpdateClassDto.TeacherID;
            ClassEntity.Schedule = UpdateClassDto.Schedule;
            ClassEntity.SubjectCode = UpdateClassDto.SubjectCode;

            DbContext.SaveChanges();

            var UpdatedClass = DbContext.Class
                .Include(c => c.Teacher) // Include related Teacher entity
                .Include(c => c.Subject) // Include related Subject entity
                .FirstOrDefault(c => c.ClassID == ClassEntity.ClassID);

            return Ok(UpdatedClass);
        }
        [HttpDelete]
        [Route("{ClassID}")]
        public IActionResult DeleteCourses(int ClassID )
        {
            var Class = DbContext.Class.Find(ClassID );
            if (Class == null)
            {
                return NotFound();
            }
            DbContext.Remove(Class);

            DbContext.SaveChanges();

            var DeletedClass = DbContext.Class
                .Include(c => c.Teacher) // Include related Teacher entity
                .Include(c => c.Subject) // Include related Subject entity
                .FirstOrDefault(c => c.ClassID == Class.ClassID);

            return Ok(Class);
        }
    }
}
