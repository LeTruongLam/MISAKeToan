using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
    public interface IBaseService<TDto,TCreateDto, TUpdateDto> : 
        IBaseReadOnlyService<TDto>
    {
      
        Task<TDto> InsertAsync(TCreateDto createDto);
       
        Task<TDto> UpdateAsync(Guid id, TUpdateDto updateDot);
       
        Task<int> DeleteAsync(Guid id);
      
        Task<int> DeleteManyAsync(List<Guid> ids);

        Task<List<TDto>> SearchAsync(string query);
    }
}
