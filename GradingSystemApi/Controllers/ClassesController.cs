using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Data;
using Team_Yeri_enrollment_system.GradingLibrary.Models;

namespace GradingSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly EnrollmentDbContext _context;

        public ClassesController(EnrollmentDbContext context)
        {
            _context = context;
        }

        // GET: api/classes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classes>>> GetClasses()
        {
            return await _context.Classes.ToListAsync();
        }

        // GET: api/classes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Classes>> GetClass(int id)
        {
            var classItem = await _context.Classes.FindAsync(id);
            if (classItem == null)
            {
                return NotFound();
            }
            return classItem;
        }

        // POST: api/classes
        [HttpPost]
        public async Task<ActionResult<Classes>> CreateClass(Classes newClass)
        {
            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClass), new { id = newClass.Class_ID }, newClass);
        }

        // PUT: api/classes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, Classes updatedClass)
        {
            if (id != updatedClass.Class_ID)
            {
                return BadRequest();
            }

            _context.Entry(updatedClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/classes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var classItem = await _context.Classes.FindAsync(id);
            if (classItem == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(classItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassExists(int id)
        {
            return _context.Classes.Any(e => e.Class_ID == id);
        }
    }
}
