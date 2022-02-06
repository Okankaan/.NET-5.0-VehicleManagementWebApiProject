﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetVehicleListByBrandModel(string brandName, string modelName)
        {
            var result = await _vehicleService.GetVehicleListByBrandModel(brandName, modelName);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
    }
}
