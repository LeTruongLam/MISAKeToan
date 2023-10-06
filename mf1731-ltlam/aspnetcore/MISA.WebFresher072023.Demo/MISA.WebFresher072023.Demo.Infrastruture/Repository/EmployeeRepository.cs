using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.WebFresher072023.Demo.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Infrastruture
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly string _connectionString;

     
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> IsExistEmployeeAsync(string employeeCode)
        {
            using var connection = new MySqlConnection(_connectionString);


            var query = "SELECT EmployeeCode FROM Employee WHERE EmployeeCode = @employeeCode";

            var param = new DynamicParameters();

            param.Add("@employeeCode", employeeCode);

            var result = await connection.QueryFirstOrDefaultAsync<string>(query, param);

            if (result != null)
            {
                return true;
            }
            return false;
        }

        public Task<List<Employee>> SearchEmployeeAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}