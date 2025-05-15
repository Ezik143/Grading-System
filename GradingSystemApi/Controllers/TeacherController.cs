using GradingSystemApi.Models.addDto;
using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;

namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly GradingDbContext DbContext;

        public TeacherController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        [HttpGet]
        public IActionResult GetAllTeacher()
        {
            var Teacher = DbContext.Teacher
                .ToList();
            return Ok(Teacher);
        }
        [HttpGet]
        [Route("{TeacherID}")]
        public IActionResult GetTeacherByID(int TeacherID)
        {
            var TeacherEntity = DbContext.Teacher.Find(TeacherID);
            if (TeacherEntity == null)
            {
                return NotFound();
            }
            return Ok(TeacherEntity);
        }

        [HttpPost]
        public IActionResult AddTeacher(TeacherDto addTeacher)
        {
            if (addTeacher == null)
            {
                return BadRequest("Teacher cannot be null");
            }
            var teacherEntity = new Teacher()
            {
                FirstName = addTeacher.FirstName,
                Lastname = addTeacher.Lastname,
                Email = addTeacher.Email,
                PhoneNumber = addTeacher.PhoneNumber,
                Department = addTeacher.Department
            };
            DbContext.Add(teacherEntity);
            DbContext.SaveChanges();
            return Ok(teacherEntity);
        }
        [HttpPut]
        [Route("{TeacherID}")]
        public IActionResult UpdateTeacher(int TeacherID, TeacherDto teacher)
        {
            var TeacherEntity = DbContext.Teacher.Find(TeacherID);
            if (TeacherEntity == null)
            {
                return NotFound();
            }
            TeacherEntity.FirstName = teacher.FirstName;
            TeacherEntity.Lastname = teacher.Lastname;
            TeacherEntity.Email = teacher.Email;
            TeacherEntity.PhoneNumber = teacher.PhoneNumber;
            TeacherEntity.Department = teacher.Department;

            DbContext.SaveChanges();
            return Ok(TeacherEntity);
        }
        [HttpDelete]
        [Route("{TeacherID}")]
        public IActionResult DeleteTeacher(int TeacherID)
        {
            var TeacherEntity = DbContext.Teacher.Find(TeacherID);
            if (TeacherEntity == null)
            {
                return NotFound();
            }
            DbContext.Teacher.Remove(TeacherEntity);
            DbContext.SaveChanges();
            return Ok(TeacherEntity);

        }
    }
}
