using Team_Yeri_enrollment_system.GradingLibrary.Models;
using Team_Yeri_enrollment_system.GradingLibrary.Data;
using GradingSystemApi.Models.addDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemApi.Controllers
{
    // Sets the route for the controller to "api/Class"
    [Route("api/[controller]")]
    // Indicates this is an API controller (enables automatic model validation, etc.)
    [ApiController]
    // Defines the ClassController, which inherits from ControllerBase
    public class ClassController(GradingDbContext DbContext) : ControllerBase
    {
        // Dependency-injected database context for accessing the database
        private readonly GradingDbContext DbContext = DbContext;

        // Handles GET requests to "api/Class"
        [HttpGet]
        public IActionResult GetAllClass()
        {
            // Retrieves all classes, including their associated Teacher entity
            var Class = DbContext.Class
                .ToList();               // Converts the result to a list
            return Ok(Class);            // Returns the list of classes with HTTP 200 OK
        }

        // Handles GET requests to "api/Class/{ClassID}"
        [HttpGet]
        [Route("{ClassID}")]
        public IActionResult GetClassByID(int ClassID)
        {
            // Finds the class entity by its primary key
            var classEntity = DbContext.Class.Find(ClassID);
            if (classEntity is null)
            {
                // Returns 404 Not Found if the class does not exist
                return NotFound();
            }
            DbContext.SaveChanges(); // (Unusual here; typically not needed for GET)
                                     // Retrieves the class with its related Teacher entity
            var ClassWithDetails = DbContext.Class
                .FirstOrDefault(c => c.ClassID == classEntity.ClassID);
            return Ok(ClassWithDetails); // Returns the class details with HTTP 200 OK
        }

        // Handles POST requests to "api/Class"
        [HttpPost]
        public IActionResult AddClass(ClassDto AddClass)
        {
            // Checks if the specified Teacher exists
            var ExistTeacher = DbContext.Teacher.Any(t => t.TeacherID == AddClass.TeacherID);
            if (!ExistTeacher)
            {
                // Returns 400 Bad Request if the teacher does not exist
                return BadRequest($"Teacher with ID {AddClass.TeacherID} does not exist");
            }

            // Creates a new Class entity from the DTO
            var ClassEntity = new Class()
            {
                TeacherID = AddClass.TeacherID,
                Schedule = AddClass.Schedule,
            };
            DbContext.Add(ClassEntity);      // Adds the new class to the context
            DbContext.SaveChanges();         // Saves changes to the database

            // Retrieves the newly created class with its Teacher
            var CreatedClass = DbContext.Class
                .FirstOrDefault(c => c.ClassID == ClassEntity.ClassID);

            return Ok(CreatedClass);         // Returns the created class with HTTP 200 OK
        }

        // Handles PUT requests to "api/Class/{ClassID}"
        [HttpPut]
        [Route("{ClassID}")]
        public IActionResult UpdateCourses(int ClassID, ClassDto UpdateClassDto)
        {
            // Finds the class entity to update
            var ClassEntity = DbContext.Class.Find(ClassID);
            if (ClassEntity == null)
            {
                // Returns 404 Not Found if the class does not exist
                return NotFound();
            }

            // Updates the class properties from the DTO
            ClassEntity.TeacherID = UpdateClassDto.TeacherID;
            ClassEntity.Schedule = UpdateClassDto.Schedule;

            DbContext.SaveChanges(); // Saves the changes to the database

            // Retrieves the updated class with its Teacher
            var UpdatedClass = DbContext.Class
                .FirstOrDefault(c => c.ClassID == ClassEntity.ClassID);

            return Ok(UpdatedClass); // Returns the updated class with HTTP 200 OK
        }

        // Handles DELETE requests to "api/Class/{ClassID}"
        [HttpDelete]
        [Route("{ClassID}")]
        public IActionResult DeleteCourses(int ClassID)
        {
            // Finds the class entity to delete
            var Class = DbContext.Class.Find(ClassID);
            if (Class == null)
            {
                // Returns 404 Not Found if the class does not exist
                return NotFound();
            }
            DbContext.Remove(Class);     // Removes the class from the context
            DbContext.SaveChanges();     // Saves the changes to the database

            // Optionally retrieves the deleted class (will be null)
            var DeletedClass = DbContext.Class
                .FirstOrDefault(c => c.ClassID == Class.ClassID);

            return Ok(Class);            // Returns the deleted class with HTTP 200 OK
        }
    }
}
