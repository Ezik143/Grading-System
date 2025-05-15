using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;

namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {
        private readonly GradingDbContext DbContext;

        public TermController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult AllTerm()
        {
            var Term = DbContext.Term
                .ToList();
            return Ok(Term);
        }

        [HttpGet]
        [Route("{TermID}")]
        public IActionResult TermByID(int TermID)
        {
            var TermEntity = DbContext.Term.Find(TermID);
            if (TermEntity == null)
            {
                return NotFound();
            }
            DbContext.SaveChanges();
            var TermWithDetails = DbContext.Term
                .FirstOrDefault(t => t.TermID == TermEntity.TermID);

            return Ok();
        }

        [HttpPost]
        public IActionResult AddTerm(Term Term)
        {
            if (Term == null)
            {
                return BadRequest("Cannot be null");
            }

            var TermEntity = new Term()
            {
                TermName = Term.TermName,
                AcademicYear = Term.AcademicYear
            };

            DbContext.Add(TermEntity);
            DbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("{TermId}")]
        public IActionResult UpdateTerm(int TermId, Term UpdateTerm)
        {
            if (UpdateTerm == null)
            {
                return BadRequest("Cannot be null");
            }

            var TermEntity = DbContext.Term.Find(TermId);
            if (TermEntity == null)
            {
                return NotFound();
            }

            TermEntity.TermName = UpdateTerm.TermName;
            TermEntity.AcademicYear = UpdateTerm.AcademicYear;
            DbContext.SaveChanges();
            var UpdatedEntity = DbContext.Term
                .FirstOrDefault(c => c.TermID == TermEntity.TermID);
            return Ok();
        }

        [HttpDelete]
        [Route("{TermId}")]
        public IActionResult DeleteTerm(int TermId)
        {
            var TermEntity = DbContext.Term.Find(TermId);
            if (TermEntity == null)
            {
                return NotFound();
            }

            DbContext.Remove(TermEntity);

            var DeletedEntity = DbContext.Term
                .FirstOrDefault();

            DbContext.SaveChanges();

            return Ok(DeletedEntity);
        }
    }
}
