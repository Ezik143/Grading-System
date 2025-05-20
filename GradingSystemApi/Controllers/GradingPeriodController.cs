using GradingSystemApi.Models.Dto;
using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;


namespace GradingSystemApi.Controllers
{
    // Route for this controller: api/GradingPeriod
    [Route("api/[controller]")]
    // Marks this as an API controller
    [ApiController]
    // Controller for managing GradingPeriod entities
    public class GradingPeriodController : ControllerBase
    {
        // The database context for accessing data
        private readonly GradingDbContext DbContext;

        // Constructor for dependency injection of the context
        public GradingPeriodController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        // GET: api/GradingPeriod
        // Returns all grading periods, including related term details
        [HttpGet]
        public IActionResult GetAllGradingPeriod()
        {
            var GradingPeriod = DbContext.GradingPeriod
                .ToList();            // Convert to a list
            return Ok(GradingPeriod); // Return HTTP 200 with the list
        }

        // GET: api/GradingPeriod/{GradingPeriodID}
        // Returns a specific grading period by its ID, including term details
        [HttpGet]
        [Route("{GradingPeriodID}")]
        public IActionResult GetByID(int GradingPeriodID)
        {
            var GradingPeriodEntity = DbContext.GradingPeriod.Find(GradingPeriodID); // Find by primary key
            if (GradingPeriodEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            DbContext.SaveChanges(); // (Unusual for GET; can be removed)
            var GradingPeriodWithDetails = DbContext.GradingPeriod
                .FirstOrDefault(e => e.GradingPeriodID == GradingPeriodEntity.GradingPeriodID);
            return Ok(GradingPeriodWithDetails); // Return HTTP 200 with details
        }

        // POST: api/GradingPeriod
        // Adds a new grading period, requires a valid term ID and name
        [HttpPost]
        public IActionResult AddGradingPeriod(GradingPeriodDto AddGradingPeriod)
        {
            // Check if the term exists
            var ExistTerm = DbContext.Term.Any(t => t.TermID == AddGradingPeriod.TermID);
            if (!ExistTerm)
            {
                // Return 400 if term does not exist
                return BadRequest($"Term with code {AddGradingPeriod.TermID} does not exist");
            }
            // Create new GradingPeriod entity from DTO
            var GradingPeriodEntity = new GradingPeriod()
            {
                TermID = AddGradingPeriod.TermID,
                Name = AddGradingPeriod.Name
            };
            DbContext.Add(GradingPeriodEntity); // Add to context
            DbContext.SaveChanges();            // Save to database
                                                // Retrieve the created grading period with term details
            var CreatedGradingPeriod = DbContext.GradingPeriod
                .FirstOrDefault(c => c.GradingPeriodID == GradingPeriodEntity.GradingPeriodID);
            return Ok(CreatedGradingPeriod); // Return HTTP 200 with created grading period
        }

        // PUT: api/GradingPeriod/{GradingPeriodID}
        // Updates an existing grading period
        [HttpPut]
        [Route("{GradingPeriodID}")]
        public IActionResult UpdateGradingPeriod(int GradingPeriodID, GradingPeriodDto UpdateGradingPeriod)
        {
            // Find the grading period entity to update
            var GradingPeriodEntity = DbContext.GradingPeriod.Find(GradingPeriodID);
            if (GradingPeriodEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            // Check if the term exists
            var ExistTerm = DbContext.Term.Any(t => t.TermID == UpdateGradingPeriod.TermID);
            if (!ExistTerm)
            {
                // Return 400 if term does not exist
                return BadRequest($"Term with code {UpdateGradingPeriod.TermID} does not exist");
            }
            // Update properties
            GradingPeriodEntity.TermID = UpdateGradingPeriod.TermID;
            GradingPeriodEntity.Name = UpdateGradingPeriod.Name;
            DbContext.SaveChanges(); // Save changes
            return Ok(GradingPeriodEntity); // Return HTTP 200 with updated grading period
        }

        // DELETE: api/GradingPeriod/{GradingPeriodID}
        // Deletes a grading period by its ID
        [HttpDelete]
        [Route("{GradingPeriodID}")]
        public IActionResult DeleteGradingPeriod(int GradingPeriodID)
        {
            // Find the grading period entity to delete
            var GradingPeriodEntity = DbContext.GradingPeriod.Find(GradingPeriodID);
            if (GradingPeriodEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            DbContext.Remove(GradingPeriodEntity); // Remove from context
            DbContext.SaveChanges();               // Save changes
            return Ok(GradingPeriodEntity);        // Return HTTP 200 with deleted grading period
        }
    }
}
