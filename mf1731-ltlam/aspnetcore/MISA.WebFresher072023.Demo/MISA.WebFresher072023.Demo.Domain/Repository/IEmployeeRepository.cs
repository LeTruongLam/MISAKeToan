using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain
{

    /// <summary>
    /// Interface tuong tac voi Repository cua Employee
    /// </summary>
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
      
        Task<bool> IsExistEmployeeAsync(string employeeCode);

        Task<List<Employee>> SearchEmployeeAsync(string query);



    }
}
