using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using VMAPI.Attributes;
using VMBusiness.Abstract;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos;

namespace VMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("add")]
        [CustomAuthorizeAttribute(Roles = "SystemAdministrator,VehicleAdministrator")]
        public async Task<IActionResult> Add(VehicleInsertUpdateDto vehicle)
        {
            var result = await _vehicleService.Add(vehicle);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getVehicleListByBrandModel")]
        [CustomAuthorizeAttribute(Roles = "SystemAdministrator,VehicleAdministrator")]
        public async Task<IActionResult> GetVehicleListByBrandModel(string brandName, string modelName)
        {
            var result = await _vehicleService.GetVehicleListByBrandModel(brandName, modelName);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        [CustomAuthorizeAttribute(Roles = "SystemAdministrator,VehicleAdministrator")]
        public async Task<IActionResult> Update(VehicleInsertUpdateDto vehicle)
        {
            var result = await _vehicleService.Update(vehicle);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        [CustomAuthorizeAttribute(Roles = "SystemAdministrator,VehicleAdministrator")]
        public async Task<IActionResult> Delete(long vehicleId)
        {
            var result = await _vehicleService.Delete(vehicleId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
