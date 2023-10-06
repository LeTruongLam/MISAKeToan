using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher072023.Demo.Application;
using MISA.WebFresher072023.Demo.Domain;

namespace MISA.WebFresher072023.Demo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<EmployeeDto, EmployeeCreateDto,
        EmployeeUpdateDto>
    {
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {

        }

    } 
}
