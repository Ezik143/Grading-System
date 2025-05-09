using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Classes
    {
        [Key]
        public required int classID { get; set; }
        public required string Schedule { get; set; }
        //Foreign key to teacherID
        /// <summary>
        /// Relations:One and Only One.
        /// Because each classes there's only one teacher assigned.
        /// </summary>
        public required int teacherID { get; set; }
        [ForeignKey("teacherID")]
        public Teacher Teacher { get; set; }
        //Foreign key to subject_code
        /// <summary>
        ///  Relations: One and Only One.
        ///  Because each class is one subject
        /// </summary>
        public required string subjectCode{ get; set; }
        [ForeignKey("subjectCode")]
        public Subject Subject { get; set; }
    }
}