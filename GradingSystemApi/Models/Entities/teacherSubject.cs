using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GradingSystemApi.Models.Entities
{
    public class teacherSubject
    {
        [Key]
        [Required]
        public required int teacherSubjectID { get; set; }

        //Foreign Key to teacherID
        /// <summary>
        /// Relation: Zero or many
        /// because teacher can teach many subjects
        /// </summary>
        [Required]
        public required int teacherID { get; set; }
        [ForeignKey("teacherID")]
        public Teacher Teacher { get; set; }

        //Foreign Key to subjectCode
        /// <summary>
        /// Relation: One and Only One
        /// because teacher record is tied to one subject
        /// </summary>
        [Required]
        public required string subjectCode { get; set; }
        [ForeignKey("subjectCode")]
        public Subject Subject { get; set; }
    }
}