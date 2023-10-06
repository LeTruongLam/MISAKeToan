using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain
{
    public interface IEmployeeValidate
    {
        /// <summary>
        /// Kiem tra co ton tai employeeCode chua
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <exception cref="ConflictException">Neu ton tai</exception>
        /// <returns></returns>
        Task CheckEmployeeExistAsync(Employee employee);
    }
}
