using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher072023.Demo.Application;

namespace MISA.WebFresher072023.Demo.Controllers
{
    public class BaseReadOnlyController<TDto> : ControllerBase
    {
        protected readonly IBaseReadOnlyService<TDto> BaseReadOnlyService;

        public BaseReadOnlyController(IBaseReadOnlyService<TDto> baseReadOnlyService)
        {
            BaseReadOnlyService = baseReadOnlyService;
        }

        [HttpGet]
        public async Task<List<TDto>> GetAllAsync()
        {
            var result = await BaseReadOnlyService.GetAllAsync();
            return result;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<TDto> GetEmployeeAsync(Guid id)
        {

            var result = await BaseReadOnlyService.GetAsync(id);
            return result;
        }
    }
}
