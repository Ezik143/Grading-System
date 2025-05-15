using GradingSystemApi.Models.Dto;
using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;

namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(GradingDbContext DbContext) : ControllerBase
    {
        private readonly GradingDbContext DbContext = DbContext;

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var Student = DbContext.Student
                .ToList();

            return Ok(Student);
        }

        [HttpGet]
        [Route("{StudentID}")]
        public IActionResult GetStudentByID(int StudentID)
        {
            var Student = DbContext.Student.Find(StudentID);
            if (Student == null) 
            {
                return NotFound();
            }

            return Ok(Student);
        }

        [HttpPost]
        public IActionResult AddStudent(StudentDto AddStudent)
        {
            var StudentEntity = new Student()
            {
                FirstName = AddStudent.FirstName,
                MiddleName = AddStudent.MiddleName,
                LastName = AddStudent.LastName,
                BirthDate = AddStudent.BirthDate,
                Sex = AddStudent.Sex,
                Email = AddStudent.Email,
                PhoneNumber = AddStudent.PhoneNumber
            };

            DbContext.Add(StudentEntity);
            DbContext.SaveChanges();

            return Ok(StudentEntity);
        }

        [HttpPut]
        [Route("{StudentID}")]
        public IActionResult UpdateStudent(int StudentID, Student UpdateStudent)
        {
            if (UpdateStudent == null)
            {
                return BadRequest("Student cannot be null");
            }
            var StudentEntity = DbContext.Student.Find(StudentID);
            if (StudentEntity == null)
            {
                return NotFound();
            }

            StudentEntity.FirstName = UpdateStudent.FirstName;
            StudentEntity.MiddleName = UpdateStudent.MiddleName;
            StudentEntity.LastName = UpdateStudent.LastName;
            StudentEntity.BirthDate = UpdateStudent.BirthDate;
            StudentEntity.Sex = UpdateStudent.Sex;
            StudentEntity.Email = UpdateStudent.Email;
            StudentEntity.PhoneNumber = UpdateStudent.PhoneNumber;

            return Ok();
        }




    }
}
