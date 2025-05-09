    using System.ComponentModel.DataAnnotations;
using Team_Yeri_enrollment_system.GradingLibrary.Models;
namespace GradingSystemApi.Models.Entities
{
    public class Subject
    {
        [Key]
        [Required]
        public required string subjectCode { get; set; }
        [Required]
        public required string subjectName { get; set; }
        [Required]
        [MaxLength(100)]
        public required int totalUnits { get; set; }

        // Subject relation to courseSubject, One to many
        /// <summary>
        ///  A Subject can be taught by many courses
        /// </summary>
        public List<courseSubject> CourseSubjects { get; set; } = new List<courseSubject>();

        //Subject relation to grades, one and only one
        /// <summary>
        /// Subject is tied to exactly one grade
        /// </summary>
        public List<Grades> Grades { get; set; } = new List<Grades>();

        //Subject relation to classes, many to many
        /// <summary>
        /// Subject can be taught by many classes
        /// </summary>
        public List<Classes> Classes { get; set; } = new List<Classes>();

        //Subject relation to teacherSubject, zero to many
        /// <summary>
        /// Subject can be taught by many teachers
        /// </summary>
        public List<teacherSubject> TeacherSubjects { get; set; } = new List<teacherSubject>();
    }
}