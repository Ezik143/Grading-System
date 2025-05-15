using GradingSystemApi.Models.addDto;
using GradingSystemApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Team_Yeri_enrollment_system.GradingLibrary.Data;

namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly GradingDbContext DbContext;

        public SubjectController(GradingDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult GetSubject()
        {
            var Subject = DbContext.Subject
                .ToList();
            return Ok(Subject);
        }
        [HttpGet]
        [Route("{SubjectCode}")]
        public IActionResult GetSubjectByID(string SubjectCode)
        {
            var subjectEntity = DbContext.Subject.Find(SubjectCode);
            if (subjectEntity is null)
            {
                return NotFound();
            }
            return Ok(subjectEntity);
        }
        [HttpPost]
        public IActionResult AddSubject(SubjectDto AddSubject)
        {
            if(AddSubject == null)
            {
                return BadRequest("Subject cannot be null");
            }

            var SubjectEntity = new Subject()
            {
                SubjectCode = AddSubject.SubjectCode,
                SubjectName = AddSubject.SubjectName,
                Units = AddSubject.Units
            };
            DbContext.Add(SubjectEntity);
            DbContext.SaveChanges();
            return Ok(SubjectEntity);
        }

        [HttpPut]
        [Route("{SubjectCode}")]
        public IActionResult UpdateSubject(int SubjectCode,SubjectDto Subject)
        {
            var subjectEntity = DbContext.Subject.Find(Subject.SubjectCode);
            if (subjectEntity is null)
            {
                return NotFound();
            }
            subjectEntity.SubjectName = Subject.SubjectName;
            subjectEntity.Units = Subject.Units;
            DbContext.SaveChanges();
            return Ok(subjectEntity);
        }

        [HttpDelete]
        [Route("{SubjectCode}")]

        public IActionResult DeleteSubject(string SubjectCode)
        {
            var subjectEntity = DbContext.Subject.Find(SubjectCode);
            if (subjectEntity is null)
            {
                return NotFound();
            }
            DbContext.Remove(subjectEntity);
            DbContext.SaveChanges();
            return Ok(subjectEntity);
        }
    }
}
