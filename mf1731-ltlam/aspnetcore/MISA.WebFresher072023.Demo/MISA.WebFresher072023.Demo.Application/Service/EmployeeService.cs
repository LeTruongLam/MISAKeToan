using MISA.WebFresher072023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
    public class EmployeeService : BaseService<Employee, EmployeeDto, EmployeeCreateDto,
        EmployeeUpdateDto>, IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeValidate _employeeValidate;

        public EmployeeService(IEmployeeRepository
            employeeRepository, 
            IEmployeeValidate employeeValidate) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeValidate = employeeValidate;
        }

        public override Employee MapCreateDtoToEntity(EmployeeCreateDto createDto)
        {
            var employee = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                EmployeeCode = createDto.EmployeeCode,
                FullName = createDto.FullName,
                DateOfBirth = createDto.DateOfBirth,
                Gender = createDto.Gender,
                CreatedBy = createDto.CreatedBy,
                CreatedDate = createDto.CreatedDate,
                ModifiedBy = createDto.ModifiedBy,
                ModifiedDate = createDto.ModifiedDate
            };
            return employee;
        }
        public override async Task ValidateCreateBusiness(Employee entity)
        {
            // Check trung
            await _employeeValidate.CheckEmployeeExistAsync(entity);
        }


        public override EmployeeDto MapEntityToDto(Employee employee)
        {
            var employeeDto = new EmployeeDto()
            {
                EmployeeId = employee.EmployeeId,
                EmployeeCode = employee.EmployeeCode,
                FullName = employee.FullName,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                CreatedBy = employee.CreatedBy,
                CreatedDate = employee.CreatedDate,
                ModifiedBy = employee.ModifiedBy,
                ModifiedDate = employee.ModifiedDate
            };
            return employeeDto;
        }

        public override Employee MapUpdateDtoToEntity(Employee employee, EmployeeUpdateDto updateDto)
        {
            var newEmployee = new Employee()
            {   
                EmployeeId = employee.EmployeeId,
                EmployeeCode = updateDto.EmployeeCode,
                FullName = updateDto.FullName,
                DateOfBirth = updateDto.DateOfBirth,
                Gender = updateDto.Gender,
                CreatedBy = updateDto.CreatedBy,
                CreatedDate = updateDto.CreatedDate,
                ModifiedBy = updateDto.ModifiedBy,
                ModifiedDate = updateDto.ModifiedDate
            };
            return newEmployee;
        }

    }
}
