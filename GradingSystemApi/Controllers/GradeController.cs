using GradingSystemApi.Models.Entities;
using GradingSystemApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Team_Yeri_enrollment_system.GradingLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace GradingSystemApi.Controllers
{
    // Route for this controller: api/Grade
    [Route("api/[controller]")]
    // Marks this as an API controller
    [ApiController]
    // Controller for managing Grade entities
    public class GradeController : ControllerBase
    {
        // The database context for accessing data
        private readonly GradingDbContext DbContext;

        // Constructor for dependency injection of the context
        public GradeController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        // GET: api/Grade
        // Returns all grades
        [HttpGet]
        public IActionResult AllGrade()
        {
            var GradeEntity = DbContext.Grade
                .ToList();           // Get all grades as a list
            return Ok(GradeEntity);  // Return HTTP 200 with the list
        }

        // GET: api/Grade/{GradeID}
        // Returns a specific grade by its ID
        [HttpGet]
        [Route("{GradeID}")]
        public IActionResult GradeByID(int GradeID)
        {
            var StudentEntity = DbContext.Grade.Find(GradeID); // Find by primary key
            if (StudentEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return Ok(StudentEntity); // Return HTTP 200 with the grade
        }

        // POST: api/Grade
        // Adds a new grade, requires valid class, grading period, and enrollment IDs
        [HttpPost]
        public IActionResult AddGrade(GradeDto AddGrade)
        {
            // Check if the class exists
            var ExistClass = DbContext.Class.Any(c => c.ClassID == AddGrade.ClassID);
            if (!ExistClass)
            {
                // Return 400 if class does not exist
                return BadRequest($"Grade with code {AddGrade.ClassID} does not exist");
            }

            // Check if the grading period exists
            var ExistGradingPeriod = DbContext.GradingPeriod.Any(g => g.GradingPeriodID == AddGrade.GradingPeriodID);
            if (!ExistGradingPeriod)
            {
                // Return 400 if grading period does not exist
                return BadRequest($"Grading Period with code {AddGrade.GradingPeriodID} does not exist");
            }

            // Check if the enrollment exists
            var ExistEnrollment = DbContext.Enrollment.Any(e => e.EnrollmentID == AddGrade.EnrollmentID);
            if (!ExistEnrollment)
            {
                // Return 400 if enrollment does not exist
                return BadRequest($"Enrollment with code {AddGrade.EnrollmentID} does not exist");
            }

            // Create new Grade entity from DTO
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

            DbContext.Add(GradeEntity);      // Add to context
            DbContext.SaveChanges();         // Save to database

            // Retrieve the created grade
            var CreatedGrade = DbContext.Grade
                .FirstOrDefault(g => g.GradeID == GradeEntity.GradeID);

            return Ok(CreatedGrade);         // Return HTTP 200 with created grade
        }

        // PUT: api/Grade/{GradeID}
        // Updates an existing grade
        [HttpPut]
        [Route("{GradeID}")]
        public IActionResult UpdateGrade(int GradeID, GradeDto UpdateGrade)
        {
            // Find the grade entity to update
            var GradeEntity = DbContext.Grade.Find(GradeID);
            if (GradeEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }

            // Check if the class exists
            var ExistClass = DbContext.Class.Any(c => c.ClassID == UpdateGrade.ClassID);
            if (!ExistClass)
            {
                return BadRequest($"Grade with code {UpdateGrade.ClassID} does not exist");
            }

            // Check if the grading period exists
            var ExistGradingPeriod = DbContext.GradingPeriod.Any(g => g.GradingPeriodID == UpdateGrade.GradingPeriodID);
            if (!ExistGradingPeriod)
            {
                return BadRequest($"Grading Period with code {UpdateGrade.GradingPeriodID} does not exist");
            }

            // Check if the enrollment exists
            var ExistEnrollment = DbContext.Enrollment.Any(e => e.EnrollmentID == UpdateGrade.EnrollmentID);
            if (!ExistEnrollment)
            {
                return BadRequest($"Enrollment with code {UpdateGrade.EnrollmentID} does not exist");
            }

            // Update properties
            GradeEntity.EducationLevel = UpdateGrade.EducationLevel;
            GradeEntity.ClassID = UpdateGrade.ClassID;
            GradeEntity.GradeValue = UpdateGrade.GradeValue;
            GradeEntity.GradeEquivalent = UpdateGrade.GradeEquivalent;
            GradeEntity.Remark = UpdateGrade.Remark;
            GradeEntity.GradingPeriodID = UpdateGrade.GradingPeriodID;
            GradeEntity.EnrollmentID = UpdateGrade.EnrollmentID;
            GradeEntity.DateRecorded = UpdateGrade.DateRecorded;

            DbContext.SaveChanges(); // Save changes

            // Retrieve the updated grade
            var UpdatedGrade = DbContext.Grade
                .FirstOrDefault(s => s.GradeID == GradeID);
            return Ok(UpdatedGrade); // Return HTTP 200 with updated grade
        }

        // DELETE: api/Grade/{GradeID}
        // Deletes a grade by its ID
        [HttpDelete]
        [Route("{GradeID}")]
        public IActionResult DeleteGrade(int GradeID)
        {
            // Find the grade entity to delete
            var GradeEntity = DbContext.Grade.Find(GradeID);
            if (GradeEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            DbContext.Remove(GradeEntity); // Remove from context
            DbContext.SaveChanges();       // Save changes

            // Optionally retrieve the deleted grade (will be null)
            var DeletedGrade = DbContext.Grade
                .FirstOrDefault(g => g.GradeID == GradeEntity.GradeID);

            return Ok(DeletedGrade); // Return HTTP 200 with deleted grade
        }
    }
}
