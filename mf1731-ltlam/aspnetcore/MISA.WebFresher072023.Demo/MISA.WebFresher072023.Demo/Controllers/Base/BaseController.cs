using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher072023.Demo.Application;

namespace MISA.WebFresher072023.Demo.Controllers
{
    public class BaseController<TDto, TCreateDto, TUpdateDto> : BaseReadOnlyController<TDto>
    {
        protected   readonly IBaseService<TDto, TCreateDto, TUpdateDto> BaseService;
        public BaseController(IBaseService<TDto,TCreateDto, TUpdateDto> baseService) : base(baseService)
        {
            BaseService = baseService;

          
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(TCreateDto createDto)
        {
            var result = await BaseService.InsertAsync(createDto);
            return StatusCode(StatusCodes.Status201Created, result);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<TDto> UpdateAsync(Guid id, TUpdateDto updateDot)
        {
            var result = await BaseService.UpdateAsync(id, updateDot);
            return result;
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteAsync(Guid id)
        {
            var result = await BaseService.DeleteAsync(id);
            return result;
        }

        [HttpGet]
        [Route("search")]
        public async Task<List<TDto>> SearchAsync([FromQuery] string query)
        {
            var result = await BaseService.SearchAsync(query);
            return result;
        }
    }
}
