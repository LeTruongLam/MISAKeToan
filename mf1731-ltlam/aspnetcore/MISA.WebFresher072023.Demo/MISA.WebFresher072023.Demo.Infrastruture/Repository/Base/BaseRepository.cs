using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.WebFresher072023.Demo.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;


namespace MISA.WebFresher072023.Demo.Infrastruture
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : IEntity
    {
      
        private readonly string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public virtual string TableName { get; set; } = typeof(TEntity).Name;




        public async Task<TEntity?> FindAsync(Guid id)
        {
            using var connection = new MySqlConnection(_connectionString);

            var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id = @id";
            var param = new DynamicParameters();
            param.Add("id", id);

            var result = await connection.QueryFirstOrDefaultAsync<TEntity>(sql, param);
            return result;
        }
        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            using var connection = new MySqlConnection(_connectionString);
            var properties = typeof(TEntity).GetProperties();

            var columnNames = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

            var sql = $"UPDATE {TableName} SET {columnNames} WHERE {TableName}Id = @Id";

            var parameters = new DynamicParameters(entity);
            parameters.Add("Id", entity.GetId());

            var result = await connection.ExecuteAsync(sql, parameters);

            return result;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using var connection = new MySqlConnection(_connectionString);

            var sql = $"SELECT * FROM {TableName}";
            var result = await connection.QueryAsync<TEntity>(sql);

            return result.ToList();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            var entity = await FindAsync(id);
            if(entity == null)
            {
                throw new NotImplementedException("Không tìm thấy bản ghi");
            }
            return entity;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = $"DELETE FROM {TableName} WHERE {TableName}Id = @id";

            var param = new DynamicParameters();
            param.Add("id", entity.GetId());
            var result = await connection.ExecuteAsync(sql, param);
            return result;
        }

        public async Task<int> DeleteManyAsync(List<TEntity> entities)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = $"DELETE FROM {TableName} WHERE {TableName}Id IN @ids";

            var param = new DynamicParameters();
            param.Add("ids", entities.Select(entity => entity.GetId()));
            var result = await connection.ExecuteAsync(sql, param);
            return result;
        }

        public Task<List<TEntity>> GetByListAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsetAsync(TEntity entity)
        {
            var connection = new MySqlConnection(_connectionString);

            var properties = typeof(TEntity).GetProperties();

            var columnNames = string.Join(", ", properties.Select(p => p.Name));
            var paramNames = string.Join(", ", properties.Select(p => "@" + p.Name));

            var sql = $"INSERT INTO {TableName} ({columnNames}) VALUES ({paramNames});";

            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var value = property.GetValue(entity);
                parameters.Add("@" + property.Name, value);
            }

            await connection.OpenAsync();
            var result = await connection.ExecuteAsync(sql, parameters);

            return result;
        }

        public Task<int> InsetManyAsync(List<TEntity> entity)
        {
            throw new NotImplementedException();
        }

      

        public Task<int> UpdateManyAsync(List<TEntity> entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
