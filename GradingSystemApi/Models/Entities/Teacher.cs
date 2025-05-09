using System.ComponentModel.DataAnnotations;
using Team_Yeri_enrollment_system.GradingLibrary.Models;
namespace GradingSystemApi.Models.Entities
{
    public class Teacher
    {
        [Key]
        [Required]
        public required int teacherID { get; set; }
        [Required]
        [MaxLength(60)]
        public required string firstName { get; set; }
        [Required]
        [MaxLength(60)]
        public required string lastname { get; set; }
        [Required]
        [MaxLength(60)]
        public required string Gmail { get; set; }
        [Required]
        [MaxLength(60)]
        public required string phoneNumber { get; set; }
        [Required]
        [MaxLength(60)]
        public required string Department { get; set; }

        //Teacher relation to teacherSubject one and only one
        /// <summary>
        /// Each Teacher is tied to one subject
        /// </summary>
        public teacherSubject teacherSubject { get; set; }

        //Teacher relation to classes, One to many
        /// <summary>
        /// Each Teacher can taught many classes
        /// </summary>
        public List<Classes> Classes { get; set; } = new List<Classes>();

    }
}