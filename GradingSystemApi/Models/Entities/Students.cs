using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
namespace GradingSystemApi.Models.Entities

{
    public class Students
    {
        [Key]
        [Required]
        public int StudentID { get; set; }

        [MaxLength(200)]
        public required string Name { get; set; }
        [MaxLength(123)]
        public required DateOnly BirthDate { get; set; }

        [Required]
        [MaxLength(1)]
        public required char Sex { get; set; }
        [Required]
        [MaxLength(60)]
        public required string Gmail { get; set; }
        [Required]
        [MaxLength(20)]
        public required string Number { get; set; }
    }
}
