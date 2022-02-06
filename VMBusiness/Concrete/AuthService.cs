using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBusiness.Abstract;
using VMEntities.JWT;
using VMEntities.VMDtos.ReturnResultEntities.Abstract;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos;
using System.Security.Claims;
using VMBusiness.Utilities;
using System.IdentityModel.Tokens.Jwt;
using VMEntities.VMDtos.ReturnResultEntities;

namespace VMBusiness.Concrete
{
    public class AuthService:IAuthService
    {
        private IUserService _userService;
        public IConfiguration Configuration { get; }

        private TokenOptions _tokenOptions = new TokenOptions();
        public AuthService(IConfiguration configuration, IUserService userService)
        {
            Configuration = configuration;
            _userService = userService;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        public async Task<AccessToken> CreateAccessToken(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("username", user.EMail));
            claims.Add(new Claim("displayname", user.Name));

            foreach (var userRole in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, "VehicleAdministrator"));
            }

            var token = JWTHelper.GetJwtToken(
                user.EMail,
                _tokenOptions.SecurityKey,
                _tokenOptions.Issuer,
                _tokenOptions.Audience,
                TimeSpan.FromMinutes(_tokenOptions.AccessTokenExpiration),
                claims.ToArray());

            return new AccessToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }

        public async Task<IDataResult<User>> Login(UserLoginDto userLoginDto)
        {
            var user = await _userService.GetUserByEmailAndPassword(userLoginDto);
            if (user == null)
            {
                return new ErrorDataResult<User>(/*ConstantMessages.UserNotFound*/"UserNotFound");
            }

            return new SuccessDataResult<User>(user, /*ConstantMessages.LoginSuccessful*/"LoginSuccessful");
        }
    }
}
