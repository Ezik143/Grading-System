﻿using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.Dto
{
    public class TermDto
    {
        public required string TermName { get; set; }
        public required DateOnly AcademicYear { get; set; }
    }
}
