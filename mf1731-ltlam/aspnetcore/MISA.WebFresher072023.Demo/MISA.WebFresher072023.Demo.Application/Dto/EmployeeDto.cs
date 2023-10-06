using MISA.WebFresher072023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
    public class EmployeeDto : BaseDto
    {
        public Guid EmployeeId { get; set; }

        public string? EmployeeCode { get; set; }

        public string? FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender? Gender { get; set; }
    }
}
