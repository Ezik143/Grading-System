using GradingSystemApi.Models.addDto;
using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Team_Yeri_enrollment_system.GradingLibrary.Data;

namespace GradingSystemApi.Controllers
{
    // Route for this controller: api/Subject
    [Route("api/[controller]")]
    // Marks this as an API controller
    [ApiController]
    // Controller for managing Subject entities
    public class SubjectController : ControllerBase
    {
        // The database context for accessing data
        private readonly GradingDbContext DbContext;

        // Constructor for dependency injection of the context
        public SubjectController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        // GET: api/Subject
        // Returns all subjects
        [HttpGet]
        public IActionResult GetSubject()
        {
            var Subject = DbContext.Subject
                .ToList();           // Get all subjects as a list
            return Ok(Subject);      // Return HTTP 200 with the list
        }

        // GET: api/Subject/{SubjectCode}
        // Returns a specific subject by its code
        [HttpGet]
        [Route("{SubjectCode}")]
        public IActionResult GetSubjectByID(string SubjectCode)
        {
            var subjectEntity = DbContext.Subject.Find(SubjectCode); // Find by primary key
            if (subjectEntity is null)
            {
                return NotFound(); // Return 404 if not found
            }
            return Ok(subjectEntity); // Return HTTP 200 with the subject
        }

        // POST: api/Subject
        // Adds a new subject
        [HttpPost]
        public IActionResult AddSubject(SubjectDto AddSubject)
        {
            if (AddSubject == null)
            {
                return BadRequest("Subject cannot be null"); // Return 400 if input is null
            }

            // Create new Subject entity from DTO
            var SubjectEntity = new Subject()
            {
                SubjectCode = AddSubject.SubjectCode,
                SubjectName = AddSubject.SubjectName,
                Units = AddSubject.Units
            };
            DbContext.Add(SubjectEntity);      // Add to context
            DbContext.SaveChanges();           // Save to database
            return Ok(SubjectEntity);          // Return HTTP 200 with created subject
        }

        // PUT: api/Subject/{SubjectCode}
        // Updates an existing subject
        [HttpPut]
        [Route("{SubjectCode}")]
        public IActionResult UpdateSubject(int SubjectCode, SubjectDto Subject)
        {
            var subjectEntity = DbContext.Subject.Find(Subject.SubjectCode); // Find by code
            if (subjectEntity is null)
            {
                return NotFound(); // Return 404 if not found
            }
            // Update properties
            subjectEntity.SubjectName = Subject.SubjectName;
            subjectEntity.Units = Subject.Units;
            DbContext.SaveChanges(); // Save changes
            return Ok(subjectEntity); // Return HTTP 200 with updated subject
        }

        // DELETE: api/Subject/{SubjectCode}
        // Deletes a subject by its code
        [HttpDelete]
        [Route("{SubjectCode}")]
        public IActionResult DeleteSubject(string SubjectCode)
        {
            var subjectEntity = DbContext.Subject.Find(SubjectCode); // Find by code
            if (subjectEntity is null)
            {
                return NotFound(); // Return 404 if not found
            }
            DbContext.Remove(subjectEntity); // Remove from context
            DbContext.SaveChanges();         // Save changes
            return Ok(subjectEntity);        // Return HTTP 200 with deleted subject
        }
    }
}
