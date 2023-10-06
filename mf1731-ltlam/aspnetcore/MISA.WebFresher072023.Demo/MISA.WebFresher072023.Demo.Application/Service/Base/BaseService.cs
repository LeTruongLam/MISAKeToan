using MISA.WebFresher072023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
    public abstract class BaseService<TEntity, TDto, TCreateDto, TUpdateDto> : BaseReadOnlyService<TEntity, TDto>,
        IBaseService<TDto, TCreateDto, TUpdateDto> where TEntity : IEntity
    {
        protected BaseService(IBaseRepository<TEntity> baseRepository) : base(baseRepository) {
        
        }
        public async Task<TDto> InsertAsync(TCreateDto createDto)
        {
            var entity = MapCreateDtoToEntity(createDto);

            if (entity.GetId() == Guid.Empty) {
                entity.SetId(Guid.NewGuid());
            }
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedBy ??= "LTLAM";
                baseEntity.CreatedDate ??= DateTime.Now;
                baseEntity.ModifiedBy ??= "LTLAM";
                baseEntity.ModifiedDate ??= DateTime.Now;

            }
            await ValidateCreateBusiness(entity);
            await BaseRepository.InsetAsync(entity);
            var result = MapEntityToDto(entity);
            return result;

        }
        public virtual async Task<TDto> UpdateAsync(Guid id, TUpdateDto updateDto)
        {
            var entity = await BaseRepository.GetAsync(id);

            var newEntity = MapUpdateDtoToEntity(entity, updateDto);
            await ValidateUpdateBusiness(newEntity);

            await BaseRepository.UpdateAsync(newEntity);

            var result = MapEntityToDto(newEntity);
            return result;
        }
      

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await BaseRepository.GetAsync(id);

            var result = await BaseRepository.DeleteAsync(entity);
            return result;
        }

        public async Task<int> DeleteManyAsync(List<Guid> ids)
        {
            var entities = await BaseRepository.GetByListAsync(ids);

            var result = await BaseRepository.DeleteManyAsync(entities);
            return result;
        }

       

        public Task<List<TDto>> SearchAsync(string query)
        {
            throw new NotImplementedException();
        }
        public abstract TEntity MapCreateDtoToEntity(TCreateDto entity);

        // virtual thi override hya khong cung duoc
        public  virtual async Task ValidateCreateBusiness(TEntity entity)
        {
            await Task.CompletedTask;
        }
        public abstract TEntity MapUpdateDtoToEntity(TEntity entity, TUpdateDto updateDto);
        public  virtual async Task ValidateUpdateBusiness(TEntity entity)
        {
            await Task.CompletedTask;

        }



    }
}
