using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBusiness.Abstract;
using VMBusiness.Constants;
using VMDataAccess.Abstract.Repositories;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos;
using VMEntities.VMDtos.ReturnResultEntities;
using VMEntities.VMDtos.ReturnResultEntities.Abstract;

namespace VMBusiness.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IUserRoleDal _userroleDal;
        private readonly IMapper _mapper;
        public UserService(IUserDal userDal, IMapper mapper, IUserRoleDal userroleDal)
        {
            _userDal = userDal;
            _mapper = mapper;
            _userroleDal = userroleDal;
        }
        public async Task<User> GetUserByEmailAndPassword(UserLoginDto userLoginDto)
        {
            return await _userDal.GetUserByEmailAndPassword(userLoginDto);
        }
        public async Task<IResult> Add(UserRegistrationDto user)
        {
            if (!CheckUserExist(user.EMail).Result.Success)
            {
                await _userDal.Add(_mapper.Map<User>(user));

                User userItem = await _userDal.Get(x => x.EMail == user.EMail && x.Active == true);
                await _userroleDal.Add(
                    new UserRole
                    {
                        UserId = userItem.Id,
                        RoleId = 5 // If Role Add method will write, this hard codded parameter, will get from Roles Table. RoleId = 5 is equal to "User" Role Type.
                    });
                return new SuccessResult(ConstantMessages.UserAdded);
            }
            return new ErrorResult(ConstantMessages.RecordAlreadyExist);

        }
        private async Task<IDataResult<User>> CheckUserExist(string userEMail)
        {
            User userItem = await _userDal.Get(x => x.EMail == userEMail && x.Active == true);

            if (userItem != null)
                return new SuccessDataResult<User>(userItem);

            return new ErrorDataResult<User>();
        }
    }
}
