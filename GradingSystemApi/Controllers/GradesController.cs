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
    public class GradeController : ControllerBase
    {
        private readonly EnrollmentDbContext DbContext;

        public GradeController(EnrollmentDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult AllGrade()
        {
            var GradeEntity = DbContext.Grade
                .ToList();
            return Ok(GradeEntity);
        }


        [HttpGet]
        [Route("{GradeID}")]
        public IActionResult GradeByID(int GradeID) 
        {
            var StudentEntity = DbContext.Grade.Find(GradeID);
            if (StudentEntity == null)
            {
                return NotFound();
            }
            return Ok(StudentEntity);
        }

        [HttpPost]
        public IActionResult AddGrade(GradeDto AddGrade)
        {

            var ExistStudent = DbContext.Student.Any(s => s.StudentID == AddGrade.StudentID);
            if (!ExistStudent)
            {
                return BadRequest($"Student with code {AddGrade.StudentID} does not exist");
            }

            var ExistClass = DbContext.Class.Any(c => c.ClassID == AddGrade.ClassID);
            if (!ExistClass)
            {
                return BadRequest($"Class with code {AddGrade.ClassID} does not exist");
            }

            var ExistTerm = DbContext.Term.Any(t => t.TermID == AddGrade.TermID);
            if (!ExistTerm)
            {
                return BadRequest($"Term with code {AddGrade.TermID} does not exist");
            }

            var GradeEntity = new Grade()
            {
                StudentID = AddGrade.StudentID,
                ClassID = AddGrade.ClassID,
                AssessmentType = AddGrade.AssessmentType,
                TermID = AddGrade.TermID,
                Score = AddGrade.Score
            };

            DbContext.Add(GradeEntity);
            DbContext.SaveChanges();

            var CreatedGrade = DbContext.Grade
                .FirstOrDefault(g => g.GradeID == GradeEntity.GradeID);

            return Ok();
        }


        [HttpPut]
        [Route("{GradeID}")]
        public IActionResult UpdateGrade(int GradeID, Grade UpdateGrade)
        {
            if (AddGrade == null)
            {
                return BadRequest("Cannot be null");
            }

            var GradeEntity = DbContext.Grade.Find(GradeID);
            if (GradeEntity == null)
            {
                return NotFound();
            }

            var ExistStudent = DbContext.Student.Any(s => s.StudentID == UpdateGrade.StudentID);
            if (!ExistStudent)
            {
                return BadRequest($"Grade with code {UpdateGrade.StudentID} does not exist");
            }

            var ExistClass = DbContext.Class.Any(c => c.ClassID == UpdateGrade.ClassID);
            if (!ExistClass)
            {
                return BadRequest($"Grade with code {UpdateGrade.ClassID} does not exist");
            }

            var ExistTerm = DbContext.Term.Any(t => t.TermID == UpdateGrade.TermID);
            if (!ExistTerm)
            {
                return BadRequest($"Grade with code {UpdateGrade.TermID} does not exist");
            }


            GradeEntity.StudentID = UpdateGrade.StudentID;
            GradeEntity.ClassID = UpdateGrade.ClassID;
            GradeEntity.AssessmentType = UpdateGrade.AssessmentType;
            GradeEntity.TermID = UpdateGrade.TermID;
            GradeEntity.Score = UpdateGrade.Score;

            DbContext.SaveChanges();
            var UpdatedGrade = DbContext.Grade
                .FirstOrDefault(s => s.GradeID == GradeID);
            return Ok(UpdatedGrade);
        }

        [HttpDelete]
        [Route("{GradeID}")]
        public IActionResult DeleteGrade(int GradeID)
        {
            var GradeEntity = DbContext.Grade.Find(GradeID);
            if (GradeEntity == null)
            {
                return NotFound();
            }
            DbContext.Remove(GradeEntity);
            DbContext.SaveChanges();

            var DeletedGrade = DbContext.Grade
                .FirstOrDefault(g => g.GradeID == GradeEntity.GradeID);

            return Ok(DeletedGrade);
        }

    }
}
