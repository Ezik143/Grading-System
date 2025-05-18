using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GradingSystemApi.Models.Entities
{
    public class GradingPeriod
    {
        [Key]
        public int GradingPeriodID { get; set; }
        public int TermID { get; set; }
        [ForeignKey("TermID")]
        public Term? Term { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
