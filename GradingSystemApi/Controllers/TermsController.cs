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
    public class TermsController : ControllerBase
    {
        private readonly EnrollmentDbContext dbContext;

        public TermsController(EnrollmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Allterms()
        {
            var terms = dbContext.Terms
                .ToList();
            return Ok(terms);
        }

        [HttpGet]
        [Route("{TermID}")]
        public IActionResult TermByID(int TermID)
        {
            var TermsEntity = dbContext.Terms.Find(TermID);
            if (TermsEntity == null)
            {
                return NotFound();
            }
            dbContext.SaveChanges();
            var TermsWithDetails = dbContext.Terms
                .FirstOrDefault(t => t.TermID == TermsEntity.TermID);

            return Ok();
        }

        [HttpPost]
        public IActionResult AddTerms(Terms terms)
        {
            if (terms == null)
            {
                return BadRequest("Cannot be null");
            }

            var TermEntity = new Terms()
            {
                TermName = terms.TermName,
                AcademicYear = terms.AcademicYear
            };

            dbContext.Add(TermEntity);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("{TermId}")]
        public IActionResult UpdateTerms(int TermId, Terms UpdateTerms)
        {
            if (UpdateTerms == null)
            {
                return BadRequest("Cannot be null");
            }

            var TermEntity = dbContext.Terms.Find(TermId);
            if (TermEntity == null)
            {
                return NotFound();
            }

            TermEntity.TermName = UpdateTerms.TermName;
            TermEntity.AcademicYear = UpdateTerms.AcademicYear;
            dbContext.SaveChanges();
            var UpdatedEntity = dbContext.Terms
                .FirstOrDefault(c => c.TermID == TermEntity.TermID);
            return Ok();
        }

        [HttpDelete]
        [Route("{TermId}")]
        public IActionResult DeleteTerms(int TermId)
        {
            var TermEntity = dbContext.Terms.Find(TermId);
            if (TermEntity == null)
            {
                return NotFound();
            }

            dbContext.Remove(TermEntity);

            var DeletedEntity = dbContext.Terms
                .FirstOrDefault();

            dbContext.SaveChanges();

            return Ok(DeletedEntity);
        }
    }
}
