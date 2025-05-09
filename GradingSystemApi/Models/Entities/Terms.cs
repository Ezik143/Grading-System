using System.ComponentModel.DataAnnotations;
namespace GradingSystemApi.Models.Entities
{
    public class Terms
    {
        [Key]
        [Required]
        public required int Term_ID { get; set; }
        [Required]
        [MaxLength(60)]
        public required string Term_Name { get; set; }
        [Required]
        public required DateOnly Academic_Year { get; set; }

        //Terms relation to Grades, zero to many
        public ICollection<Grades> Grades { get; set; } = new List<Grades>();

        public Enrollment Enrollment { get; set; }
    }
}