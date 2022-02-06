using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBusiness.Abstract;
using VMDataAccess.Abstract.Repositories;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos;

namespace VMBusiness.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<User> GetUserByEmailAndPassword(UserLoginDto userLoginDto)
        {
            return await _userDal.GetUserByEmailAndPassword(userLoginDto);
        }
    }
}
