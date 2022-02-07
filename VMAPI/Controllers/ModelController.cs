using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VMBusiness.Abstract;

namespace VMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;
        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet("getByBrandId")]
        public async Task<IActionResult> GetByBrandId(int brandId)
        {
            var result = await _modelService.GetByBrandId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
