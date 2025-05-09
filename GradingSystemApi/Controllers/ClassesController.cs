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
        private readonly enrollmentDbContext dbContext;
        public ClassesController(enrollmentDbContext dbContext)
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
        [Route("{Class_ID}")]
        public IActionResult getClassesByID(int Class_ID)
        {
            var class_ID = dbContext.Classes.Find(Class_ID);
            if (class_ID is null)
            {
                return NotFound();
            }
            return Ok(class_ID);
        }

        [HttpPost]
        public IActionResult addClasses(ClassesDto addClasses)
        {
            if (addClasses == null)
            {
                return BadRequest("Class cannot be null");
            }
            var classEntity = new Classes()
            {
                classID = 0, // Assign a default value for the required property
                teacherID = addClasses.teacherID,
                Schedule = addClasses.Schedule,
                subjectCode = addClasses.subjectCode
            };
            dbContext.Add(classEntity);
            dbContext.SaveChanges();
            return Ok(classEntity);
        }

        [HttpPut]
        [Route("{Class_ID}")]
        public IActionResult updateCourses(int Class_ID, ClassesDto updateClassesDto)
        {
            if (updateClassesDto == null)
            {
                return BadRequest("Class cannot be null");
            }
            var classEntity = dbContext.Classes.Find(Class_ID);
            if (classEntity == null)
            {
                return NotFound();
            }
            classEntity.classID = Class_ID;
            classEntity.teacherID = updateClassesDto.teacherID;
            classEntity.Schedule = updateClassesDto.Schedule;
            classEntity.subjectCode = updateClassesDto.subjectCode;
            dbContext.SaveChanges();
            return Ok(classEntity);
        }
        [HttpDelete]
        [Route("{Class_ID}")]
        public IActionResult deleteCourses(int Class_ID)
        {
            var classes = dbContext.Classes.Find(Class_ID);
            if (classes == null)
            {
                return NotFound();
            }
            dbContext.Remove(classes);
            dbContext.SaveChanges();
            return Ok(classes);
        }
    }
}
