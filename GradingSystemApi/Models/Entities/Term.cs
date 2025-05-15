using System.ComponentModel.DataAnnotations;
namespace GradingSystemApi.Models.Entities
{
    public class Term
    {
        [Key]
        [Required]
        public int TermID { get; set; }
        [Required]
        public required string TermName { get; set; }
        [Required]
        public required DateOnly AcademicYear { get; set; }
    }
}