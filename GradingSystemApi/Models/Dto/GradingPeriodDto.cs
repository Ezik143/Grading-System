using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.Dto
{
    public class GradingPeriodDto
    {
        public int TermID { get; set; }
        public required string Name { get; set; }
    }
}
