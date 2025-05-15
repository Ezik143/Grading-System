using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team_Yeri_enrollment_system.GradingLibrary.Models;
namespace GradingSystemApi.Models.Entities
{
    public class Grade
    {
        [Key]
        [Required]
        public int GradeID { get; set; }
        [Required]
        public  required int StudentID { get; set; }
        //[ForeignKey("StudentID")]
        //[Required]
        //public Students? Student { get; set; }
        //[Required]
        public  required int ClassID { get; set; }
        //[ForeignKey("ClassID")]
        //[Required]
        //public Classes? Classes { get; set;}    
        [Required]
        public required string AssessmentType { get; set; }
        [Required]
        public  required int TermID { get; set; }
        //[ForeignKey("TermID")]
        //[Required]
        //public  Terms? Terms { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public required decimal Score { get; set; }
    }
}