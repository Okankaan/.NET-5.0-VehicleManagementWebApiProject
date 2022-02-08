using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VMAPI.Attributes;
using VMBusiness.Abstract;
using VMEntities.VMDtos;

namespace VMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("userAdd")]
        [CustomAuthorizeAttribute(Roles = "SystemAdministrator")]
        public async Task<IActionResult> Add(UserRegistrationDto user)
        {
            var result = await _userService.Add(user);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
