using Team_Yeri_enrollment_system.GradingLibrary.Models;
using Team_Yeri_enrollment_system.GradingLibrary.Data;
using GradingSystemApi.Models.addDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GradingSystemApi.Models.Dto;


namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly GradingDbContext DbContext;

        public CourseController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        [HttpGet]
        public IActionResult getCourse()
        {
            var Course = DbContext.Course
                .ToList();
            return Ok(Course);
        }

        [HttpGet]
        [Route("{CourseID}")]
        public IActionResult GetCourseByID(int CourseID)
        {
            var CourseEntity = DbContext.Course.Find(CourseID);
            if(CourseEntity is null)
            {
                return NotFound();
            }
            return Ok(CourseEntity);
        }

        [HttpPost]
        public IActionResult AddCourse(CourseDto AddCourse)
        {
            var courseEntity = new Course()
            {
                CourseName = AddCourse.CourseName,
                Department = AddCourse.Department,
                TotalUnits = AddCourse.TotalUnits
            };
            DbContext.Add(courseEntity);
            DbContext.SaveChanges();
            var CreatedCourse = DbContext.Course
                .FirstOrDefault(c => c.CourseID == courseEntity.CourseID);
            return Ok(courseEntity);
        }

        [HttpPut]
        [Route("{CourseID}")]
        public IActionResult updateCourse(int CourseID, CourseDto UpdateCourseDto)
        {
            var course = DbContext.Course.Find(CourseID);
            if (course == null)
            {
                return NotFound();
            }
            course.CourseName = UpdateCourseDto.CourseName;
            course.Department = UpdateCourseDto.Department;
            course.TotalUnits = UpdateCourseDto.TotalUnits;

            DbContext.SaveChanges();

            var UpdatedCourse = DbContext.Course
                .FirstOrDefault(c => c.CourseID == course.CourseID);

            return Ok(course);
        }

        [HttpDelete]
        [Route("{CourseID}")]
        public IActionResult DeleteCourse(int CourseID)
        {
            var course = DbContext.Course.Find(CourseID);
            if (course == null)
            {
                return NotFound();
            } 
            DbContext.Course.Remove(course);
            DbContext.SaveChanges();

            var DeletedCourse = DbContext.Course
                .FirstOrDefault(c => c.CourseID == course.CourseID);

            return Ok(course);
        }
    }
}
