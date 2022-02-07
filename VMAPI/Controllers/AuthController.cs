using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using VMBusiness.Abstract;
using VMEntities.JWT;
using VMEntities.VMDtos;

namespace VMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly IMemoryCache _cache;

        public AuthController(IAuthService authService, IJwtAuthManager jwtAuthManager, IMemoryCache cache)
        {
            _authService = authService;
            _jwtAuthManager = jwtAuthManager;
            _cache = cache;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var userToLogin = await _authService.Login(userLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var claims = new List<Claim>();
            claims.Add(new Claim("username", userLoginDto.EMail));

            foreach (var userRole in userToLogin.Data.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
            }

            var jwtResult = _jwtAuthManager.GenerateTokens(userLoginDto.EMail, claims.ToArray(), DateTime.Now);

            if (jwtResult != null)
            {
                JwtCache jwtCache = new JwtCache();
                jwtCache.Token = jwtResult;
                jwtCache.isActive = true;
                MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions();
                memoryCacheEntryOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(60);
                _cache.Set(userLoginDto.EMail, jwtCache, memoryCacheEntryOptions);

                return Ok(new LoginResult
                {
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            return BadRequest();
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            var claims = ((System.Security.Claims.ClaimsIdentity)User.Identity).Claims;

            foreach (var claim in claims)
            {
                if (claim.Type.Equals("username"))
                {
                    var jwtCacheParam = _cache.Get(claim.Value);
                    if (jwtCacheParam != null)
                    {
                        _cache.Remove(claim.Value);
                    }
                }
            }

            return Ok();
        }
    }
}
