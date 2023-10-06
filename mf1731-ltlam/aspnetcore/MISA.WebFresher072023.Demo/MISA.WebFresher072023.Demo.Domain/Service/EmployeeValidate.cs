using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain
{
    /// <summary>
    /// Class validate nghiep vu
    /// </summary>
    public class EmployeeValidate : IEmployeeValidate
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeValidate(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CheckEmployeeExistAsync(Employee employee)
        {
            var isExistEmployee = await _employeeRepository.IsExistEmployeeAsync(employee.EmployeeCode);
            
            if(isExistEmployee == true )
            {
                throw new ConflictException();

            }
        }
    }
}
