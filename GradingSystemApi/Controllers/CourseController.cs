using Team_Yeri_enrollment_system.GradingLibrary.Models;
using Team_Yeri_enrollment_system.GradingLibrary.Data;
using GradingSystemApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class courseController : ControllerBase
    {
        private readonly enrollmentDbContext dbContext;

        public courseController(enrollmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult getCourse()
        {
            var courses = dbContext.Courses
                .Include(c => c.CourseSubjects) // Include related CourseSubjects entity
                .ToList();
            return Ok(courses);
        }

        [HttpGet]
        [Route("{Course_ID}")]
        public IActionResult getCourse_ID(int Course_ID)
        {
            var course_ID = dbContext.Courses.Find(Course_ID);
            if(course_ID is null)
            {
                return NotFound();
            }
            return Ok(course_ID);
        }

        [HttpPost]
        public IActionResult AddCourses(CoursesDto addCourse)
        {
            if (addCourse == null)
            {
                return BadRequest("Course cannot be null");
            }
            var courseEntity = new Course()
            {
                courseID = 0,
                courseName = addCourse.courseName,
                Department = addCourse.Department,
                totalUnits = addCourse.totalUnits
            };
            dbContext.Add(courseEntity);
            dbContext.SaveChanges();
            return Ok(courseEntity);
        }
        [HttpPut]
        [Route("{Course_ID}")]
        public IActionResult updateCourses(int Course_ID,CoursesDto updateCoursesDto)
        {
            var course = dbContext.Courses.Find(Course_ID);
            if (course == null)
            {
                return NotFound();
            }

            course.courseName = updateCoursesDto.courseName;
            course.Department = updateCoursesDto.Department;
            course.totalUnits = updateCoursesDto.totalUnits;

            dbContext.SaveChanges();
            return Ok(course);
        }

        [HttpDelete]
        [Route("{Course_ID}")]
        public IActionResult deleteCourses(int Course_ID)
        {
            var course = dbContext.Courses.Find(Course_ID);
            if (course == null)
            {
                return NotFound();
            } 
            dbContext.Courses.Remove(course);
            dbContext.SaveChanges();
            return Ok(course);
        }
    }
}
