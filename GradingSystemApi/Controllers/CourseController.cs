using Team_Yeri_enrollment_system.GradingLibrary.Models;
using Team_Yeri_enrollment_system.GradingLibrary.Data;
using GradingSystemApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly EnrollmentDbContext dbContext;

        public CourseController(EnrollmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult getCourse()
        {
            var courses = dbContext.Courses
                .ToList();
            return Ok(courses);
        }

        [HttpGet]
        [Route("{CourseID}")]
        public IActionResult GetCourseByID(int CourseID)
        {
            var CourseEntity = dbContext.Courses.Find(CourseID);
            if(CourseEntity is null)
            {
                return NotFound();
            }
            return Ok(CourseEntity);
        }

        [HttpPost]
        public IActionResult AddCourses(CoursesDto AddCourse)
        {
            if (AddCourse == null)
            {
                return BadRequest("Course cannot be null");
            }
            var courseEntity = new Course()
            {
                CourseName = AddCourse.CourseName,
                Department = AddCourse.Department,
                TotalUnits = AddCourse.TotalUnits
            };
            dbContext.Add(courseEntity);
            dbContext.SaveChanges();

            var CreatedCourse = dbContext.Courses
                .FirstOrDefault(c => c.CourseID == courseEntity.CourseID);

            return Ok(courseEntity);
        }

        [HttpPut]
        [Route("{CourseID}")]
        public IActionResult updateCourses(int CourseID, CoursesDto UpdateCoursesDto)
        {
            var course = dbContext.Courses.Find(CourseID);
            if (course == null)
            {
                return NotFound();
            }

            //check if a course with the same name already exists
            var subjectExists = dbContext.Courses.Any(s => s.CourseName == UpdateCoursesDto.CourseName);
            if (subjectExists)
            {
                return BadRequest("A course with the same name already exists.");
            }

            course.CourseName = UpdateCoursesDto.CourseName;
            course.Department = UpdateCoursesDto.Department;
            course.TotalUnits = UpdateCoursesDto.TotalUnits;

            dbContext.SaveChanges();

            var UpdatedCourse = dbContext.Courses
                .FirstOrDefault(c => c.CourseID == course.CourseID);

            return Ok(course);
        }

        [HttpDelete]
        [Route("{CourseID}")]
        public IActionResult deleteCourses(int CourseID)
        {
            var course = dbContext.Courses.Find(CourseID);
            if (course == null)
            {
                return NotFound();
            } 
            dbContext.Courses.Remove(course);
            dbContext.SaveChanges();

            var DeletedCourse = dbContext.Courses
                .FirstOrDefault(c => c.CourseID == course.CourseID);

            return Ok(course);
        }
    }
}
