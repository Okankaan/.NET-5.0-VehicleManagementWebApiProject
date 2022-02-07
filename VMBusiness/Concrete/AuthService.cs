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
using VMBusiness.Constants;

namespace VMBusiness.Concrete
{
    public class AuthService : IAuthService
    {
        private IUserService _userService;
        public IConfiguration Configuration { get; }

        public AuthService(IConfiguration configuration, IUserService userService)
        {
            Configuration = configuration;
            _userService = userService;
        }

        public async Task<IDataResult<User>> Login(UserLoginDto userLoginDto)
        {
            var user = await _userService.GetUserByEmailAndPassword(userLoginDto);
            if (user == null)
            {
                return new ErrorDataResult<User>(ConstantMessages.UserNotFound);
            }
            return new SuccessDataResult<User>(user, ConstantMessages.LoginSuccessful);
        }
    }
}
