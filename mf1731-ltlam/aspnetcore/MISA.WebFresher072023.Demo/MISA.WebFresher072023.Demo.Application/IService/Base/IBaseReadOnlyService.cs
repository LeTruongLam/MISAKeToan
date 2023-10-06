using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
    public interface IBaseReadOnlyService<TDto>
    {
        Task<List<TDto>> GetAllAsync();
     
        Task<TDto> GetAsync(Guid id);
     
    }
}
