using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos;
using VMEntities.VMDtos.ReturnResultEntities.Abstract;

namespace VMBusiness.Abstract
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAndPassword(UserLoginDto userLoginDto);
        Task<IResult> Add(UserRegistrationDto user);
    }
}
