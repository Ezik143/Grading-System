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
        private readonly EnrollmentDbContext dbContext;

        public SubjectController(EnrollmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetSubject()
        {
            var subjects = dbContext.Subjects
                .ToList();
            return Ok(subjects);
        }
        [HttpGet]
        [Route("{SubjectCode}")]
        public IActionResult GetSubjectByID(string SubjectCode)
        {
            var subjectEntity = dbContext.Subjects.Find(SubjectCode);
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
            dbContext.Add(SubjectEntity);
            dbContext.SaveChanges();
            return Ok(SubjectEntity);
        }

        [HttpPut]
        [Route("{SubjectCode}")]
        public IActionResult UpdateSubject(int SubjectCode,SubjectDto Subject)
        {
            var subjectEntity = dbContext.Subjects.Find(Subject.SubjectCode);
            if (subjectEntity is null)
            {
                return NotFound();
            }
            subjectEntity.SubjectName = Subject.SubjectName;
            subjectEntity.Units = Subject.Units;
            dbContext.SaveChanges();
            return Ok(subjectEntity);
        }

        [HttpDelete]
        [Route("{SubjectCode}")]

        public IActionResult DeleteSubject(string SubjectCode)
        {
            var subjectEntity = dbContext.Subjects.Find(SubjectCode);
            if (subjectEntity is null)
            {
                return NotFound();
            }
            dbContext.Remove(subjectEntity);
            dbContext.SaveChanges();
            return Ok(subjectEntity);
        }
    }
}
