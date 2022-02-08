using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VMAPI.Attributes;
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
        [CustomAuthorizeAttribute(Roles = "SystemAdministrator,BrandAdministrator,User")]
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
        [CustomAuthorizeAttribute(Roles = "SystemAdministrator,BrandAdministrator")]
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
