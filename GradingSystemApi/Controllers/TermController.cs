using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;

namespace GradingSystemApi.Controllers
{
    // Route for this controller: api/Term
    [Route("api/[controller]")]
    // Marks this as an API controller
    [ApiController]
    // Controller for managing Term entities
    public class TermController : ControllerBase
    {
        // The database context for accessing data
        private readonly GradingDbContext DbContext;

        // Constructor for dependency injection of the context
        public TermController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        // GET: api/Term
        // Returns all terms
        [HttpGet]
        public IActionResult AllTerm()
        {
            var Term = DbContext.Term
                .ToList();           // Get all terms as a list
            return Ok(Term);        // Return HTTP 200 with the list
        }

        // GET: api/Term/{TermID}
        // Returns a specific term by its ID
        [HttpGet]
        [Route("{TermID}")]
        public IActionResult TermByID(int TermID)
        {
            var TermEntity = DbContext.Term.Find(TermID); // Find by primary key
            if (TermEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }
            DbContext.SaveChanges(); // (Unusual for GET; can be removed)
            var TermWithDetails = DbContext.Term
                .FirstOrDefault(t => t.TermID == TermEntity.TermID);

            return Ok(TermWithDetails); // Return HTTP 200 with the term
        }

        // POST: api/Term
        // Adds a new term
        [HttpPost]
        public IActionResult AddTerm(Term Term)
        {
            if (Term == null)
            {
                return BadRequest("Cannot be null"); // Return 400 if input is null
            }

            // Create new Term entity from input
            var TermEntity = new Term()
            {
                TermName = Term.TermName,
                AcademicYear = Term.AcademicYear
            };

            DbContext.Add(TermEntity); // Add to context
            DbContext.SaveChanges();   // Save to database
            return Ok();               // Return HTTP 200 (no content returned)
        }

        // PUT: api/Term/{TermId}
        // Updates an existing term
        [HttpPut]
        [Route("{TermId}")]
        public IActionResult UpdateTerm(int TermId, Term UpdateTerm)
        {
            if (UpdateTerm == null)
            {
                return BadRequest("Cannot be null"); // Return 400 if input is null
            }

            var TermEntity = DbContext.Term.Find(TermId); // Find by ID
            if (TermEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }

            // Update properties
            TermEntity.TermName = UpdateTerm.TermName;
            TermEntity.AcademicYear = UpdateTerm.AcademicYear;
            DbContext.SaveChanges(); // Save changes
            var UpdatedEntity = DbContext.Term
                .FirstOrDefault(c => c.TermID == TermEntity.TermID);
            return Ok(); // Return HTTP 200 (no content returned)
        }

        // DELETE: api/Term/{TermId}
        // Deletes a term by its ID
        [HttpDelete]
        [Route("{TermId}")]
        public IActionResult DeleteTerm(int TermId)
        {
            var TermEntity = DbContext.Term.Find(TermId); // Find by ID
            if (TermEntity == null)
            {
                return NotFound(); // Return 404 if not found
            }

            DbContext.Remove(TermEntity); // Remove from context

            var DeletedEntity = DbContext.Term
                .FirstOrDefault(); // (Not necessary, as the entity is deleted)

            DbContext.SaveChanges(); // Save changes

            return Ok(DeletedEntity); // Return HTTP 200 with (now deleted) entity
        }
    }
}
