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
    public class GradingPeriodController : ControllerBase
    {
        private readonly GradingDbContext DbContext;

        public GradingPeriodController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult GetAllGradingPeriod()
        {
            var GradingPeriod = DbContext.GradingPeriod
                .Include(t => t.Term)
                .ToList();
            return Ok(GradingPeriod);
        }

        [HttpGet]
        [Route("{GradingPeriodID}")]
        public IActionResult GetByID(int GradingPeriodID)
        {
            var GradingPeriodEntity = DbContext.GradingPeriod.Find(GradingPeriodID);
            if (GradingPeriodEntity == null)
            {
                return NotFound();
            }
            DbContext.SaveChanges();
            var GradingPeriodWithDetails = DbContext.GradingPeriod
                .Include(t => t.Term)
                .FirstOrDefault(e => e.GradingPeriodID == GradingPeriodEntity.GradingPeriodID);
            return Ok(GradingPeriodWithDetails);
        }

        [HttpPost]
        public IActionResult AddGradingPeriod(GradingPeriodDto AddGradingPeriod)
        {
            var ExistTerm = DbContext.Term.Any(t => t.TermID == AddGradingPeriod.TermID);
            if (!ExistTerm)
            {
                return BadRequest($"Term with code {AddGradingPeriod.TermID} does not exist");
            }
            var GradingPeriodEntity = new GradingPeriod()
            {
                TermID = AddGradingPeriod.TermID,
                Name = AddGradingPeriod.Name
            };
            DbContext.Add(GradingPeriodEntity);
            DbContext.SaveChanges();
            var CreatedGradingPeriod = DbContext.GradingPeriod
                .Include(t => t.Term)
                .FirstOrDefault(c => c.GradingPeriodID == GradingPeriodEntity.GradingPeriodID);
            return Ok(CreatedGradingPeriod);
        }

        [HttpPut]
        [Route("{GradingPeriodID}")]
        public IActionResult UpdateGradingPeriod(int GradingPeriodID, GradingPeriodDto UpdateGradingPeriod)
        {
            var GradingPeriodEntity = DbContext.GradingPeriod.Find(GradingPeriodID);
            if (GradingPeriodEntity == null)
            {
                return NotFound();
            }
            var ExistTerm = DbContext.Term.Any(t => t.TermID == UpdateGradingPeriod.TermID);
            if (!ExistTerm)
            {
                return BadRequest($"Term with code {UpdateGradingPeriod.TermID} does not exist");
            }
            GradingPeriodEntity.TermID = UpdateGradingPeriod.TermID;
            GradingPeriodEntity.Name = UpdateGradingPeriod.Name;
            DbContext.SaveChanges();
            return Ok(GradingPeriodEntity);
        }

        [HttpDelete]
        [Route("{GradingPeriodID}")]
        public IActionResult DeleteGradingPeriod(int GradingPeriodID)
        {
            var GradingPeriodEntity = DbContext.GradingPeriod.Find(GradingPeriodID);
            if (GradingPeriodEntity == null)
            {
                return NotFound();
            }
            DbContext.Remove(GradingPeriodEntity);
            DbContext.SaveChanges();
            return Ok(GradingPeriodEntity);
        }
    }
}
