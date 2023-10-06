using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain
{
    public interface IBaseRepository<TEntity>
    {
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        Task<List<TEntity>> GetAllAsync();
      
        Task<TEntity?> FindAsync(Guid id);
       
        Task<TEntity> GetAsync(Guid id);

        Task<List<TEntity>> GetByListAsync(List<Guid> ids);

        Task<int> InsetAsync(TEntity entity);

        Task<int> InsetManyAsync(List<TEntity> entity); 

        Task<int> UpdateAsync(TEntity entity);

        Task<int> UpdateManyAsync(List<TEntity> entity);

        Task<int> DeleteAsync(TEntity entity);
      
        Task<int> DeleteManyAsync(List<TEntity> entity);

    }
}
