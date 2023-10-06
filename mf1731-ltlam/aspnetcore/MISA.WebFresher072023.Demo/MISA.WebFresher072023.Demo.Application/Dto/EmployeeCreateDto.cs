using MISA.WebFresher072023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
    public class EmployeeCreateDto : BaseDto
    {
        [MaxLength(20)]
        public string? EmployeeCode { get; set; }
        [MaxLength(255)]
        public string? FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender? Gender { get; set; }
    }
}
