using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDBEntities;
using VMEntities.VMDtos;

namespace VMDataAccess.Abstract.Repositories
{
    public interface IUserDal : IBaseEntityRepository<User>
    {
        Task<User> GetUserByEmailAndPassword(UserLoginDto userLoginDto);
    }
}
