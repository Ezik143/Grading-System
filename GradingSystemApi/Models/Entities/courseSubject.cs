using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team_Yeri_enrollment_system.GradingLibrary.Models;

namespace GradingSystemApi.Models.Entities
{
    public class courseSubject
    {
        [Key]
        [Required]
        public required string courseSubjectID { get; set; }
        //Foreign Key to Course_ID
        /// <summary>
        /// Relation: One or Many
        /// because each subject can be reused by multiple courses
        /// <example>
        ///     Courses:BSIT AND BSIS
        ///     Programming 101 is used by BSIT and BSIS
        /// </example>
        /// </summary>
        [Required]
        public required int courseID { get; set; }
        [ForeignKey("courseID")]
        public Course Course { get; set; }
        //Foreign Key for subjectCode
        /// <summary>
        ///  Relation: One and Only One
        ///  Each course-subject pair refers to a specific subject
        ///  One subject can be reused across courses
        /// </summary>
        [Required]
        [ForeignKey("subjectCode")]
        public required int subjectCode { get; set; }
        public Subject Subject { get; set; }
    }
}