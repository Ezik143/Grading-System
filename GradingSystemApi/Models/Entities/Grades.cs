using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team_Yeri_enrollment_system.GradingLibrary.Models;
namespace GradingSystemApi.Models.Entities
{
    public class Grades
    {
        [Key]
        [Required]
        public required int gradeID { get; set; }

        //Foreign Key to studentID
        /// <summary>
        /// Relations: One and only one
        /// Grades is tied to a specific student
        /// </summary>
        [Required]
        public required int studentID { get; set; }
        [ForeignKey("studentID")]
        public Students Student { get; set; }

        // Foreign Key to classID
        /// <summary>
        /// Relations: One and only one
        /// Grade is tied to a specific class
        /// </summary>
        [Required]
        public required int classID { get; set; }
        [ForeignKey("classID")]
        public Classes Class { get; set; }

        [Required]
        [MaxLength(60)]
        public required string assesmentType { get; set; }

        // Foreign Key to termID
        /// <summary>
        /// relation: One and only One
        /// Each Grade is tied to exactly one Term
        /// </summary>
        [Required]
        public required int termID { get; set; }
        [ForeignKey("termID")]
        public Terms Term { get; set; }

        // Foreign Key to subjectCode
        /// <summary>
        /// relation: Zero or many
        /// Each grade is associated with a specific subject
        /// </summary>
        [Required]
        public required string subjectCode { get; set; }
        [ForeignKey("subjectCode")]
        public Subject Subject { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public  decimal Score { get; set; }
    }
}