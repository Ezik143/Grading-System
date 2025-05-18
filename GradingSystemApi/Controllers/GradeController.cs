using GradingSystemApi.Models.Entities;
using GradingSystemApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Team_Yeri_enrollment_system.GradingLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly GradingDbContext DbContext;

        public GradeController(GradingDbContext DbContext)
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

            var ExistClass = DbContext.Class.Any(c => c.ClassID == AddGrade.ClassID);
            if (!ExistClass)
            {
                return BadRequest($"Grade with code {AddGrade.ClassID} does not exist");
            }

            var ExistGradingPeriod = DbContext.GradingPeriod.Any(g => g.GradingPeriodID == AddGrade.GradingPeriodID);
            if (!ExistGradingPeriod)
            {
                return BadRequest($"Grading Period with code {AddGrade.GradingPeriodID} does not exist");
            }

            var ExistEnrollment = DbContext.Enrollment.Any(e => e.EnrollmentID == AddGrade.EnrollmentID);
            if (!ExistEnrollment)
            {
                return BadRequest($"Enrollment with code {AddGrade.EnrollmentID} does not exist");
            }

            var GradeEntity = new Grade()
            {
                EducationLevel = AddGrade.EducationLevel,
                ClassID = AddGrade.ClassID,
                GradeValue = AddGrade.GradeValue,
                GradeEquivalent = AddGrade.GradeEquivalent,
                Remark = AddGrade.Remark,
                GradingPeriodID = AddGrade.GradingPeriodID,
                EnrollmentID = AddGrade.EnrollmentID,
                DateRecorded = AddGrade.DateRecorded
            };

            DbContext.Add(GradeEntity);
            DbContext.SaveChanges();

            var CreatedGrade = DbContext.Grade
                .FirstOrDefault(g => g.GradeID == GradeEntity.GradeID);

            return Ok(CreatedGrade);
        }


        [HttpPut]
        [Route("{GradeID}")]
        public IActionResult UpdateGrade(int GradeID, GradeDto UpdateGrade)
        {

            var GradeEntity = DbContext.Grade.Find(GradeID);
            if (GradeEntity == null)
            {
                return NotFound();
            }


            var ExistClass = DbContext.Class.Any(c => c.ClassID == UpdateGrade.ClassID);
            if (!ExistClass)
            {
                return BadRequest($"Grade with code {UpdateGrade.ClassID} does not exist");
            }

            var ExistGradingPeriod = DbContext.GradingPeriod.Any(g => g.GradingPeriodID == UpdateGrade.GradingPeriodID);
            if (!ExistGradingPeriod)
            {
                return BadRequest($"Grading Period with code {UpdateGrade.GradingPeriodID} does not exist");
            }

            var ExistEnrollment = DbContext.Enrollment.Any(e => e.EnrollmentID == UpdateGrade.EnrollmentID);
            if (!ExistEnrollment)
            {
                return BadRequest($"Enrollment with code {UpdateGrade.EnrollmentID} does not exist");
            }

            GradeEntity.EducationLevel = UpdateGrade.EducationLevel;
            GradeEntity.ClassID = UpdateGrade.ClassID;
            GradeEntity.GradeValue = UpdateGrade.GradeValue;
            GradeEntity.GradeEquivalent = UpdateGrade.GradeEquivalent;
            GradeEntity.Remark = UpdateGrade.Remark;
            GradeEntity.GradingPeriodID = UpdateGrade.GradingPeriodID;
            GradeEntity.EnrollmentID = UpdateGrade.EnrollmentID;
            GradeEntity.DateRecorded = UpdateGrade.DateRecorded;

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
