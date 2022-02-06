using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VMBusiness.Abstract;

namespace VMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _brandService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("allModelsOfBrands")]
        public async Task<IActionResult> GetAllModelsOfBrands()
        {
            var result = await _brandService.GetAllModelsOfBrands();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
    }
}
