using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team_Yeri_enrollment_system.GradingLibrary.Models;
namespace GradingSystemApi.Models.Entities
{
    public class Enrollment
    {
        [Key]
        [Required]
        public required int enrollmentID { get; set; }
        //Foreign Key to studentID
        /// <summary>
        /// relation: zero or many
        /// One Student can have zero or many Enrollments
        /// </summary>
        [Required]
        public required int studentID { get; set; }
        [ForeignKey("studentID")]
        public Students Student { get; set; }

        //Foreign Key to courseID
        /// <summary>
        /// relation: Zero or many
        /// One course can have zero or many Enrollments
        /// </summary>
        [Required]
        public required int courseID { get; set; }
        [ForeignKey("courseID")]
        public Course Course { get; set; }
        //Foreign Key to termID
        /// <summary>
        /// relation: Zero or many
        /// Each enrollment is associated with a specific term
        /// <example>
        ///     midterm enrollment, final enrollment
        ///     first year enrollment, second year enrollment
        /// </example>
        /// </summary>
        [Required]
        public required int termID { get; set; }
        [ForeignKey("termID")]
        public Terms Term { get; set; }
        [Required]
        [MaxLength(1)]
        public required char enrollmentStatus { get; set; }

    }
}